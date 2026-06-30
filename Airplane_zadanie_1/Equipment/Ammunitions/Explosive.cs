using Airplane_zadanie_1.Airplanes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    public class Explosive: Ammunitions
    {
        public override TypeOfAmmunitions Type => TypeOfAmmunitions.Explosive;
        public override Double Damage => 18.0;
        public override Double Weight => 100.0;
        public override void SpecialEffects(Airplane target) 
        {
            target.Stan();
        }
    }
}
