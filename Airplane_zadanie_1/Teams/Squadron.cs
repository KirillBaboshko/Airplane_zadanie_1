using Airplane_zadanie_1.Airplanes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Teams
{
    public class Squadron
    {
        private readonly List<Airplane> _members = new();

        public Squadron(string name, ITargetingStrategy strategy)
        {
            Name = name;
            Strategy = strategy;
        }

        public string Name { get; }
        public ITargetingStrategy Strategy { get; }

        public IReadOnlyList<Airplane> Members => _members;
        public IReadOnlyList<Airplane> AliveMembers => _members.Where(m => m.IsAlive).ToList();
        public bool IsAlive => _members.Any(m => m.IsAlive);
        public Airplane? CommanderTarget { get; set; }

        public void Add(Airplane airplane)
        {
            airplane.Squadron = this;
            _members.Add(airplane);
        }
    }
}
