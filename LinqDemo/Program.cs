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
                                        .ToArray();
            foreach (var item in str2)
            {
                Console.WriteLine(item);
            }

            

            List<Book> books = new List<Book>();
            books.Add(new Book { id = 1, name = "Harry potter and socerer's stone", author = "JK Rowling" });
            books.Add(new Book { id = 2, name = "karry potter and chamber of secret", author = "JK Rowling" });
            books.Add(new Book { id = 3, name = "karry potter and prisoner of azkaban", author = "JK Rowling" });

            books.Add(new Book { id = 4, name = "barry potter and Goblet of fire", author = "JK Rowling" });
            books.Add(new Book { id = 5, name = "barry potter and order of the phoenix", author = "JK Rowling" });
            books.Add(new Book { id = 6, name = "Harry potter and half blood prince", author = "JK Rowling" });
            books.Add(new Book { id = 7, name = "Harry potter and deathly hallows", author = "JK Rowling" });

            IEnumerable<Book> names = books
                                        .Where(book => book.name.Contains("half"))
                                        .OrderBy(book => book.name)
                                        .ToList();


            //Lookup
            ILookup<char, string> lookup =
                                        books
                                        .ToLookup(p => p.name[0],
                                        p => p.name + " " + p.author);

            foreach (IGrouping<char, string> item in lookup)
            {
                Console.WriteLine(item.Key);
                foreach (string  member in item)
                {
                    Console.WriteLine(member);
                }
            }

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

            // Specify the data source.
            int[] scores = { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // QueryMethod1 returns a query as the value of the method.
            var myQuery1 = Queries.QueryMethod1(nums);

            // Query myQuery1 is executed in the following foreach loop.
            Console.WriteLine("Results of executing myQuery1:");
            // Rest the mouse pointer over myQuery1 to see its type.
            foreach (var s in myQuery1)
            {
                Console.WriteLine(s);
            }

            // You also can execute the query returned from QueryMethod1
            // directly, without using myQuery1.
            Console.WriteLine("\nResults of executing myQuery1 directly:");
            // Rest the mouse pointer over the call to QueryMethod1 to see its
            // return type.
            foreach (var s in Queries.QueryMethod1(nums))
            {
                Console.WriteLine(s);
            }

            // QueryMethod2 returns a query as the value of its out parameter.
            Queries.QueryMethod2(nums, out IEnumerable<string> myQuery2);

            // Execute the returned query.
            Console.WriteLine("\nResults of executing myQuery2:");
            foreach (var s in myQuery2)
            {
                Console.WriteLine(s);
            }

            // You can modify a query by using query composition. In this case, the
            // previous query object is used to create a new query object; this new object
            // will return different results than the original query object.
            myQuery1 =
                from item in myQuery1
                orderby item descending
                select item;

            // Execute the modified query.
            Console.WriteLine("\nResults of executing modified myQuery1:");
            foreach (var s in myQuery1)
            {
                Console.WriteLine(s);
            }
        }
    }
}
