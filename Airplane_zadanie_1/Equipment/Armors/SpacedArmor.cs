using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Armors
{
    internal class SpacedArmor : IArmor
    {
        public int id { get; } = 3;
        public double armor { get; } = 0.25;
    }
}
