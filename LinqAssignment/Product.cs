using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CategoryId { get; set; }

        static List<Product> products = new List<Product>
            {
                new Product{ Id=1,Name="Milk",Description="Fresh Milk", ExpiryDate=Convert.ToDateTime("02-03-2022"),Price=20,Quantity=14,CategoryId=1},
                new Product{ Id=2,Name="Butter",Description="Fresh Butter", ExpiryDate=Convert.ToDateTime("04-03-2022"),Price=60,Quantity=14,CategoryId=1},
                new Product{ Id=3,Name="Curd",Description="Fresh Curd", ExpiryDate=Convert.ToDateTime("03-03-2022"),Price=50,Quantity=14,CategoryId=1},
                new Product{ Id=4,Name="Biscuits",Description="Glucose Biscuits", ExpiryDate=Convert.ToDateTime("03-03-2022"),Price=10,Quantity=614,CategoryId=2},
                new Product{ Id=5,Name="Cookies",Description="Sweet cookies", ExpiryDate=Convert.ToDateTime("05-03-2022"),Price=25,Quantity=214,CategoryId=2},
                new Product{ Id=6,Name="Chocolates",Description="Milk Chocolates", ExpiryDate=Convert.ToDateTime("12-03-2022"),Price=120,Quantity=311,CategoryId=2},
                new Product{ Id=7,Name="Soybean oil",Description="Refined oil", ExpiryDate=Convert.ToDateTime("12-03-2022"),Price=160,Quantity=314,CategoryId=3},
                new Product{ Id=8,Name="mustard oil",Description="Non-refined oil", ExpiryDate=Convert.ToDateTime("12-04-2022"),Price=220,Quantity=214,CategoryId=3},
                new Product{ Id=9,Name="olive oil",Description="Extra virgin oil", ExpiryDate=Convert.ToDateTime("12-05-2022"),Price=520,Quantity=64,CategoryId=3},
                new Product{ Id=10,Name="Mango",Description="Fresh Ratnagiri Mangoes", ExpiryDate=Convert.ToDateTime("12-05-2022"),Price=200,Quantity=54,CategoryId=4},
                new Product{ Id=11,Name="Apple",Description="Fresh kashmir Apples", ExpiryDate=Convert.ToDateTime("12-05-2022"),Price=160,Quantity=24,CategoryId=4},
                new Product{ Id=12,Name="Orange",Description="Fresh Nagpur Oranges", ExpiryDate=Convert.ToDateTime("12-05-2022"),Price=80,Quantity=34,CategoryId=4},
                new Product{ Id=13,Name="Wheat",Description="Wheat grains",Price=30,Quantity=314,CategoryId=5, ExpiryDate=Convert.ToDateTime("12-05-2025")},
                new Product{ Id=14,Name="Rice",Description="Rice grain",Price=60,Quantity=114,CategoryId=5, ExpiryDate=Convert.ToDateTime("12-05-2025")}
            };

        public static List<Product> GetProducts()
        {
            return products;
        }
    }
}
