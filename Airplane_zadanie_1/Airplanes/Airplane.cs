using Airplane_zadanie_1.Equipment.Ammunitions;
using Airplane_zadanie_1.Equipment.Armors;
using Airplane_zadanie_1.Equipment.Guns;
using Airplane_zadanie_1.Teams;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Airplanes
{
    public enum TypeOfPlanes
    {
        Fighter,
        Bomber,
        Stormtrooper
    }
    public abstract class Airplane
    {
        private Double _hp;
        private Double _weight;
        private Boolean isStaned = false;
        private Boolean isMarked=false;
        private Boolean isAlive = true;
        private static Int32 _Id;
        public Airplane(Double hp,Double weight, Double baseAccuracy ,Double baseDodgeChance,Double baseArmor)
        {
            _hp= hp;
            MaxHp = hp;
            _weight= weight;
            MaxWeight = weight;
            BaseAccuracy = baseAccuracy;
            BaseDodgeChance=baseDodgeChance;
            BaseArmor = baseArmor;
            _Id++;

        }
        public abstract TypeOfPlanes Type{  get; }
        public Squadron? Squadron { get; set; }
        public Int32 Id => _Id;
        public Double Weight=> _weight;
        public Double HP => _hp;
        public Double MaxHp { get; }
        public Double MaxWeight { get; }
        public Double BaseAccuracy {get;}
        public Double BaseArmor { get; }
        public Double BaseDodgeChance { get; }
        public Boolean IsAlive => isAlive;
        public Int32 CountAmmo { get; set; }
        public Guns? Gun { get; set; }
        public Armors? Armor { get; set; }
        public Ammunitions? Ammunition { get; set; }
        public void Stan() { isStaned = !isStaned; }
        public void Mark() { isMarked = !isMarked; }

        public Double EffectiveAccuracy => BaseAccuracy + BaseAccuracy*Gun.AccuracyBuff;
        public Double EffectiveDodgeChance => BaseDodgeChance + BaseDodgeChance*Armor.DodgeBuff;
        public Double EffectiveArmor => BaseArmor + BaseArmor * Armor.Protection;
 
        public void Die()
        {
            if (isAlive && HP<=0.0)
            {
                isAlive = false;
            }
        }
        public Double MarkBuff() {
            if (isMarked)
            {
                Mark();
                return 0.15;
            }
            else
            {
                return 0.0;
            }
        }
        public Boolean IsStaned()
        {
            if (isStaned)
            {
                Stan();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean TryDodge()
        {
            return Rand.Chance(EffectiveDodgeChance);
        }
        protected virtual Double DamageMultiplierAgainst(Airplane target) => 1.0;
        protected virtual Boolean TryAbsorbHit() => false;
        public virtual Boolean TrySpecialAttack(IReadOnlyList<Airplane> enemies) => false;
        public void ChancheHP(Double value)
        {
            _hp += value;
        }
        public virtual void TakeDamage(Airplane enemy)
        {
            if(TryAbsorbHit())
            {
                return;
            }
            Double ReceivedDamage = enemy.Gun.Shot() + enemy.Ammunition.Damage * enemy.Gun.ShotCount;
            ReceivedDamage *= enemy.DamageMultiplierAgainst(this);
            ReceivedDamage -= ReceivedDamage * EffectiveArmor;
            ChancheHP(ReceivedDamage);
            switch (enemy.Ammunition.Type)
            {
                case TypeOfAmmunitions.Tracers:
                    {
                        this.Mark();
                        break;
                    }
                case TypeOfAmmunitions.Explosive:
                    {
                        this.Stan();
                        break;
                    }
            }
            System.Console.WriteLine($"Самолет №{enemy.Id} попал с уроном {ReceivedDamage} по самолету №{this.Id}, осталось {this.HP} HP");
            Die();
    
        }
        public virtual void Attack(Airplane target)
        {
            if (Gun != null && isAlive && CountAmmo > 0)
            {
                if (Rand.Chance(EffectiveAccuracy + EffectiveAccuracy * target.MarkBuff()))
                {
                    if (!Gun.IgnoreDodge)
                    {
                        if (target.TryDodge())
                        {
                            System.Console.WriteLine($"Самолет №{Id} промах");
                        }
                        else
                        {
                            CountAmmo--;
                            target.TakeDamage(this);
                        }
                    }
                    else
                    {
                        CountAmmo--;
                        target.TakeDamage(this);

                    }
                }
            }
            else
            {
                System.Console.WriteLine($"Самолет №{Id} - боекомлект пуст");
            }

        }
    }
}
