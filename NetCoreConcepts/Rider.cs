﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreConcepts
{
    public class Rider
    {
        public int Id { get; set; }
        public EquineBeast Mount { get; set; }
    }

    public enum EquineBeast
    {
        Donkey,
        Mule,
        Horse,
        Unicorn
    }
}
