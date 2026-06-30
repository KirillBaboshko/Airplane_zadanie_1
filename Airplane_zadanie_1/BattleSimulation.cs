using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Teams;
using static System.Console;


namespace Airplane_zadanie_1
{
    //Здесь будет код симуляции битвы между командами
    public sealed class BattleSimulation
    {
        private const Int32 MaxRounds = 1000;

        private readonly List<Squadron> _squadrons;

        public BattleSimulation(IEnumerable<Squadron> squadrons)
        {
            _squadrons = squadrons.ToList();
        }

        public void Run()
        {
            PrintRoster();

            Int32 round = 0;
            while (AliveSquadrons().Count > 1 && round < MaxRounds)
            {
                round++;
                WriteLine($"Раунд {round}");
                StartRound();
                ExecuteRound();
                Thread.Sleep(2500);
            }

            Announce(round);
        }

        private List<Squadron> AliveSquadrons() => _squadrons.Where(s => s.IsAlive).ToList();

        private List<Airplane> EnemiesOf(Squadron squadron)
            => _squadrons.Where(s => s != squadron)
                         .SelectMany(s => s.AliveMembers)
                         .ToList();

        
        private void StartRound()
        {

            foreach (Squadron squadron in AliveSquadrons())
            {
                List<Airplane> enemies = EnemiesOf(squadron);
                if (enemies.Count > 0)
                    squadron.CommanderTarget = Rand.Pick(enemies);
                else
                    squadron.CommanderTarget = null;
            }
        }
        private void ExecuteRound()
        {
            List<Airplane> order = _squadrons.SelectMany(s => s.AliveMembers).ToList();

            foreach (Airplane attacker in order)
            {
                if (!attacker.IsAlive)
                {
                    continue;
                }

                if (attacker.IsStaned())
                {
                    WriteLine($"Самолет {attacker.Id} пропускает ход (двигатель заглушён).");
                    continue;
                }

                List<Airplane> enemies = EnemiesOf(attacker.Squadron);
                if (enemies.Count == 0)
                {
                    continue;
                }

                if (attacker.TrySpecialAttack(enemies))
                {
                    continue;
                }

                Airplane target = attacker.Squadron.Strategy.SelectTarget(attacker, enemies, attacker.Squadron);
                attacker.Attack(target);
            }
        }

        private void PrintRoster()
        {
            WriteLine("Состав эскадрилий");
            foreach (Squadron squadron in _squadrons)
            {
                WriteLine($"{squadron.Name} — тактика «{squadron.Strategy.Name}»:");
                foreach (Airplane plane in squadron.Members)
                {
                    WriteLine($"Самолет  №{plane.Id}");
                }
            }
        }

        private void Announce(int round)
        {
            List<Squadron> alive = AliveSquadrons();

            WriteLine("Бой окончен");
            if (alive.Count == 1)
            {
                WriteLine($"Победила эскадрилья «{alive[0].Name}» за {round} раунд(ов)!");
            }
            else
            {
                WriteLine($"Ничья по лимиту в {MaxRounds} раундов.");
            }
        }
    }
}
