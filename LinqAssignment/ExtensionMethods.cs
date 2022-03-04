using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    static class ExtensionMethods
    {
        public static List<Product> ExpiryProductListInNextMonth(this IEnumerable<Product> products,int days)
        { 
            return products
                .Where(product => product.ExpiryDate.CompareTo(DateTime.Now.AddDays(days)) < 0 && !(product.ExpiryDate.CompareTo(DateTime.Now) < 0))
                        .ToList();
        }
        public static List<Product> ExpiredProductList(this IEnumerable<Product> products)
        {
            return products.Where(product => product.ExpiryDate.CompareTo(DateTime.Now) < 0 && !product.ExpiryDate.Equals(Convert.ToDateTime("01-01-0001")))
                        .ToList();
        }
                    

    }
}
