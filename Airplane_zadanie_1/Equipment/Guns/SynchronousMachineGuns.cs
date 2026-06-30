using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Guns
{
    public class SynchronousMachineGuns:Guns
    {
        public override TypeOfGuns Type =>TypeOfGuns.SynchronousMachineGuns;
        public override Int32 MinDamage => 10;
        public override Int32 MaxDamage => 15;
        public Double AccuracyBuff => 0.15;
        public override Int32 ShotCount => 1;
    }
}
