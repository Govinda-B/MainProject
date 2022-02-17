using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace OOP
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle()
        {
<<<<<<<<< Temporary merge branch 1
=========

>>>>>>>>> Temporary merge branch 2
        }
        public double Area(double radius)
        {
            return PI * radius * radius;
        }

        public override double Area()
        {
            return PI * Radius * Radius;
        }
    }
}
