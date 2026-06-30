using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Guns
{
    public class TurbineRockets : Guns
    {
        public override TypeOfGuns Type => TypeOfGuns.TurbineRockets;
        public override Int32 MinDamage => 35;
        public override Int32 MaxDamage => 40;
        public override Int32 ShotCount => 1;
        public Boolean IgnoreDodge => true;
        public Boolean isReloaded => true;
        public static Int32 ReloadCount => 1;
    }
}
