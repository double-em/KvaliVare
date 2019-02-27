using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
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
            SetupOrderRepo();

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

        private void SetupOrderRepo()
        {
            orderRepository = orderRepository.getInstance();
            List<string> orders = dBcontroller.GetAllOrders();

            foreach (string order in orders)
            {
                string[] values = order.Split(',');

                int.TryParse(values[0], out int orderId);
                bool.TryParse(values[4], out bool picked);

                Customer customer = GetCustomer(values[1]);

                List<string> saleOrderLinesValues = dBcontroller.GetSaleOrderLines(orderId);
                List<SaleOrderLine> saleOrderLines = new List<SaleOrderLine>();
                foreach (string saleOrderLineValue in saleOrderLinesValues)
                {
                    string[] valuesSaleLine = saleOrderLineValue.Split(',');

                    int.TryParse(valuesSaleLine[0], out int productId);
                    int.TryParse(valuesSaleLine[1], out int quantity);
                    double.TryParse(valuesSaleLine[2], out double price);

                    SaleOrderLine saleOrderLine = new SaleOrderLine(GetProduct(productId), quantity, price);
                    saleOrderLines.Add(saleOrderLine);
                }

                orderRepository.AddOrder(orderRepository.CreateOrder(saleOrderLines, customer, orderId, values[2], values[3], picked));
            }
        }

        public void CreateOrder(List<SaleOrderLine> orderlines, Customer customer, string orderDate, string deliveryDate, bool picked = false)
        {
            int orderId = dBcontroller.RegisterOrder(customer.Id, orderDate, deliveryDate, picked);
            orderRepository.AddOrder(orderRepository.CreateOrder(orderlines, customer, orderId, orderDate, deliveryDate, picked));
        }

        public Customer GetCustomer(string searchQuery)
        {
            return customerRepository.GetCustomer(searchQuery);
        }

        public Product GetProduct(int id)
        {
            return productRepository.GetProduct(id);
        }

        public Product GetProduct(string name)
        {
            return productRepository.GetProduct(name);
        }
    }
}
