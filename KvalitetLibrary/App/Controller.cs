using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KvalitetLibrary.Domain;

namespace KvalitetLibrary.App
{
    public class Controller
    {
        private CustomerRepository customerRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private DBcontroller dBcontroller = new DBcontroller();
        private List<string> templist;

        public Controller()
        {
            update();
            customerRepository = customerRepository.Getinstance();
            foreach (var item in templist)
            {
                string[] splitarry = item.Split(',');
                customerRepository.AddCustomer(customerRepository.CreateCustomer(int.Parse(splitarry[0]), splitarry[1], splitarry[2], splitarry[3], splitarry[4], splitarry[5]));
            }

        }

        public void CreateCustomerandAdd(int id, string name, string address, string ZIP, string town, string telephone)
        {
            Customer customer = customerRepository.CreateCustomer(id, name, address, ZIP, town, telephone);
            customerRepository.AddCustomer(customer);
        }

        private void update()
        {
            templist = dBcontroller.GetAllCustomers();            
        }

    }
}
