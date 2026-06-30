using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Ammunitions
{
    public class Explosive: Amunitions
    {
        public override TypeOfAmunitions Type => TypeOfAmunitions.Explosive;
        public override Double Damage => 18.0;
        public override void SpecialEffects(Airplane target) 
        {
            target.Stan();
        }
    }
}
