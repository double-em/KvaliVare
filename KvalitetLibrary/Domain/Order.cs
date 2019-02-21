using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetLibrary.Domain
{
    class Order
    {
        private List<SaleOrderLine> orderlines = new List<SaleOrderLine>();
        public Customer customer { get; set; }
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public bool Picked { get; set; }


        public void AddOrderLine(Product product, int quantity, double price)
        {
            throw new NotImplementedException();
        }
    }
}
