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
        private DBcontroller dBcontroller = new DBcontroller();

        public Controller()
        {
            customerRepository = customerRepository.Getinstance();
        }

        public void CreateCustomerandAdd(int id, string name, string address, string ZIP, string town, string telephone)
        {
            Customer customer = customerRepository.CreateCustomer(id, name, address, ZIP, town, telephone);
            customerRepository.AddCustomer(customer);
        }

    }
}
