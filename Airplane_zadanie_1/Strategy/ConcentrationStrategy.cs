using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Strategy
{
    public class ConcentrationStrategy: ITargetingStrategy
    {
        private Airplane? _current;

        public string Name => "Концентрация";

        public Airplane SelectTarget(Airplane attacker, IReadOnlyList<Airplane> enemies, Squadron ownSquadron)
        {
            if (_current is null || !_current.IsAlive || !enemies.Contains(_current))
            {
                _current = Rand.Pick(enemies);
            }

            return _current;
        }
    }
}
