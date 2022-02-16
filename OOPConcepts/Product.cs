using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcepts
{
    public class Product    //Parent Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public void Stock(int quantity)
        {
            Quantity += quantity;
        }
        public int Buy(int quantity)
        {
            if (quantity>Quantity)
            {
                return 0;
            } 
            Quantity -= quantity;
            return quantity * Price;
        }

        
    }
}
