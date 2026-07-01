using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Teams;


namespace Airplane_zadanie_1.Strategy
{
    public class LeaderHuntStrategy : ITargetingStrategy
    {
        public string Name => "Охота на лидера";

        public Airplane SelectTarget(Airplane attacker, IReadOnlyList<Airplane> enemies, Squadron ownSquadron)
            => enemies.MaxBy(enemy => enemy.HP)!;
    }
}
