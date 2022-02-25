using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();
            double area = Circle.Area(22);
            Console.WriteLine(area);

            //Multiple Inheritance
            Child child = new Child(2,2.5f);
            Console.WriteLine(child.Cube(3));
            
            Console.WriteLine(child.Cube());

            Console.WriteLine(child.Cube(3.3));


            Parent1 parent1 = new Parent1();
            Parent2 parent2 = new Parent2();
            Child2 child2 = new Child2(parent1,parent2);

            Console.WriteLine(child2.Cube(2));
            Console.WriteLine(child2.Cube(1.6f));
            Console.WriteLine(child2.Cube());
        }
    }
}
