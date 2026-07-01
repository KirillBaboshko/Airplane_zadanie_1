using Airplane_zadanie_1.Equipment.Ammunitions;
using Airplane_zadanie_1.Equipment.Armors;
using Airplane_zadanie_1.Equipment.Guns;
using Airplane_zadanie_1.Teams;
using static System.Console;

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
            _weight= 0;
            MaxWeight = weight;
            BaseAccuracy = baseAccuracy;
            BaseDodgeChance=baseDodgeChance;
            BaseArmor = baseArmor;
            Id=++_Id;

        }
        public abstract TypeOfPlanes Type{  get; }
        public Squadron? Squadron { get; set; }
        public Int32 Id { get; }
        public Double Weight=> _weight;
        public Double HP => _hp;
        public Double MaxHp { get; }
        public Double MaxWeight { get; }
        public Double BaseAccuracy {get;}
        public Double BaseArmor { get; }
        public Double BaseDodgeChance { get; }
        public Boolean IsAlive => isAlive;
        public Boolean IsCanAtttack { get; private set; }
        public Int32 CountAmmo { get; set; }
        public Guns? Gun { get; set; }
        public Armors? Armor { get; set; }
        public Ammunitions? Ammunition { get; set; }

        public void MontageGun(Guns? gun)
        {
            if ((MaxWeight-(_weight+ gun.Weight))>=0)
            {
                _weight += gun.Weight;
                Gun = gun;
            }
            else
            {
                WriteLine($"У самолета №{Id} перегруз, установка оружия невозможна!");
            }
        }
        public void MontageArmor(Armors? armor)
        {
            if ((MaxWeight - (_weight + armor.Weight)) >= 0)
            {
                _weight += armor.Weight;
                Armor = armor;
            }
            else
            {
                WriteLine($"У самолета №{Id} перегруз, установка брони невозможна!");
            }
        }
        public void MontageAmmunition(Ammunitions? ammo)
        {
            CountAmmo = 0;
            Ammunition = ammo;
            while ((MaxWeight - (_weight + ammo.Weight)) >= 0)
            {
                CountAmmo++;
                _weight += ammo.Weight;
            }
            WriteLine($"У самолета №{Id} боекомплект под завязку,удалось погрузить {CountAmmo} снарядов");
        }
        public void Stan() { isStaned = !isStaned; }
        public void Mark() { isMarked = !isMarked; }

        public Double EffectiveAccuracy => BaseAccuracy + BaseAccuracy*Gun.AccuracyBuff;
        public Double EffectiveDodgeChance => BaseDodgeChance + BaseDodgeChance*Armor.DodgeBuff;
        public Double EffectiveArmor => BaseArmor + BaseArmor * Armor.Protection;
 
        public Boolean Die()
        {
            if (isAlive && HP<=0.0)
            {
                isAlive = false;
                _hp = 0;
                return true;
            }
            return false;
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
            if (_hp<0)
            {
                _hp = 0;
            }
        }
        public virtual void TakeDamage(Double damage)
        {
            if (TryAbsorbHit())
            {
                return;
            }
            ChancheHP(-damage);
        }
        public virtual Double CalculateDamage(Airplane target)
        {
            Double ReceivedDamage = Gun.Shot() + Ammunition.Damage * Gun.ShotCount;
            ReceivedDamage *= DamageMultiplierAgainst(target);
            ReceivedDamage -= ReceivedDamage * target.EffectiveArmor;
            return ReceivedDamage;
        }
        public virtual Double Attack(Airplane target)
        {
            if (Gun != null && isAlive && CountAmmo > 0)
            {
                CountAmmo--;
                if (Rand.Chance(EffectiveAccuracy + EffectiveAccuracy * target.MarkBuff()))
                { 
                    if (!Gun.IgnoreDodge && target.TryDodge())
                    {
                        WriteLine($"Самолет №{target.Id} увернулся");
                        return 0;
                    }
                    Double finalyDamage = CalculateDamage(target);
                    WriteLine($"Самолет №{Id} попал с уроном {finalyDamage} по самолету №{target.Id}");
                    return finalyDamage;
                }
                WriteLine($"Самолет №{Id} промах");
                return 0;
            }
            WriteLine($"Самолет №{Id} - боекомлект пуст");
            return 0;

        }
    }
}
