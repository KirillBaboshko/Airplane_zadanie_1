using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1;
using Airplane_zadanie_1.Equipment.Ammunitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Equipment.Guns
{
    public enum TypeOfGuns
    {
        SynchronousMachineGuns,
        TurbineRockets,
        WingGuns
    }
    public abstract class Guns
    {
        public abstract TypeOfGuns Type { get; }
        public abstract Int32 MinDamage {  get; }
        public abstract Int32 MaxDamage { get; }
        public Double AccuracyBuff { get; }
        public abstract Int32 ShotCount { get; }
        public Boolean IgnoreDodge => false;
        public Boolean isReloaded => false;
        public static Int32 ReloadCount { get; }
        public Int32 Reload=ReloadCount;
        public virtual Double Shot()
        {
            if (!isReloaded)
            {
                return Rand.DamageRange(MinDamage, MaxDamage) * ShotCount;
            }
            else
            {
                if (Reload != 0)
                {
                    Reload--;
                    return Rand.DamageRange(MinDamage, MaxDamage) * ShotCount;
                }
                else
                {
                    Reload = ReloadCount;
                    return 0;
                }
            }
        }
    }
}
