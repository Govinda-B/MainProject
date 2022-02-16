using System;

namespace OOPConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            Product cookie = new Product
            {
                Id = 1,
                Name = "Cookie",
                Quantity = 100,
                Price = 5
            };
            Product product1 = new Product
            {
                Id = 1,
                Name = "Cookie",
                Quantity = 100,
                Price = 5
            };
            Product product2 = new Product
            {
                Id = 2,
                Name = "Chocolate",
                Quantity = 100,
                Price = 15
            };
            Product product3 = new Product
            {
                Id = 3,
                Name = "Milk Chocolate",
                Quantity = 100,
                Price = 10
            };

            int Cost = product1.Buy(10);
            Console.WriteLine(Cost);
        }
    }
}
