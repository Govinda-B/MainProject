using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Child2 : IParent1, IParent2
    {
        public Parent1 Parent1Obj { get; set; }
        public Parent2 Parent2Obj { get; set; }
        public Child2()
        {

        }
        public Child2(Parent1 parent1, Parent2 parent2)
        {
            Parent1Obj = parent1;
            Parent2Obj = parent2;
        }
        public int Cube(int number)
        {
            return Parent1Obj.Cube(number);
        }

        public int Cube()
        {
            return Parent1Obj.Cube();
        }

        public double Cube(double number)
        {
            return Parent2Obj.Cube(number);
        }

        public int Square(int number)
        {
            return Parent1Obj.Square(number);
        }

        public int Square()
        {
            return Parent1Obj.Square();
        }

        public double Square(double number)
        {
            return Parent2Obj.Square(number);
        }
    }
}
