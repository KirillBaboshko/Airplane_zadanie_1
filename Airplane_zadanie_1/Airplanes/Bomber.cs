using Airplane_zadanie_1.Equipment.Armors;
using static System.Console;

namespace Airplane_zadanie_1.Airplanes
{
    public class Bomber : Airplane
    {
        private const double AreaBombChance = 0.10;
        private const double AreaBombDamage = 15;

        public Bomber() : base(hp: 680,weight:5000, baseDodgeChance: 0.05, baseAccuracy: 0.80, baseArmor:0.20) { }

        public override TypeOfPlanes Type => TypeOfPlanes.Bomber;

        public override void TrySpecialAttack(IReadOnlyList<Airplane> enemies)
        {
            if (Armor is SpacedArmor)
            {
                return;
            }

            if (!Rand.Chance(AreaBombChance))
            {
                return;
            }

            WriteLine($"Бомбардировщик №{Id} начал бомбардировку");

            foreach (Airplane enemy in enemies)
            {
                if (enemy.IsAlive)
                {
                    enemy.ChancheHP(AreaBombDamage);
                }
            }

            return;
        }
    }
}
