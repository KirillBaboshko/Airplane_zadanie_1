using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Armors
{
    public class SpacedArmor : Armors
    {
        public override TypeOfArmors Type => TypeOfArmors.SpacedArmor;
        public override Double Protection => 0.25;
        public Double DodgeBuff => -0.10;
        public override Double Weight => 1000.0;
    }
}
