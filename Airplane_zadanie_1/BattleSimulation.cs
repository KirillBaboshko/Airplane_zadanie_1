using Airplane_zadanie_1.Airplanes;
using Airplane_zadanie_1.Teams;
using System;
using System.Collections.Generic;
using System.Text;

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
                System.Console.WriteLine($"Раунд {round}");
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

        /// <summary>
        /// Один честный ход: фиксируем порядок до начала стрельбы, далее каждый
        /// живой самолёт действует один раз. Цели пересчитываются на лету,
        /// чтобы не бить по уже сбитым.
        /// </summary>
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
                    System.Console.WriteLine($"Самолет {attacker.Id} пропускает ход (двигатель заглушён).");
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
            System.Console.WriteLine("Состав эскадрилий");
            foreach (Squadron squadron in _squadrons)
            {
                System.Console.WriteLine($"{squadron.Name} — тактика «{squadron.Strategy.Name}»:");
                foreach (Airplane plane in squadron.Members)
                {
                    System.Console.WriteLine($"Самолет  №{plane.Id}");
                }
            }
        }

        private void Announce(int round)
        {
            List<Squadron> alive = AliveSquadrons();

            System.Console.WriteLine("Бой окончен");
            if (alive.Count == 1)
            {
                System.Console.WriteLine($"Победила эскадрилья «{alive[0].Name}» за {round} раунд(ов)!");
            }
            else
            {
                System.Console.WriteLine($"Ничья по лимиту в {MaxRounds} раундов.");
            }
        }
    }
}
