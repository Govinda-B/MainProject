using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = new List<string>();
            str.Add("anand");
            str.Add("amy");
            str.Add("amey");
            str.Add("sarvesh");
            str.Add("yash");
            str.Add("sachin");

            //LINQ query
            IEnumerable<string> outstr =from s in str
                                        where s[0] == 'a'
                                        orderby s
                                        select s;
            foreach (var item in outstr)
            {
                Console.WriteLine(item);
            }

            //Linq Query with lambda expression
            IEnumerable<string> str2 = str
                                        .Where(s => s[0] == 'a')
                                        .OrderBy(s=>s.Length)
                                        .ToList();
            foreach (var item in str2)
            {
                Console.WriteLine(item);
            }

            List<Book> books = new List<Book>();
            books.Add(new Book { id = 1, name = "Harry potter and socerer's stone", author = "JK Rowling" });
            books.Add(new Book { id = 2, name = "Harry potter and chamber of secret", author = "JK Rowling" });
            books.Add(new Book { id = 3, name = "Harry potter and prisoner of azkaban", author = "JK Rowling" });
            books.Add(new Book { id = 4, name = "Harry potter and Goblet of fire", author = "JK Rowling" });
            books.Add(new Book { id = 5, name = "Harry potter and order of the phoenix", author = "JK Rowling" });
            books.Add(new Book { id = 6, name = "Harry potter and half blood prince", author = "JK Rowling" });
            books.Add(new Book { id = 7, name = "Harry potter and deathly hallows", author = "JK Rowling" });

            IEnumerable<Book> names = books
                                        .Where(book => book.name.Contains("half"))
                                        .OrderBy(book => book.name)
                                        .ToList();

            foreach (var item in names)
            {
                Console.WriteLine(item.id+"\t\t"+item.name+ "\t\t" + item.author);
            }

            IEnumerable<string> name = from book in books
                                       where book.name.Contains("Harry")
                                       select book.name;
            foreach (var item in name)
            {
                Console.WriteLine(item);
            }
        }
    }
}
