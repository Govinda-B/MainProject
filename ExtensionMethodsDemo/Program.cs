using System;
//using ExtensionMethods2;
namespace ExtensionMethodsDemo
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string s = "Hello Extension Methods";
            int i = s.WordCount();
            Console.WriteLine("Length of string is {0}",i);
            var strout = s.SentanceSplit();
            foreach (var item in strout)
            {
                Console.WriteLine(item);
            }

            DomainEntity domainEntity = new DomainEntity 
            { FirstName = "govinda", Id = 1, LastName = "Boob" };
            Console.WriteLine(domainEntity.FullName());
        }
    }
}
