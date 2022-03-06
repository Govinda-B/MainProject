using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class NumberClass
    {
        public static void Addition(int number1, int number2)
        {
            int addition = number1 + number2;
            Console.WriteLine("The addition is : " + addition);
        }

        public static void Substraction(int number1, int number2)
        {
            int substraction = number1 - number2;
            Console.WriteLine("The substraction is : " + substraction);
        }

        public static void Multiplication(int number1, int number2)
        {
            int multiplication = number1 * number2;
            Console.WriteLine("The multiplication is : " + multiplication);
        }

        public static void Division(int number1, int number2)
        {
            int division = number1 / number2;
            Console.WriteLine("The Division is : " + division);
        }
    }
}
