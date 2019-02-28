using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KvalitetLibrary.Domain;


namespace KvalitetLibrary.App
{
    class OrderRepository
    {
        private static OrderRepository instance;
        private List<Order> orders = new List<Order>();

        public static OrderRepository getInstance()
        {
            if (instance == null)
            {
                instance = new OrderRepository();
            }
            return instance;
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public Order CreateOrder(List<SaleOrderLine> saleOrderLines, Customer customer, int orderId, string orderDate, string deliveryDate, bool picked)
        {
            return new Order(saleOrderLines, customer, orderId, orderDate, deliveryDate, picked);
        }
    }
}
