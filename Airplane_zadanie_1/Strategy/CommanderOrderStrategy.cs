using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Teams;


namespace Airplane_zadanie_1.Strategy
{
    public class CommanderOrderStrategy: ITargetingStrategy
    {
        public string Name => "Приказ командира";

        public Airplane SelectTarget(Airplane attacker, IReadOnlyList<Airplane> enemies, Squadron ownSquadron)
        {
            Airplane? order = ownSquadron.CommanderTarget;
            if (order is not null && order.IsAlive && enemies.Contains(order))
            {
                return order;
            }

            return Rand.Pick(enemies);
        }
    }
}
