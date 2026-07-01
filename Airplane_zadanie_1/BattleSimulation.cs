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
        private readonly PVO _PVO=new PVO(0.5);

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
                List<Airplane> order = _squadrons.SelectMany(s => s.AliveMembers).ToList();
                ExecuteRound(order);
                CalculatingLosses(order,round);
                //Thread.Sleep(2500);
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
        private void ExecuteRound(IReadOnlyList<Airplane> order)
        {

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
                if (Rand.Chance(_PVO.HitСhance))
                {
                    WriteLine($"ПВО отразило атаку самолета №{attacker.Id}");
                }
                else
                {
                    target.TakeDamage(attacker.Attack(target));
                }
                
            }
            
        }
        private void CalculatingLosses(IReadOnlyList<Airplane> order,Int32 round)
        {
            foreach (Airplane survivor in order)
            {
                if (survivor.Die())
                {
                    WriteLine($"Самолет №{survivor.Id} был сбит в раунде {round}");
                }
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
            if (round == MaxRounds)
            {
                WriteLine($"Ничья по лимиту в {MaxRounds} раундов.");
            }
            else
            {
                List<Squadron> alive = AliveSquadrons();

                WriteLine("Бой окончен");
                if (alive.Count == 1)
                {
                    WriteLine($"Победила эскадрилья «{alive[0].Name}» за {round} раунд(ов)!");
                }
                else
                {
                    WriteLine($"Ничья, победила дружба, все эскадрильи мертвы за {round} раунд(ов)!");
                }
            }
        }
    }
}
