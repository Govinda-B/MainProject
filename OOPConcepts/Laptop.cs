using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcepts
{
    public class Laptop:Product //Inherited Class
    {
        public int RAM { get; set; }
        public string Processor { get; set; }
        public bool IsBacklightKeyboard { get; set; }
    }
}
