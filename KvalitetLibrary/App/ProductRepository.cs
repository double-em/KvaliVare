using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KvalitetLibrary.Domain;


namespace KvalitetLibrary.App
{
    class ProductRepository
    {
        private List<Product> products = new List<Product>();
        private ProductRepository instance;

        public ProductRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ProductRepository();
            }
            return instance;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public Product CreateProduct(int id, string name, string description, double price, int minInStock)
        {
            return new Product(id, name, description, price, minInStock);
        }

        public Product GetProduct(int id)
        {
            foreach (Product product in products)
            {
                if (product.ProductId == id)
                {
                    return product;
                }
            }
            return null;
        }

        public Product GetProduct(string name)
        {
            foreach (Product product in products)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
