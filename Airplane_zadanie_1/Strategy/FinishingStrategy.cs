using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Teams;

namespace Airplane_zadanie_1.Strategy
{
    public class FinishingStrategy : ITargetingStrategy
    {
        public string Name => "Добивание";

        public Airplane SelectTarget(Airplane attacker, IReadOnlyList<Airplane> enemies, Squadron ownSquadron)
            => enemies.MinBy(enemy => enemy.HP)!;
    }
}
