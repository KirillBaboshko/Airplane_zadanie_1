using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Airplanes
{
    internal class Bomber:Airplane
    {
        public int idOfType { get; } = 2;
        public double HP { get; set; } = 680.0;
        public IGun? gun { get; set; }
        public IArmor? armor { get; set; }
    
        public double accuracy { get; set; } = 0.8;
        public int idOfTeam { get; set; }
        public double dodgeChance { get; set; } = 0.05;
    }
}
