using System;
using System.Collections.Generic;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> students = new List<string>();
            students.Add("Anand");
            students.Add("Pranav");
            students.Add("Pankaj");
            students.Add("Chetan");
            students.Remove("Pranav");
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Queue<string> names = new Queue<string>();
            names.Enqueue("Anand");
            names.Enqueue("Pranav");
            Console.WriteLine(names.Dequeue());
            Console.WriteLine(names.Dequeue());

            Stack<string> name = new Stack<string>();
            name.Push("Anand");
            name.Push("Pranav");

            Console.WriteLine();
            Console.WriteLine(name.Pop());
            Console.WriteLine(name.Pop());

        }
    }
}
