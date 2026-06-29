using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    internal class Piercing : IAmmunition
    {
        public int id { get; } = 2;
        public double damage { get; } = 10.0;

    }
}
