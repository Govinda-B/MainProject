using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Child:IParent1,IParent2
    {
        private Parent1 parent1 = new Parent1();
        private Parent2 parent2 = new Parent2();

        public Child()
        {
            
        }
        public Child(int number,float floatnumber)
        {
            this.parent1.number = number;
            this.parent2.FloatNumber = floatnumber;
        }

        public int Cube(int number)
        {
            return parent1.Cube(number);
        }

        public int Cube()
        {
            return parent1.Cube();
        }

        public double Cube(double number)
        {
            return parent2.Cube(number);
        }

        public int Square(int number)
        {
            return parent1.Square(number);
        }

        public int Square()
        {
            return parent1.Square(parent1.number);
        }

        public double Square(double number)
        {
            return parent2.Square(number);
        }
    }
}
