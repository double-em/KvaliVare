using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KvalitetLibrary.Domain;

namespace KvalitetLibrary.App
{
    public class CustomerRepository
    {
        private static CustomerRepository instance; 
        private List<Customer> customers = new List<Customer>();

        public CustomerRepository Getinstance()
        {
            if (instance == null)
            {
                instance = new CustomerRepository();                
            }
            return instance;
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer CreateCustomer(int id, string name, string address, string ZIP, string town, string telephone)
        {
            Customer customer = new Customer(id, name, address, ZIP, town, telephone);
            return customer;
        }

    }
}
