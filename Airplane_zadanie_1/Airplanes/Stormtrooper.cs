using static System.Console;

namespace Airplane_zadanie_1.Airplanes
{
    public class Stormtrooper : Airplane
    {
        private Boolean _cockpitUsed;

        public Stormtrooper() : base(hp: 480, weight: 3500, baseDodgeChance: 0.10, baseAccuracy: 0.80, baseArmor: 0.15) { }

        public override TypeOfPlanes Type => TypeOfPlanes.Stormtrooper;

        protected override Boolean TryAbsorbHit()
        {
            if (_cockpitUsed)
            {
                return false;
            }

            _cockpitUsed = true;
            WriteLine($"Самолет №{Id} держит удар бронированной кабиной (первый урон поглощён).");
            return true;
        }
    }
}
