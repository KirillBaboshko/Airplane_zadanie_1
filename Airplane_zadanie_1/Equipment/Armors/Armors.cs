using Airplane_zadanie_1.Equipment.Guns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Armors
{
    public enum TypeOfArmors
    {
        ArmorPlate,
        ProtectedFuelTank,
        SpacedArmor
    }
    public abstract class Armors
    {
        public abstract TypeOfArmors Type { get; }
        public abstract Double Protection {  get; }
        public abstract Double Weight { get; }
        public Double DodgeBuff { get; }
    }
}
