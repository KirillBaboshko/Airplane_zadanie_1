using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    internal class Tracers : IAmmunition
    {
        public int id { get; } = 1;
        public double damage { get; } = 12.0;

    }
}
