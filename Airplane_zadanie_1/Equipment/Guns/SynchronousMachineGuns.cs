using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Guns
{
    internal class SynchronousMachineGuns:IGun
    {
        public int id { get; } = 1;
        public int minDamadge { get; } = 10;
        public int maxDamadge { get; } = 15;
    }
}
