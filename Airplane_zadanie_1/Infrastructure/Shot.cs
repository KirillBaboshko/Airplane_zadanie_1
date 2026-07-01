using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Equipment.Ammunitions;
using Airplane_zadanie_1.Equipment.Guns;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Infrastructure
{
    public class Shot
    {
        public Shot(Airplane owner, Airplane target,Guns gun, Ammunitions ammo)
        {
            Owner = owner;
            Target = target;
            Gun= gun;
            Ammunition = ammo;
        }
        public Guns? Gun { get; }
        public Ammunitions? Ammunition { get; }
        public Airplane Owner { get;  }
        public Airplane Target { get; }

        private Double Calculation()=>(Gun.Shot() + Ammunition.Damage * Gun.ShotCount) * Owner.DamageMultiplierAgainst(Target);
        public void FixHit()
        {
            if (Rand.Chance(Owner.EffectiveAccuracy + Owner.EffectiveAccuracy * Target.MarkBuff()))
            {
                if (!Gun.IgnoreDodge && Target.TryDodge())
                {
                    WriteLine($"Самолет №{Target.Id} увернулся от выстрела самолета №{Owner.Id}");
                    return;
                }
                Double resultDamage = Calculation();
                WriteLine($"Самолет №{Owner.Id} попал по самолету №{Target.Id} c уроном {resultDamage}");
                Target.TakeDamage(resultDamage);
                Owner.Ammunition.SpecialEffects(Target);
                return;
            }
            WriteLine($"Самолет №{Owner.Id} промах");
        }
    }
}
