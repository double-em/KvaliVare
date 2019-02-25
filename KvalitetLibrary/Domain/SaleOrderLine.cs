using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetLibrary.Domain
{
    public class SaleOrderLine
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public SaleOrderLine(Product product, int quantity, double price)
        {
            this.product = product;
            Quantity = quantity;
            Price = price;
        }
    }
}
