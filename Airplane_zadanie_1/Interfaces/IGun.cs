using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Interfaces
{
    internal interface IGun
    {
        public int id { get;  }
        public int minDamadge {  get; }
        public int maxDamadge { get; }
    }
}
