using Airplane_zadanie_1.Airplanes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    public class Rocet : Ammunitions
    {
        public override TypeOfAmmunitions Type => TypeOfAmmunitions.Rocet;
        public override Double Damage => 75.0;
        public override Double Weight => 100.0;
    }
}
