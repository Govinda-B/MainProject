using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
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
