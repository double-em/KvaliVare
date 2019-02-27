using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public Controller()
        {
            SetupCustomerRepo();

            SetupProductRepo();

        }

        public void CreateCustomerandAdd(string name, string address, string ZIP, string town, string telephone)
        {
            int id = dBcontroller.RegisterUser(name, address, ZIP, town, telephone);
            Customer customer = customerRepository.CreateCustomer(id, name, address, ZIP, town, telephone);
            customerRepository.AddCustomer(customer);
        }

        public void SetupCustomerRepo()
        {
            List<string> templist = dBcontroller.GetAllCustomers();
            customerRepository = customerRepository.Getinstance();
            foreach (var item in templist)
            {
                string[] splitarry = item.Split(',');
                customerRepository.AddCustomer(customerRepository.CreateCustomer(int.Parse(splitarry[0]), splitarry[1], splitarry[2], splitarry[3], splitarry[4], splitarry[5]));
            }
        }

        public void SetupProductRepo()
        {
            productRepository = productRepository.getInstance();
            List<string> products = dBcontroller.GetAllProducts();
            foreach (string productValues in products)
            {
                string[] values = productValues.Split(',');

                int.TryParse(values[0], out int id);
                double.TryParse(values[3], out double price);
                int.TryParse(values[4], out int minInStock);
                Product product = productRepository.CreateProduct(id, values[1], values[2], price, minInStock);
                productRepository.AddProduct(product);
            }

        }

        public void CreateOrder(string orderDate, string deliveryDate, int productTypeId, int quantity)
        {
            
        }

        public void AddSaleOrderLine(int orderId)
        {
            
        }

        public string GetCustomer(string searchQuery)
        {
            return customerRepository.GetCustomer(searchQuery);
        }
    }
}
