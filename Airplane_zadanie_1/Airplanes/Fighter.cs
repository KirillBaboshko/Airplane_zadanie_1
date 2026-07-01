
namespace Airplane_zadanie_1.Airplanes
{
   
    internal class Fighter : Airplane
    {
        public Fighter() : base(hp: 320, weight: 2500, baseDodgeChance: 0.25, baseAccuracy: 0.80, baseArmor: 0.10) { }

        public override TypeOfPlanes Type => TypeOfPlanes.Fighter;

        public override double DamageMultiplierAgainst()
            => Target.Type == TypeOfPlanes.Bomber ? 1.20 : 1.0;
    }
}
