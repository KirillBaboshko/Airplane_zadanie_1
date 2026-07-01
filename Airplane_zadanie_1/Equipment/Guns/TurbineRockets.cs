

namespace Airplane_zadanie_1.Equipment.Guns
{
    public class TurbineRockets : Guns
    {
        public override TypeOfGuns Type => TypeOfGuns.TurbineRockets;
        public override Int32 MinDamage => 35;
        public override Int32 MaxDamage => 40;
        public Boolean IgnoreDodge => true;
        public Boolean isReloaded => true;
        public override int ReloadTurns => 1;
        public override Double Weight => 150.0;
    }
}
