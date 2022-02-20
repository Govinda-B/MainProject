using System;
using System.Collections;
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


            SortedList<string, string> openWith =
            new SortedList<string, string>();

            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            Console.WriteLine("For key = \"rtf\", value = {0}.",openWith["rtf"]);

            Dictionary<string, string> keyValuePairs =new Dictionary<string, string>();
            keyValuePairs.Add("a", "one");
            keyValuePairs.Add("b", "two");
            keyValuePairs.Add("c", "three");
            keyValuePairs.Add("d", "four");
            Console.WriteLine("For key = \"a\", value = {0}.", keyValuePairs["a"]);

            foreach (KeyValuePair<string, string> kvp in keyValuePairs)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }

            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(true);
            arrayList.Add("Hello");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }


            Hashtable hashtable = new Hashtable();

            // Add some elements to the hash table. There are no
            // duplicate keys, but some of the values are duplicates.
            hashtable.Add("txt", "notepad.exe");
            hashtable.Add("bmp", true);
            hashtable.Add("dib", 1);
            hashtable.Add("rtf", "wordpad.exe");
            Console.WriteLine(hashtable["txt"]);
        }
    }
}
