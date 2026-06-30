
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Armors
{
    public class ProtectedFuelTank : Armors
    {
        public override TypeOfArmors Type => TypeOfArmors.ProtectedFuelTank;
        public override Double Protection => 0.15;
    }
}
