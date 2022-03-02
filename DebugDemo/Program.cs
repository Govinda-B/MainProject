using System;
using System.Collections.Generic;

namespace DebugDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = { 'f', 'r', 'e', 'd', ' ', 's', 'm', 'i', 't', 'h' };
            string name = "";
            int[] a = new int[10];
            for (int i = 0; i < letters.Length; i++)
            {
                name += letters[i];
                a[i] = i + 1;
                
            }
            Method.SendMessage(name, a[letters.Length-1]);

            //2nd Example
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            try
            {
                var smallest = Method.GetSmallests(numbers, -4);
                foreach (int number in smallest)
                {
                    Console.WriteLine(number);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            

            Console.ReadKey(); 
        }

        
    }
}
