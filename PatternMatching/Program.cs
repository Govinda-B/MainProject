using System;
using System.Collections.Generic;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            int? maybe=null;

            if (maybe is int number)
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }

            string? message = "This is not the null string";

            if (message is not null)
            {
                Console.WriteLine(message);
            }

            int[] numberlist = { 1, 2,3,4,5,6,7,8,9};
            Console.WriteLine(StaticMethods.MidPoint(numberlist));
            Console.WriteLine(StaticMethods.MidPoint(new List<int>{ 1,2,3,4,5,6,7,8,9}));
            try
            {
                Console.WriteLine(StaticMethods.MidPoint(new List<int> { }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string WaterState(int tempInFahrenheit) =>
                tempInFahrenheit switch
                {
                    (> 32) and (< 212) => "liquid",
                    < 32 => "solid",
                    > 212 => "gas",
                    32 => "solid/liquid transition",
                    212 => "liquid / gas transition",
                };
            Console.WriteLine(WaterState(32));

            decimal CalculateDiscount(Order order) => order switch
            {
                (Items: > 10, Cost: > 1000.00m) => 0.10m,
                (Items: > 5, Cost: > 500.00m) => 0.05m,
                Order { Cost: > 250.00m } => 0.02m,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var someObject => 0m,
            };

            Order order = new Order(4, 1888);
            Console.WriteLine(CalculateDiscount(order));
        }
        
    }
}
