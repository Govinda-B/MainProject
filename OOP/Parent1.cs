using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Parent1 : IParent1
    {
        public int number { get; set; }
        public Parent1()
        {

        }
        public Parent1(int number)
        {
            this.number = number;
        }
        public int Cube(int number)
        {
            return number * number;
        }

        public int Square(int number)
        {
            return number * number * number;
        }

        public int Square()
        {
            return number * number;
        }

        public int Cube()
        {
            return number * number * number;
        }
    }
}
