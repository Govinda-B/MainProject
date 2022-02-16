using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();
            double area = c1.Area(22);
            Console.WriteLine(area);
        }
    }
}
