using Airplane_zadanie_1.Airplanes;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    public enum TypeOfAmunitions
    {
        Tracers,
        Piercing,
        Explosive
    }
    public abstract class Amunitions
    {
        public abstract TypeOfAmunitions Type {  get; }
        public abstract Double Damage { get; }
        public virtual void SpecialEffects(Airplane target) { }
    }
}
