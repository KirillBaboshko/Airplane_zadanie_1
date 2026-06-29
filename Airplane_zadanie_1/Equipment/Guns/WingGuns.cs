using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Guns
{
    internal class WingGuns : IGun
    {
        public int id { get; } = 2;
        public int minDamadge { get; } = 20;
        public int maxDamadge { get; } = 30;
    }
}
