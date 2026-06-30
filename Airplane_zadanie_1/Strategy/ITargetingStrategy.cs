using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Strategy
{
    public interface ITargetingStrategy
    {
        String Name { get; }
        Airplane SelectTarget(Airplane attacker, IReadOnlyList<Airplane> enemies, Squadron ownSquadron);
    }
}
