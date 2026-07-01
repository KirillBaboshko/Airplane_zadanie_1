


namespace Airplane_zadanie_1.Equipment.Guns
{
    public class SynchronousMachineGuns:Guns
    {
        public override TypeOfGuns Type =>TypeOfGuns.SynchronousMachineGuns;
        public override Int32 MinDamage => 10;
        public override Int32 MaxDamage => 15;
        public override Double Weight => 100.0;
        public Double AccuracyBuff => 0.15;
    }
}
