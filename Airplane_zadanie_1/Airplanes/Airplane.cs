using Airplane_zadanie_1.Equipment.Ammunitions;
using Airplane_zadanie_1.Equipment.Armors;
using Airplane_zadanie_1.Equipment.Guns;
using Airplane_zadanie_1.Infrastructure;
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
        public Airplane? Target { get; private set; }
        public Int32 Id { get; }
        public Double Weight=> _weight;
        public Double HP => _hp;
        public Double MaxHp { get; }
        public Double MaxWeight { get; }
        public Double BaseAccuracy {get;}
        public Double BaseArmor { get; }
        public Double BaseDodgeChance { get; }
        public Boolean IsAlive { get; set; } = true;
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
        public void Aim(IReadOnlyList<Airplane> enemies)
        {
            Target=Squadron.Strategy.SelectTarget(this, enemies,Squadron);
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
        public virtual Double DamageMultiplierAgainst(Airplane target) => 1.0;
        protected virtual Boolean TryAbsorbHit() => false;
        public virtual void TrySpecialAttack(IReadOnlyList<Airplane> enemies) { }
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
            damage-=(damage* EffectiveArmor);
            ChancheHP(-damage);
            WriteLine($"Самолет №{Id} после попадания осталось {HP} HP");
        }
        public virtual Shot? Attack()
        {
            if (Gun != null && IsAlive && CountAmmo > 0)
            {
                CountAmmo--;
                WriteLine($"Самолет №{Id} - произвел выстрел");
                return new Shot(this,Target,Gun,Ammunition);
            }
            WriteLine($"Самолет №{Id} - боекомлект пуст");
            return null;
        }
    }
}
