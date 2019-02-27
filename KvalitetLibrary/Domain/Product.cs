using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetLibrary.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MinInStock { get; set; }

        public Product(int productId, string name, string description, double price, int minInStock)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            MinInStock = minInStock;
        }
    }
}
