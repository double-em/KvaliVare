using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetLibrary.Domain
{
    public class Order
    {
        private List<SaleOrderLine> orderlines;
        public Customer customer { get; set; }
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryDate { get; set; }
        public bool Picked { get; set; }

        public Order(List<SaleOrderLine> orderlines, Customer customer, int orderId, string orderDate, string deliveryDate, bool picked)
        {
            this.orderlines = orderlines;
            this.customer = customer;
            OrderId = orderId;
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            Picked = picked;
        }

        public void AddOrderLine(Product product, int quantity, double price)
        {
            SaleOrderLine saleOrderLine = new SaleOrderLine(product, quantity, price);
            orderlines.Add(saleOrderLine);
        }

        public void Removeorderlines(int index)
        {
            orderlines.RemoveAt(index);
        }
    }
}
