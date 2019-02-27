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
        private OrderRepository instance;
        private List<Order> orders = new List<Order>();

        public OrderRepository getInstance()
        {
            if (instance == null)
            {
                instance = new OrderRepository();
            }
            return instance;
        }
    }
}
