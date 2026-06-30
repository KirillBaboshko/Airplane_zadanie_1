using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    public class Piercing : Amunitions
    {
        public override TypeOfAmunitions Type => TypeOfAmunitions.Piercing;
        public override Double Damage => 10.0;
      
    }
}
