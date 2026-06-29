using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Armors
{
    internal class ProtectedFuelTank : IArmor
    {
        public int id { get; } = 1;
        public double armor { get; } = 0.15;
    }
}
