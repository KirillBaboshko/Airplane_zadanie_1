using System;
using System.Collections.Generic;
using System.Text;

namespace Airplane_zadanie_1.Infrastructure
{
    public class PVO
    {
        public PVO(Double hitChance) 
        {
            HitСhance = hitChance;
        }
        public Double HitСhance { get; }
    }
}
