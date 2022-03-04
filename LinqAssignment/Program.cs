using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            List<Category> categories = Category.GetCategories();
            List<Product> products = Product.GetProducts();
            // 1) Display average price of product of a specific category and also average price of all products
            // Average price of dairy product by id
            Console.WriteLine("Average price of dairy product by id");
            int id = 1;
            //Static Method
            double averagePriceofProductsbyId = AveragePriceById(id);
            Console.WriteLine($"Average price of all product in dairy category is {averagePriceofProductsbyId}");

            // Average price of dairy product by category name
            string name = "Dairy";
            Console.WriteLine("\nAverage price of dairy product by category name");
            //Static Method
            double averagePriceofProducts = AveragePriceofProducts(name,products,categories);
            Console.WriteLine($"Average price of all product in dairy category is {averagePriceofProducts}");

            // Average Price of all products
            Console.WriteLine("\nAverage Price of all products");
            //Static Method
            double averagePriceofAllProducts = AveragePriceofAllProducts(products);
            Console.WriteLine($"Average price of all product is {averagePriceofAllProducts}");

            // 2) Display total quantity of products (both category wise and all products).
            // Total Quantity of all products
            Console.WriteLine("\nTotal Quantity of all products");
            int totalQuantityfAllProducts = program.TotalQuantityfAllProducts(products);
            Console.WriteLine($"Quantity of all products in  is {totalQuantityfAllProducts}");

            // Total Quantity of product in list
            Console.WriteLine("\nTotal Quantity of product in list");
            int totalQuantityfAllProductsInList = program.TotalQuantityfAllProductsInList(products);
            Console.WriteLine($"Quantity of products in list is {totalQuantityfAllProductsInList}");

            //Total Quantity of products by category
            Console.WriteLine("\nTotal Quantity of products by category");
            int totalQuantityfProductsByCategoryId = program.TotalQuantityfProductsByCategoryId(products, id);
            Console.WriteLine($"Quantity of products in given category is {totalQuantityfProductsByCategoryId}");

            //Total Quantity of products in list by category
            Console.WriteLine("\nTotal Quantity of products in list by category");
            int totalQuantityfProductsInListByCategoryId = program.TotalQuantityfProductsInListByCategoryId(products,88);
            Console.WriteLine($"Quantity of products in product list in given category is {totalQuantityfProductsInListByCategoryId}");

            // 3) Display costliest product details of a specific category.
            Console.WriteLine("\n Display costliest product details of a specific category.");
            try
            {
                IEnumerable<Product> costliestProductInCategory = program.CostliestProductInCategory(products, id);
                foreach (Product item in costliestProductInCategory)
                {
                    Console.WriteLine(item.Name + "\t" + item.Price);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter Correct category id");
            }

            // 4) Display cheapest product details of a specific category.
            Console.WriteLine(" Display cheapest product details of a specific category.");
            try
            {
                IEnumerable<Product> cheapestProductInCategory = program.CheapestProductInCategory(products, id);
                foreach (Product item in cheapestProductInCategory)
                {
                    Console.WriteLine(item.Name + "\t" + item.Price);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter correct category id");
            }

            // 5) Filter products which have crossed the Expiry date.
            Console.WriteLine("\nFilter products which have crossed the Expiry date.");
            try
            {
                // Extension Method
                List<Product> expiredProductList = program.ExpiredProductList(products);
                foreach (Product item in expiredProductList)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("There is no expired product");
            }

            // 6) Filter products which are expiring in next month.
            Console.WriteLine("\nFilter products which are expiring in next month.");
            try
            {
                // Using Extension Method
                List<Product> expiryProductListInNextMonth = products.ExpiryProductListInNextMonth(30);
                foreach (Product item in expiryProductListInNextMonth)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No product is expiring in next month");
            }

            // 7) Find products by id, category, name.
            // Find Product by Category id
            Console.WriteLine("\nFind Product by Category id");
            try
            {
                List<Product> productsByCategoryId = program.ProductsByCategoryId(products,2);
                foreach (Product item in productsByCategoryId)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine("No product in given categoryId");
            }
            // Find Product by Category name
            Console.WriteLine("\nFind Product by Category name");
            var newName = "Fruit";
            try
            {
                List<Product> productsByCategoryName = program.ProductsByCategoryName(products, categories, newName);
                foreach (Product item in productsByCategoryName)
                {
                    Console.WriteLine(item.Name);
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No product in category");
            }

            //Find Product by name
            Console.WriteLine("\nFind Product by name");
            try
            {
                Product productByName = program.ProductsByName(products, name);
                Console.WriteLine(productByName.Name);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("There is no such product in the product list");
            }

            // Find Product by id
            Console.WriteLine("\nFind Product by id");
            try
            {
                Product productById = program.ProductById(products,1);
                Console.WriteLine(productById.Name + "\t" + productById.Price);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("There is no product for given product id");
            }

            // 8) Create 2 list of products and perform following operations
            List<Product> products1 = Product.GetProducts1();

            List<Product> products2 = Product.GetProducts2();

            Console.WriteLine("\nDisplay common products");
            // 1) Display common products.
            try
            {
                IEnumerable<string> commonProducts = program.CommonProducts(products1, products2);
                foreach (var item in commonProducts)
                {
                    Console.WriteLine(item);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No product is common in two lists");
            }

            // 2) Display unique products from both lists.
            Console.WriteLine("\nDisplay unique products from both lists.");
            var distinctProducts = program.DistinctProducts(products1, products2);
            try
            {
                foreach (string item in distinctProducts)
                {
                    Console.WriteLine(item);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("No unique products from both lists.");
            }

            // 3) Display products from list 1 which are not in list 2.
            Console.WriteLine("\nDisplay products from list 2 which are not in list 1.");
            try
            {
                var distinctProductsInList2 = program.DistinctProductsInList(products2, products1);
                foreach (var item in distinctProductsInList2)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There are no products from list 2 which are not in list 1");
            }

            // 4) Unique products from list 1.
            Console.WriteLine("\nUnique products from list 1.");
            try
            {
                var distinctProductsInList1 = program.DistinctProductsInList(products1, products2);
                foreach (var item in distinctProductsInList1)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There are Unique products from list 1");
            }

            // 9) Perform sorting operation on products on Price, Quantity, Expiry date,
            // Sort by price(Ascending)
            var sortProductByPrice = program.SortProductByPrice(products);
            Console.WriteLine("\nSort by Price(Ascending)");
            foreach (Product item in sortProductByPrice)
            {
                Console.WriteLine(item.Price + "\t" + item.Name);
            }

            // Sort by price(Descending)
            var sortProductByPriceDesc = program.SortProductByPriceDesc(products);
            Console.WriteLine("\nSort by Price(Descending)");
            foreach (Product item in sortProductByPriceDesc)
            {
                Console.WriteLine(item.Price + "\t" + item.Name);
            }

            // Sort by quantity(Ascending)
            var sortProductByQuantity = program.SortProductByQuantity(products);
            Console.WriteLine("\nSort by Quantity(Ascending)");
            foreach (Product item in sortProductByQuantity)
            {
                Console.WriteLine(item.Quantity + "\t" + item.Name);
            }

            // Sort by Expiry Date(Ascending)
            //Instance Method
            IEnumerable<Product> sortProductByExpiryDate = program.SortProductByExpiryDate(products);
            Console.WriteLine("\nSort by Expiry Date(Ascending)");
            foreach (Product item in sortProductByExpiryDate)
            {
                Console.WriteLine(item.ExpiryDate + "\t" + item.Name);
            }

            // 10) Make use of "Any", "All" and "Contains" on product list.
            Console.WriteLine("\nAny Product description has keyword 'Fresh'");
            bool anyDescriptionContain = program.AnyDescriptionContain(products, "Fresh");
            Console.WriteLine(anyDescriptionContain);
            Console.WriteLine("\nAll Product description has keyword 'Fresh'");
            bool allDescriptionContain = program.AllDescriptionContain(products, "Fresh");
            Console.WriteLine(allDescriptionContain);

            // 11) Perform join of product and category and
            // display - Product name, Category Name, Product price and Product description.
            var joinProductCategory = program.joinProductCategory(products, categories);
            Console.WriteLine("\njoin of product and category");
            foreach (var item in joinProductCategory)
            {
                Console.WriteLine(item);
            }

            
        }

        static double AveragePriceById(int i)
        {
            var products = Product.GetProducts();
            return products
                .Where(product => product.CategoryId.Equals(i))
                .Average(product => product.Price);
        }

        static double AveragePriceofProducts(string name, IEnumerable<Product> products, IEnumerable<Category> categories)
        {
            return products.Where(product => product.CategoryId.Equals(categories.Single(category => category.Name.Equals(name)).Id))
                    .Average(product => product.Price);
        }

        static double AveragePriceofAllProducts(IEnumerable<Product> products)
        {
            return products.Average(product => product.Price);
        }

        int TotalQuantityfAllProducts(IEnumerable<Product> products)
        {
            return products.Sum(product => product.Quantity);
        }

        // Total Quantity of product in list
        int TotalQuantityfAllProductsInList(IEnumerable<Product> products)
        {
            return products.Count();
        }

        //Total Quantity of products by category
        int TotalQuantityfProductsByCategoryId(IEnumerable<Product> products,int id)
        { 
            return products.Where(product => product.CategoryId.Equals(id))
                    .Sum(product => product.Quantity);
        }

            //Total Quantity of products in list by category
        int TotalQuantityfProductsInListByCategoryId(IEnumerable<Product> products, int id)
        {
            return products.Count(product => product.CategoryId.Equals(id));
        }    

        IEnumerable<Product> SortProductByExpiryDate(IEnumerable<Product> products)
        {
            return products.OrderBy(product => product.ExpiryDate);
        }

        IEnumerable<Product> CostliestProductInCategory(IEnumerable<Product> products,int id)
        {
            double maxPrice =
                    products.Where(product => product.CategoryId.Equals(id))
                        .Max(product => product.Price);
            return products.Where(product => product.CategoryId.Equals(id) && product.Price.Equals(maxPrice))
                .ToList();
        }

        IEnumerable<Product> CheapestProductInCategory(IEnumerable<Product> products, int id)
        {
            double cheapestPrice =
                    products.Where(product => product.CategoryId.Equals(id))
                        .Min(product => product.Price);
            return products.Where(product => product.CategoryId.Equals(id) && product.Price.Equals(cheapestPrice))
                                              .ToList();
        }

        List<Product> ExpiredProductList(IEnumerable<Product> products)
        {
            return products.ExpiredProductList();
        }

        List<Product> ProductsByCategoryId(IEnumerable<Product> products, int id)
        {
            return products.Where(product => product.CategoryId.Equals(id)).ToList();
        }

        List<Product> ProductsByCategoryName(IEnumerable<Product> products,IEnumerable<Category> categories, string name)
        {
            return products.Where(product => product.CategoryId.Equals(categories.Single(category => category.Name.Equals(name)).Id))
                        .ToList();
        }

        Product ProductsByName(IEnumerable<Product> products, string name)
        {
            return products.Single(product => product.Name.Equals(name));
        }

        Product ProductById(IEnumerable<Product> products, int id)=>
            products.SingleOrDefault(product => product.Id.Equals(id));


        dynamic joinProductCategory(List<Product> products, List<Category> categories)
        {
            return products.Join(
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
        }

        List<string> CommonProducts(List<Product> products1, List<Product> products2)
        {
            return products1.Select(p => p.Name).Intersect(products2.Select(p => p.Name)).ToList();
        }

        List<string> DistinctProducts(List<Product> products1, List<Product> products2)
        {
            return products1.Select(p1 => p1.Name).Except(products2.Select(p2 => p2.Name))
                .Union(products2.Select(p2 => p2.Name).Except(products1.Select(p1 => p1.Name))).ToList();
        }
        List<string> DistinctProductsInList(List<Product> list1, List<Product> list2)
        {
            return list1.Select(p1 => p1.Name).Except(list2.Select(p2 => p2.Name)).ToList();
        }

        bool AllDescriptionContain(List<Product> products, string value) =>
            products.All(product => product.Description.Contains(value));

        bool AnyDescriptionContain(List<Product> products, string value) =>
            products.Any(product => product.Description.Contains(value));

        IEnumerable<Product> SortProductByQuantity(List<Product> products) =>
                products.OrderBy(product => product.Quantity).ThenBy(product => product.Name);

        // Sort by price(Ascending)
        IEnumerable<Product> SortProductByPrice(List<Product> products) => products.OrderBy(product => product.Price);

        // Sort by price(Descending)
        IEnumerable<Product> SortProductByPriceDesc(List<Product> products) => products.OrderByDescending(product => product.Price);

    }

}
