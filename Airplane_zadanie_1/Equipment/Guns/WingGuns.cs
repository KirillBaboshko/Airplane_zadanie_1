using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Guns
{
    public class WingGuns : Guns
    {
        public override TypeOfGuns Type => TypeOfGuns.WingGuns;
        public override Int32 MinDamage => 20;
        public override Int32 MaxDamage => 30;
        public override Int32 ShotCount => 2;
        public Double AccuracyBuff => -0.10;
    }
}
