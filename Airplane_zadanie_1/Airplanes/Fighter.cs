using Airplane_zadanie_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Airplanes
{
   
    internal class Fighter: IAirplane
    {
        public int idOfType { get; } = 1;
        public double HP { get; set; } = 320.0;
        public IGun? gun { get; set; }
        public IArmor? armor { get; set; }
        public IAmmunition? ammunition { get; set; }
        public double accuracy { get; set; } = 0.5;
        public int idOfTeam { get; set; }
        public double dodgeChance { get; set; } = 0.25;
        public double Attack(IAirplane enemy)
        {
            Random rand = new Random();
            double sumaryDamage=rand.Next(gun.minDamadge,gun.maxDamadge)+ ammunition.damage;
            if(enemy.idOfType==3)
            {
                sumaryDamage += sumaryDamage * 0.20;
            }
            return sumaryDamage;
        }
        public void TakingDamage(double damage)
        {

        }
    }
}
