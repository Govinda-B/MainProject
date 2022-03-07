using System;

namespace Delegates
{
    class Program
    {
        public delegate void Del(string message);
        public delegate void NumberDelegate(int number1,int number2);

        static void Main(string[] args)
        {
            NumberDelegate numberDelegate = Addition;
            numberDelegate += Substraction;
            numberDelegate += Multiplication;
            numberDelegate += Division;

            numberDelegate(55, 3);

            Del handler = DelegateMethod;
            handler("Hello World");
            MethodWithCallback(1, 2, handler);

            NumberDelegate NewDel = NumberClass.Addition;
            NewDel += NumberClass.Substraction;
            NewDel += NumberClass.Multiplication;
            NewDel += NumberClass.Division;
            NewDel -= NumberClass.Addition;
            NewDel(10, 2);

            //Func Delegate
            Func<int, int, int> Sum = (x, y) => x + y;
            Console.WriteLine(Sum(5,6));

            Func<int> GetRandomNumber = () => new Random().Next(100, 999);
            Console.WriteLine(GetRandomNumber());

            Action<string> Line = (data) => Console.WriteLine(data);
            Line("Hello");

            Del DelWrite = name => Console.WriteLine(name);

            DelWrite("govinda");

        }

        static void Addition(int number1, int number2)
        {
            int addition = number1 + number2;
            Console.WriteLine("The addition is : "+addition);
        }

        static void Substraction(int number1, int number2)
        {
            int substraction = number1 - number2;
            Console.WriteLine("The substraction is : " + substraction);
        }

        static void Multiplication(int number1, int number2)
        {
            int multiplication = number1 * number2;
            Console.WriteLine("The multiplication is : " + multiplication);
        }

        static void Division(int number1, int number2)
        {
            int division = number1 / number2;
            Console.WriteLine("The Division is : " + division);
        }

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }
    }
}
