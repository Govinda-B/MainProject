using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Parent2 : IParent2
    {
        public float FloatNumber { get; set; }
        public double Cube(double number)
        {
            return number * number * number;
        }


        public double Square(double number)
        {
            return number * number;
        }
    }
}
