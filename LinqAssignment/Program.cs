﻿    using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = Category.GetCategories();
            List<Product> products = Product.GetProducts();
            // 1) Display average price of product of a specific category and also average price of all products
            // Average price of dairy product by id
            Console.WriteLine("Average price of dairy product by id");
            int id = 1;
            double averagePriceofDairyProductsbyId = products
                                                    .Where(product => product.CategoryId.Equals(id))
                                                    .Average(product => product.Price);
            Console.WriteLine($"Average price of all product in dairy category is {averagePriceofDairyProductsbyId}");

            string name = "Dairy";
            // Average price of dairy product by category name
            Console.WriteLine("Average price of dairy product by category name");
            double averagePriceofDairyProducts = products
                                                .Where(product => product.CategoryId.Equals(categories.Where(category => category.Name.Equals(name)).Single().Id))
                                                .Average(product => product.Price);
            Console.WriteLine($"Average price of all product in dairy category is {averagePriceofDairyProducts}");

            // Average Price of all products
            Console.WriteLine("\nAverage Price of all products");
            double averagePriceofAllProducts = products.Average(product => product.Price);
            Console.WriteLine($"Average price of all product is {averagePriceofAllProducts}");

            // 2) Display total quantity of products (both category wise and all products).
            // Total Quantity of all products
            Console.WriteLine("Total Quantity of all products");
            int TotalQuantityfAllProducts = products.Sum(product => product.Quantity);
            Console.WriteLine($"Quantity of products in given category is {TotalQuantityfAllProducts}");

            //Total Quantity of products by category
            Console.WriteLine("\nTotal Quantity of products by category");
            int TotalQuantityfProductsByCategoryId = products
                                                .Where(product => product.CategoryId.Equals(id))
                                                .Sum(product => product.Quantity);
            Console.WriteLine($"Quantity of products in given category is {TotalQuantityfProductsByCategoryId}");

            // 3) Display costliest product details of a specific category.
            Console.WriteLine("\n Display costliest product details of a specific category.");
            double maxPrice = 
                                            products
                                            .Where(product => product.CategoryId.Equals(id))
                                            .Max(product => product.Price);


            IEnumerable<Product> costliestProductInCategory = products.Where(product => product.CategoryId.Equals(id) && product.Price.Equals(maxPrice))
                                                .ToList();

            foreach (Product item in costliestProductInCategory)
            {
                Console.WriteLine(item.Id + item.Name);
            }
            

            // 4) Display cheapest product details of a specific category.
            Console.WriteLine(" Display cheapest product details of a specific category.");
             double cheapestPrice = products
                                           .Where(product => product.CategoryId.Equals(id))
                                           .Min(product => product.Price);

             IEnumerable<Product> cheapestProductInCategory = products.Where(product => product.CategoryId.Equals(id) && product.Price.Equals(cheapestPrice))
                                                   .ToList();

            foreach (Product item in cheapestProductInCategory)
                {
                    Console.WriteLine(item.Name+"\t"+item.Price);
                }
            Console.WriteLine();
            // 5) Filter products which have crossed the Expiry date.
            List<Product> expiredProductList = products
                                        .Where(product => product.ExpiryDate.CompareTo(DateTime.Now) < 0 && !product.ExpiryDate.Equals(Convert.ToDateTime("01-01-0001")))
                                        .ToList();
            foreach (Product item in expiredProductList)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            // 6) Filter products which are expiring in next month.
            Console.WriteLine("Filter products which are expiring in next month.");
            try
            {
                DateTime dateTime = new DateTime();
                dateTime = DateTime.Today;
                dateTime.AddMonths(1);
                List<Product> expiryProductListInNextMonth = products
                                        .Where(product => product.ExpiryDate.CompareTo(dateTime) <= 0)
                                        .ToList();
                foreach (Product item in expiredProductList)
                {
                    Console.WriteLine(item.Name);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("No product is expiring in next month");
            }
            // 7) Find products by id, category, name.
            // Find Product by Category id
            Console.WriteLine("\nFind Product by Category id");
            try
            {
                List<Product> ProductsByCategoryId = products
                                               .Where(product => product.CategoryId.Equals(id))
                                               .ToList();
                Console.WriteLine();
                foreach (Product item in ProductsByCategoryId)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No product in given categoryId");
            }
            // Find Product by Category name
            Console.WriteLine("Find Product by Category name");
            var newName = "Fruit";
            try
            {
                List<Product> ProductsByCategoryName = products
                                                .Where(product => product.CategoryId.Equals(categories.Where(category => category.Name.Equals(newName)).Single().Id))
                                                .ToList();
                foreach (Product item in ProductsByCategoryName)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("No product in category");
            }
            

            //Find Product by name
            Console.WriteLine("Find Product by name\n");
            try
            {
                Product ProductsByName = products
                                                .Where(product => product.Name.Equals("Fruits"))
                                                .Single();
                Console.WriteLine(ProductsByName.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            // Find Product by id
            Console.WriteLine("Find Product by id");
            try
            {

                Product ProductById = products.Where(product => product.Id.Equals(id)).SingleOrDefault();
                Console.WriteLine(ProductById.Name+"\t"+ProductById.Price);
            }
            catch (Exception)
            {
                Console.WriteLine("Product not found");
            }

            // 8) Create 2 list of products and perform following operations
            List<Product> products1 = new List<Product>
            {
                new Product{ Id=1,Name="Milk",Description="Fresh Milk", ExpiryDate=Convert.ToDateTime("02-02-2022"),Price=20,Quantity=14,CategoryId=1},
                new Product{ Id=2,Name="Butter",Description="Fresh Butter", ExpiryDate=Convert.ToDateTime("04-02-2022"),Price=60,Quantity=14,CategoryId=1},
                new Product{ Id=3,Name="Curd",Description="Fresh Curd", ExpiryDate=Convert.ToDateTime("02-02-2022"),Price=50,Quantity=14,CategoryId=1},
                new Product{ Id=4,Name="Biscuits",Description="Glucose Biscuits", ExpiryDate=Convert.ToDateTime("02-02-2022"),Price=10,Quantity=614,CategoryId=2},
                new Product{ Id=5,Name="Cookies",Description="Sweet cookies", ExpiryDate=Convert.ToDateTime("22-02-2022"),Price=25,Quantity=214,CategoryId=2},
                new Product{ Id=6,Name="Chocolates",Description="Milk Chocolates", ExpiryDate=Convert.ToDateTime("12-02-2022"),Price=120,Quantity=311,CategoryId=2},
                new Product{ Id=7,Name="Soybean oil",Description="Refined oil", ExpiryDate=Convert.ToDateTime("02-03-2022"),Price=160,Quantity=314,CategoryId=3},
                new Product{ Id=8,Name="mustard oil",Description="Non-refined oil", ExpiryDate=Convert.ToDateTime("02-04-2022"),Price=220,Quantity=214,CategoryId=3},
                new Product{ Id=9,Name="olive oil",Description="Extra virgin oil", ExpiryDate=Convert.ToDateTime("02-05-2022"),Price=520,Quantity=64,CategoryId=3},
                new Product{ Id=10,Name="Mango",Description="Fresh Ratnagiri Mangoes",Price=200,Quantity=54,CategoryId=4}
            };

            List<Product> products2 = new List<Product>
            {
                new Product{ Id=3,Name="Curd",Description="Fresh Curd", ExpiryDate=Convert.ToDateTime("02-02-2022"),Price=50,Quantity=14,CategoryId=1},
                new Product{ Id=4,Name="Biscuits",Description="Glucose Biscuits", ExpiryDate=Convert.ToDateTime("02-02-2022"),Price=10,Quantity=614,CategoryId=2},
                new Product{ Id=9,Name="olive oil",Description="Extra virgin oil", ExpiryDate=Convert.ToDateTime("02-05-2022"),Price=520,Quantity=64,CategoryId=3},
                new Product{ Id=10,Name="Mango",Description="Fresh Ratnagiri Mangoes",Price=200,Quantity=54,CategoryId=4},
                new Product{ Id=11,Name="Apple",Description="Fresh kashmir Apples",Price=160,Quantity=24,CategoryId=4},
                new Product{ Id=12,Name="Orange",Description="Fresh Nagpur Oranges",Price=80,Quantity=34,CategoryId=4},
                new Product{ Id=13,Name="Wheat",Description="Wheat grains",Price=30,Quantity=314,CategoryId=5},
                new Product{ Id=14,Name="Rice",Description="Rice grain",Price=60,Quantity=114,CategoryId=5}
            };
            Console.WriteLine("\nDisplay common products");
            // 1) Display common products.
            HashSet<int> product2Ids = new HashSet<int>(products2.Select(p2 => p2.Id));
            IEnumerable<Product> commonProducts = products1
                                                    .Where(p1=> product2Ids.Contains(p1.Id)).ToList();
            foreach (var item in commonProducts)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            // 2) Display unique products from both lists.
            Console.WriteLine("\nDisplay unique products from both lists.");
            HashSet<int> product1Ids = new HashSet<int>(products1.Select(p1 => p1.Id));
            var distinctProductsInList1 = products1
                                                    .Where(p1 => !product2Ids.Contains(p1.Id)).ToList();
            var distinctProductsInList2 = products2
                                                    .Where(p2 => !product1Ids.Contains(p2.Id)).ToList();
            var distinctProducts = distinctProductsInList1.Union(distinctProductsInList2);

            foreach (var item in distinctProducts)
            {
                Console.WriteLine(item.Name);
            }

            // 3) Display products from list 1 which are not in list 2.
            Console.WriteLine("\nDisplay products from list 2 which are not in list 1.");
            Console.WriteLine();
            foreach (var item in distinctProductsInList2)
            {
                Console.WriteLine(item.Name);
            }
            // 4) Unique products from list 1.
            Console.WriteLine("Unique products from list 1.");
            Console.WriteLine();
            foreach (var item in distinctProductsInList1)
            {
                Console.WriteLine(item.Name);
            }

            // 9) Perform sorting operation on products on Price, Quantity, Expiry date,
            // Sort by price(Ascending)
            var sortProductByPrice = products
                                        .OrderBy(product => product.Price);
            Console.WriteLine("Sort by Price(Ascending)");
            foreach (Product item in sortProductByPrice)
            {
                Console.WriteLine(item.Price + "\t" + item.Name);
            }


            // Sort by price(Descending)
            var sortProductByPriceDesc = products
                                        .OrderByDescending(product => product.Price);
            Console.WriteLine("Sort by Price(Descending)");
            foreach (Product item in sortProductByPriceDesc)
            {
                Console.WriteLine(item.Price + "\t" + item.Name);
            }


            // Sort by quantity(Ascending)
            var sortProductByQuantity = products
                                        .OrderBy(product => product.Quantity)
                                        .ThenBy(product => product.Name);
            Console.WriteLine("Sort by Quantity(Ascending)");
            foreach (Product item in sortProductByQuantity)
            {
                Console.WriteLine(item.Quantity + "\t" + item.Name);
            }

            // Sort by Expiry Date(Ascending)
            IEnumerable<Product> sortProductByExpiryDate = products
                                        .OrderBy(product => product.ExpiryDate);
            Console.WriteLine("Sort by Expiry Date(Ascending)");
            foreach (Product item in sortProductByExpiryDate)
            {
                Console.WriteLine(item.ExpiryDate+"\t"+item.Name);
            }

            // 10) Make use of "Any", "All" and "Contains" on product list.
            Console.WriteLine("Any Product description has keyword 'Fresh'");
            bool anyDescriptionContainFresh = products.Any(product => product.Description.Contains("Fresh"));
            Console.WriteLine(anyDescriptionContainFresh);
            Console.WriteLine("All Product description has keyword 'Fresh'");
            bool allDescriptionContainFresh = products.All(product => product.Description.Contains("Fresh"));
            Console.WriteLine(allDescriptionContainFresh);

            // 11) Perform join of product and category and
            // display - Product name, Category Name, Product price and Product description.

            var joinProductCategory = products
                                    .Join(
                                    categories,
                                    product => product.CategoryId,
                                    category => category.Id,
                                    (product, category) => new
                                    {
                                        ProductName = product.Name,
                                        CategoryName = category.Name,
                                        ProductPrice = product.Price,
                                        ProductDescription = product.Description
                                    });
            Console.WriteLine("\njoin of product and category\n");
            foreach (var item in joinProductCategory)
            {
                Console.WriteLine(item);
            }


            //Sum of All product prices
            var TotalPriceofAllProducts = products.Sum(product => product.Price);

            //Product Sorted by Expiry Date
            var productSortedByExpiryDate = products.OrderBy(product => product.ExpiryDate);



            
            Console.WriteLine(averagePriceofDairyProducts);

        }

        double AveragePriceById(int i)
        {
            var products = Product.GetProducts();
            return products
                .Where(product => product.CategoryId.Equals(1))
                .Average(product => product.Price);
        }
    }
}
