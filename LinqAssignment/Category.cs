using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        static List<Category> categories = new List<Category>
            {
                new Category{ Id=1, Name= "Dairy", Description="Dairy Products"},
                new Category{ Id=2, Name= "Packaged Foods", Description="Packaged food Products"},
                new Category{ Id=3, Name= "Oil", Description="Various Edible Oils"},
                new Category{ Id=4, Name= "Fruits", Description="Fresh fruits"},
                new Category{ Id=5, Name= "Grains", Description="Grains for eating"}
            };

        public static List<Category> GetCategories()
        {
            return categories;
        }
    }
}
