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
        public Shot(Airplane owner, Double resultDamage)
        {
            Owner = owner;
 
            ResultDamage=resultDamage;
        }
        public Double ResultDamage { get; }
        public Airplane Owner { get;  }

        
        public void FixHit()
        {
            if (Rand.Chance(Owner.EffectiveAccuracy + Owner.EffectiveAccuracy * Owner.Target.MarkBuff()))
            {
                if (!Owner.Gun.IgnoreDodge && Owner.Target.TryDodge())
                {
                    WriteLine($"Самолет №{Owner.Target.Id} увернулся от выстрела самолета №{Owner.Id}");
                    return;
                } 
                WriteLine($"Самолет №{Owner.Id} попал по самолету №{Owner.Target.Id} c уроном {ResultDamage}");
                Owner.Target.TakeDamage(ResultDamage);
                Owner.Ammunition.SpecialEffects(Owner.Target);
                return;
            }
            WriteLine($"Самолет №{Owner.Id} промах");
        }
    }
}
