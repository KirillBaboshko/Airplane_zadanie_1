

using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Equipment.Ammunitions;
using Airplane_zadanie_1.Infrastructure;
using static System.Console;

namespace Airplane_zadanie_1.Equipment.Guns
{
    public enum TypeOfGuns
    {
        SynchronousMachineGuns,
        TurbineRockets,
        WingGuns
    }
    public abstract class Guns
    {
        private int _cooldown;
        public abstract TypeOfGuns Type { get; }
        public abstract Int32 MinDamage {  get; }
        public abstract Int32 MaxDamage { get; }
        public abstract Double Weight { get; }
        public Double AccuracyBuff { get; }
        public virtual int Shots => 1;
        public Boolean IgnoreDodge => false;
        public virtual int ReloadTurns => 0;
        public bool IsReady => _cooldown <= 0;

        public void RegisterShot() => _cooldown = ReloadTurns + 1;
        public void Tick()
        {
            if (_cooldown > 0)
            {
                _cooldown--;
            }
        }
        public virtual Shot? Shot(Airplane shoter)
        {
            if (!IsReady)
            {
                WriteLine($"Самолет №{shoter.Id} - на перезарядке");
                return null;
            }
            Double damage = 0;
            for (int shot = 0; shot < Shots; shot++)
            {
                damage += Rand.DamageRange(MinDamage, MaxDamage);
                damage += shoter.Ammunition.Damage;
            }
            damage*=shoter.DamageMultiplierAgainst();
            RegisterShot();
            WriteLine($"Самолет №{shoter.Id} - произвел выстрел");
            return new Shot(shoter,damage);
            
        }
    }
}
