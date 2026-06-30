using Airplane_zadanie_1.Airplanes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    public class Tracers : Ammunitions
    {
        public override TypeOfAmmunitions Type => TypeOfAmmunitions.Tracers;
        public override Double Damage => 12.0;
        public override Double Weight =>75.0;
        public override void SpecialEffects(Airplane target)
        {
            target.Mark();
        }
    }
}
