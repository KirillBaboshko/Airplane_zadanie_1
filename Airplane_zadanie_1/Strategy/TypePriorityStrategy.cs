using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Teams;


namespace Airplane_zadanie_1.Strategy
{
    public class TypePriorityStrategy : ITargetingStrategy
    {
        private static readonly Dictionary<TypeOfPlanes, TypeOfPlanes?> Priority = new()
        {
            [TypeOfPlanes.Fighter] = TypeOfPlanes.Bomber,
            [TypeOfPlanes.Stormtrooper] = TypeOfPlanes.Fighter,
            [TypeOfPlanes.Bomber] = null,
        };

        public string Name => "По приоритету типов";

        public Airplane SelectTarget(Airplane attacker, IReadOnlyList<Airplane> enemies, Squadron ownSquadron)
        {
            TypeOfPlanes? preferred = Priority[attacker.Type];
            if (preferred is not null)
            {
                List<Airplane> matches = enemies.Where(e => e.Type == preferred).ToList();
                if (matches.Count > 0)
                {
                    return Rand.Pick(matches);
                }
            }

            return Rand.Pick(enemies);
        }
    }
}
