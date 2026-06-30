using Airplane_zadanie_1.Equipment.Ammunitions;
using Airplane_zadanie_1.Equipment.Armors;
using Airplane_zadanie_1.Equipment.Guns;
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
        private Boolean isStaned = false;
        private Boolean isMarked=false;
        private Boolean isAlive = true;
        private static Int32 _Id;
        public Airplane(Double hp, Double baseAccuracy ,Double baseDodgeChance)
        {
            _hp= hp;
            MaxHp = hp;
            BaseAccuracy = baseAccuracy;
            BaseDodgeChance=baseDodgeChance;
            _Id++;

        }
        public abstract TypeOfPlanes TypeOfPlane{  get; }
        public Int32 Id => _Id;
        public Double HP => _hp;
        public Double MaxHp { get; }
        public Double BaseAccuracy {get;}
        public Double BaseArmor { get; }
        public Double BaseDodgeChance { get; }
        public Guns? Gun { get; set; }
        public Armors? Armor { get; set; }
        public Amunitions? Amunition { get; set; }
        public virtual void Stan() { isStaned = !isStaned; }
        public virtual void Mark() { isMarked = !isMarked; }

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
        public virtual Double MarkBuff() {
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
        public virtual Boolean TryDodge()
        {
            return Rand.Chance(EffectiveDodgeChance);
        }
        public virtual void TakeDamage(Airplane enemy)
        {
            Double ReceivedDamage = enemy.Gun.Shot() + enemy.Amunition.Damage * enemy.Gun.ShotCount;
            ReceivedDamage -= ReceivedDamage * EffectiveArmor;
            this._hp-= ReceivedDamage;
            switch(enemy.Amunition.Type)
            {
                case TypeOfAmunitions.Tracers:
                    {
                        this.Mark();
                        break;
                    }
                case TypeOfAmunitions.Explosive:
                    {
                        this.Stan();
                        break;
                    }
            }
            System.Console.WriteLine($"Самолет №{enemy.Id} попал с уроном {ReceivedDamage} по самолету №{this.Id}, осталось {this.HP} HP");
    
        }
        public virtual void Attack(Airplane target)
        {
            if(Gun!=null && isAlive)
            {
                if(Rand.Chance(EffectiveAccuracy+ EffectiveAccuracy*target.MarkBuff()))
                {
                    if(!Gun.IgnoreDodge)
                    {
                        if(target.TryDodge())
                        {
                            System.Console.WriteLine($"Самолет №{Id} промах");
                        }
                        else
                        {
                            target.TakeDamage(this);
                        }
                    }
                    else
                    {
                        target.TakeDamage(this);
               
                    }
                }
            }

        }
    }
}
