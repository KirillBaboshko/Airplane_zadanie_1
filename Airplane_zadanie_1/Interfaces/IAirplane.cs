using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Interfaces
{
    internal interface IAirplane
    {
        public int idOfType { get; }
        public double HP { get; set; }
        public IGun gun { get; set; }
        public IArmor armor { get; set; }
        public IAmmunition ammunition { get; set; }
        public double accuracy { get; set; }
        public int idOfTeam { get; set; }
        public double dodgeChance { get; set; }
        public double Attack()
        {
            Random rand = new Random();
            return rand.Next(gun.minDamadge, gun.maxDamadge) + ammunition.damage;
        }
        public void TakingDamage(double damage)
        {
            this.HP-=damage;
        }
    }
}
