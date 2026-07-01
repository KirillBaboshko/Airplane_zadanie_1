using Airplane_zadanie_1.Airplanes;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    public enum TypeOfAmmunitions
    {
        Tracers,
        Piercing,
        Explosive,
        Rocet
    }
    public abstract class Ammunitions
    {
        public abstract TypeOfAmmunitions Type {  get; }
        public abstract Double Damage { get; }
        public abstract Double Weight { get; }
        public virtual void SpecialEffects(Airplane target) { }
    }
}
