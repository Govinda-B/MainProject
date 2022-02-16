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

            Laptop laptop1 = new Laptop
            { Id = 4, Name = "Macbook", Price = 99000, Quantity = 3, IsBacklightKeyboard = true, RAM = 8, Processor = "M1" };

            Laptop laptop2 = new Laptop
            { Id = 5, Name = "Macbook intel", Price = 119000, Quantity = 5, IsBacklightKeyboard = true, RAM = 8, Processor = "I5" };

            Laptop laptop3 = new Laptop
            { Id = 4, Name = "Macbook", Price = 99000, Quantity = 3, IsBacklightKeyboard = true, RAM = 8, Processor = "M1" };

            laptop1.Stock(3);
            int costoflaptop1 = laptop1.Buy(1);
            Console.WriteLine(costoflaptop1);
        }
    }
}
