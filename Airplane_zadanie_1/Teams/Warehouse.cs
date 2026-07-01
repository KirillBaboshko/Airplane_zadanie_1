using Airplane_zadanie_1.Equipment.Ammunitions;
using Airplane_zadanie_1.Equipment.Armors;
using Airplane_zadanie_1.Equipment.Guns;


namespace Airplane_zadanie_1.Teams
{
    public class Warehouse
    {
        private readonly List<Func<Guns>> _guns = new()
        {
            () => new SynchronousMachineGuns(),
            () => new WingGuns(),
            () => new TurbineRockets(),
        };

        private readonly List<Func<Armors>> _armors = new()
        {
            () => new ProtectedFuelTank(),
            () => new ArmorPlate(),
            () => new SpacedArmor(),
        };

        private readonly List<Func<Ammunitions>> _ammunitions = new()
        {
            () => new Tracers(),
            () => new Piercing(),
            () => new Explosive(),
        };

        public Guns TakeRandomGun() => Rand.Pick(_guns)();

        public Armors TakeRandomArmor() => Rand.Pick(_armors)();

        public Ammunitions TakeRandomAmmunition(TypeOfGuns gunType) 
        {
            if (gunType == TypeOfGuns.TurbineRockets)
            {
                return new Rocet();
            }
            return Rand.Pick(_ammunitions)(); 
        }
    }
}
