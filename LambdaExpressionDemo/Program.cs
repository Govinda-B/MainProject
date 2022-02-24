using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpressionDemo
{
    class Program
    {
        public delegate TResult Func<in T, out TResult>(T arg);
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));

            System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
            Console.WriteLine(e);

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));

            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("Anand");

            //Input parameters of a lambda expression
            Action line = () => Console.WriteLine();
            line();
            Func<double, double> cube = x => x * x * x;
            Console.WriteLine(cube(3.3));

            Func<int, int, bool> testForEquality = (x, y) => x == y;
            Console.WriteLine(testForEquality(5,6));

            line();

            Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
            Console.WriteLine(isTooLong(8,"govindadinseh"));

            Func<int, int, int> constant = (_, _) => 42;
            Console.WriteLine(constant(4,5));

            //Lambda expressions and tuples
            Func<(int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);
            var numbers3 = (2, 3, 4);
            var doubledNumbers = doubleThem(numbers3);
            Console.WriteLine($"The set {numbers3} doubled: {doubledNumbers}");

            Func<(int n1, int n2, int n3), (int, int, int)> doubleNumbers = ns => (2 * ns.n1, 2 * ns.n2, 2 * ns.n3);
            var doubledNumbers2 = doubleNumbers(numbers3);
            Console.WriteLine($"The set {numbers3} doubled: {doubledNumbers2}");

            //Lambdas with the standard query operators
            Console.WriteLine("\n\nLambdas with the standard query operators");
            Func<int, bool> equalsFive = x => x == 5;
            bool result = equalsFive(4);
            Console.WriteLine(result);

            int[] numbers4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbers2 = numbers4.Count(n => n % 2 == 1);
            Console.WriteLine($"There are {oddNumbers2} odd numbers in {string.Join(" ", numbers4)}");

            var firstNumbersLessThanSix = numbers.TakeWhile(n => n < 6);
            Console.WriteLine(string.Join(" ", firstNumbersLessThanSix));


            //don't use lambda expressions directly in query expressions, 
            //but you can use them in method calls within query expressions
            var numberSets2 = new List<int[]>
            {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 0, 0, 0 },
                new[] { 9, 8 },
                new[] { 1, 0, 1, 0, 1, 0, 1, 0 }
            };

            var setsWithManyPositives2 =
                from numberSet in numberSets2
                where numberSet.Count(n => n > 0) > 3
                select numberSet;

            foreach (var numberSet in setsWithManyPositives2)
            {
                Console.WriteLine(string.Join(" ", numberSet));
            }




            //Capture of outer variables and variable scope in lambda expressions
            Console.WriteLine("\n\n\n\nCapture of outer variables and variable scope in lambda expressions");
            var game = new VariableCaptureGame();

            int gameInput = 5;
            game.Run(gameInput);

            int jTry = 10;
            bool result2 = game.isEqualToCapturedLocalVariable(jTry);
            Console.WriteLine($"Captured local variable is equal to {jTry}: {result2}");

            int anotherJ = 3;
            game.updateCapturedLocalVariable(anotherJ);

            bool equalToAnother = game.isEqualToCapturedLocalVariable(anotherJ);
            Console.WriteLine($"Another lambda observes a new value of captured variable: {equalToAnother}");



            Console.WriteLine("\n\n\n");
            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddNumbers = numbers.Count(n => n % 2 == 1);


            Console.WriteLine($"There are {oddNumbers} odd numbers in {string.Join(" ", numbers)}");

            List<Book> books = new List<Book>();

            books.Add(new Book { id = 1, name = "Harry Potter", author = "JK Rowling" });
            books.Add(new Book { id = 2, name = "Superman", author = "Random" });
            books.Add(new Book { id = 3, name = "Batman", author = "Random" });
            books.Add(new Book { id = 4, name = "Bugs Bunny", author = "Random" });
            books.Add(new Book { id = 5, name = "Mickey mouse", author = "Random" });
            books.Add(new Book { id = 6, name = "Narnia", author = "WB" });
            books.Add(new Book { id = 7, name = "Naruto", author = "Kishimoto" });

            IEnumerable<string> book = books
                                        .Where(bookentity => bookentity.author == "Random")
                                        .Select(bookentity => bookentity.name)
                                        .ToList();
            foreach (var item in book)
            {
                Console.WriteLine(item);
            }

            var numberSets = new List<int[]>
            {
                new[] { 1, 2, 3, 4, 5 },
                new[] { 0, 0, 0 },
                new[] { 9, 8 },
                new[] { 1, 0, 1, 0, 1, 0, 1, 0 }
            };

            var setsWithManyPositives =
                from numberSet in numberSets
                where numberSet.Count(n => n > 0) > 3
                select numberSet;

            foreach (var numberSet in setsWithManyPositives)
            {
                Console.WriteLine(string.Join(" ", numberSet));
            }

        }
    }
}
