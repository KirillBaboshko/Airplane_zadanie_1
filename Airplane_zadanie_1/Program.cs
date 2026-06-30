using Airplane_zadanie_1;
using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Strategy;
using Airplane_zadanie_1.Teams;

Warehouse warehouse = new();
SquadronFactory factory = new(warehouse);

// Каждая эскадрилья получает свою тактику и состав самолётов.
// Чтобы устроить бой 3, 4 и более эскадрилий нужно просто добавлять новые команды в этот список
List<Squadron> squadrons = new()
{
    factory.CreateSquadron(
        "Люфтваффе",
        new CommanderOrderStrategy(),
        () => new Fighter(), () => new Fighter(), () => new Stormtrooper(), () => new Bomber()),

    factory.CreateSquadron(
        "ВВС СССР",
        new ConcentrationStrategy(),
        () => new Fighter(), () => new Stormtrooper(), () => new Stormtrooper(), () => new Bomber()),

    factory.CreateSquadron(
        "USAF",
        new TypePriorityStrategy(),
        () => new Fighter(), () => new Fighter(), () => new Bomber(), () => new Bomber()),
};

BattleSimulation battle = new(squadrons);
battle.Run();