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
    }
}
