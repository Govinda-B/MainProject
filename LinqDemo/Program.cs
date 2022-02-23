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
            IEnumerable<string> outstr = from s in str
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
                                        .OrderBy(s => s.Length)
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
            books.Add(new Book { id = 8, name = "A Clash of kings", author = "GRRMartin" });
            books.Add(new Book { id = 9, name = "A game of thrones", author = "GRRMartin" });

            IEnumerable<Book> names = books
                                        .Where(book => book.name.Contains("half"))
                                        .OrderBy(book => book.name)
                                        .ToList();

            //Group Query Result
            Console.WriteLine("Group Query Result");
            var groupByAuthorQuery =
                    from book in books
                    group book by book.author into newGroup
                    orderby newGroup.Key
                    select newGroup;
            foreach (var nameGroup in groupByAuthorQuery)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var book in nameGroup)
                {
                    Console.WriteLine($"\t{book.author}, {book.name}");
                }
            }


            //Lookup
            ILookup<char, string> lookup =
                                        books
                                        .ToLookup(p => p.name[0],
                                        p => p.name + " " + p.author);

            foreach (IGrouping<char, string> item in lookup)
            {
                Console.WriteLine(item.Key);
                foreach (string member in item)
                {
                    Console.WriteLine(member);
                }
            }

            foreach (var item in names)
            {
                Console.WriteLine(item.id + "\t\t" + item.name + "\t\t" + item.author);
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

            var students = Student.students;
            Console.WriteLine("Group By value");
            Console.WriteLine();
            var groupByFirstLetterQuery =
                from student in students
                group student by student.LastName[0];

            foreach (var studentGroup in groupByFirstLetterQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                // Nested foreach is required to access group items.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }


            int GetPercentile(Student s)
            {
                double avg = s.ExamScores.Average();
                return avg > 0 ? (int)avg / 10 : 0;
            }

            Console.WriteLine("Group By Range");
            Console.WriteLine();
            var groupByPercentileQuery =
                from student in students
                let percentile = GetPercentile(student)
                group new
                {
                    student.FirstName,
                    student.LastName
                } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;

            // Nested foreach required to iterate over groups and group items.
            foreach (var studentGroup in groupByPercentileQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key * 10}");
                foreach (var item in studentGroup)
                {
                    Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
                }
            }


            Console.WriteLine("\n\n\nGroup By comparison ");
            var groupByHighAverageQuery =
            from student in students
            group new
            {
                student.FirstName,
                student.LastName
            } by student.ExamScores.Average() > 75 into studentGroup
            select studentGroup;

            foreach (var studentGroup in groupByHighAverageQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.FirstName} {student.LastName}");
                }
            }


            Console.WriteLine("\n\n\nNested Group Query");
            var nestedGroupsQuery =
            from student in students
            group student by student.Year into newGroup1
            from newGroup2 in (
            from student in newGroup1
            group student by student.LastName
            )
            group newGroup2 by newGroup1.Key;

            // Three nested foreach loops are required to iterate
            // over all elements of a grouped group. Hover the mouse
            // cursor over the iteration variables to see their actual type.
            foreach (var outerGroup in nestedGroupsQuery)
            {
                Console.WriteLine($"DataClass.Student Level = {outerGroup.Key}");
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine($"\tNames that begin with: {innerGroup.Key}");
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine($"\t\t{innerGroupElement.LastName} {innerGroupElement.FirstName}");
                    }
                }
            }

            Console.WriteLine("\n\n\nGroup Query with subQuery");
            var queryGroupMax =
            from student in students
            group student by student.Year into studentGroup
            select new
            {
                Level = studentGroup.Key,
                HighestScore = (
                    from student2 in studentGroup
                    select student2.ExamScores.Average()
                ).Max()
            };

            int count = queryGroupMax.Count();
            Console.WriteLine($"Number of groups = {count}");

            foreach (var item in queryGroupMax)
            {
                Console.WriteLine($"  {item.Level} Highest Score={item.HighestScore}");
            }


            Console.WriteLine("\n\n\n\n\nDynamically specify predicate filters at run time");
            int[] ids = { 111, 114, 112 };

            var queryNames =
                from student in students
                where ids.Contains(student.ID)
                select new
                {
                    student.LastName,
                    student.ID
                };

            foreach (var student in queryNames)
            {
                Console.WriteLine($"{student.LastName}: {student.ID}");
            }
            Console.WriteLine("\n\nChanging inputs");
            ids = new[] { 122, 117, 120, 115 };
            foreach (var student in queryNames)
            {
                Console.WriteLine($"{student.LastName}: {student.ID}");
            }

            Console.WriteLine("\n\n\n\nUsing different queries at runtime");
            FilterByYearType(true);
            Console.WriteLine("\n With different input");
            FilterByYearType(false);


        }


        static void FilterByYearType(bool oddYear)
        {
            var students = Student.students;
            IEnumerable<Student> studentQuery;
            if (oddYear)
            {
                studentQuery =
                    from student in students
                    where student.Year == GradeLevel.FirstYear || student.Year == GradeLevel.ThirdYear
                    select student;
            }
            else
            {
                studentQuery =
                    from student in students
                    where student.Year == GradeLevel.SecondYear || student.Year == GradeLevel.FourthYear
                    select student;
            }

            string descr = oddYear ? "odd" : "even";
            Console.WriteLine($"The following students are at an {descr} year level:");
            foreach (Student name in studentQuery)
            {
                Console.WriteLine($"{name.LastName}: {name.ID}");
            }

        }
    }
}
