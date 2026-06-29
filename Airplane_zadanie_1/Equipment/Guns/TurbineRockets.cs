using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Guns
{
    internal class TurbineRockets : IGun
    {
        public int id { get; } = 3;
        public int minDamadge { get; } = 35;
        public int maxDamadge { get; } = 40;
    }
}
