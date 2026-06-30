using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Teams
{
    public class SquadronFactory
    {
        private readonly Warehouse _warehouse;

        public SquadronFactory(Warehouse warehouse) => _warehouse = warehouse;
        public Airplane CreateAirplane(Func<Airplane> create)
        {
            Airplane airplane = create();

            airplane.MontageGun(_warehouse.TakeRandomGun());
            airplane.MontageArmor(_warehouse.TakeRandomArmor());
            airplane.MontageAmmunition(_warehouse.TakeRandomAmmunition());

            return airplane;
        }
        public Squadron CreateSquadron(String name, ITargetingStrategy strategy, params Func<Airplane>[] composition)
        {
            Squadron squadron = new(name, strategy);

            foreach (Func<Airplane> create in composition)
            {
                squadron.Add(CreateAirplane(create));
            }

            return squadron;
        }
    }
}
