using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    internal class Explosive:IAmmunition
    {
        public int id { get; } = 3;
        public double damage { get; } = 18.0;

    }
}
