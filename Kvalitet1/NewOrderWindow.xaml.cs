using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KvalitetLibrary.App;
using KvalitetLibrary.Domain;

namespace Kvalitet1
{
    /// <summary>
    /// Interaction logic for OpretOrdreWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        private Controller control;
        private Product product;
        private List<SaleOrderLine> saleOrderLines;
        public NewOrderWindow(Controller control)
        {
            InitializeComponent();
            this.control = control;
        }

        private void TilbageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BtnFindProduct_Click(object sender, RoutedEventArgs e)
        {
            product = control.GetProduct(tbProductName.Text);

            if (product != null)
            {
                lProductName.Content = "Produkt: " + product.Name;
                lProductPrice.Content = "Pris pr. stk.: " + product.Price + ",-";
            }
            
        }

        private void TbQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            int.TryParse(tbQuantity.Text, out int quantity);
            if (product != null)
            {
                lPrice.Content = "I alt: " + product.Price * quantity + ",-";
            }
            
        }

        private void BtnSaleOrderLine_Click(object sender, RoutedEventArgs e)
        {
            if (saleOrderLines == null)
            {
                saleOrderLines = new List<SaleOrderLine>();
            }

            int.TryParse(tbQuantity.Text, out int quantity);
            saleOrderLines.Add(new SaleOrderLine(product, quantity, product.Price * quantity));

            lbOrderLines.Items.Add(product.Name + "\t" + product.Price + "\t" + quantity + "\t" + (double)(product.Price * quantity));

            double total = 0;
            foreach (SaleOrderLine saleOrderLine in saleOrderLines)
            {
                total += saleOrderLine.Price;
            }
            lTotal.Content = "I alt: " + total + ",-";
        }

        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = control.GetCustomer(tbCustomerId.Text);
            if (customer != null)
            {
                control.CreateOrder(saleOrderLines, customer, DateTime.Today.ToShortDateString(), DateTime.Today.AddDays(3).ToShortDateString());
                CleanUp();
            }
            
        }

        private void CleanUp()
        {
            saleOrderLines = new List<SaleOrderLine>();
            product = null;
            
            tbProductName.Text = "";

            lProductName.Content = "Produkt: Ingen";
            lProductPrice.Content = "Pris pr. stk.: 00,00,-";
            tbQuantity.Text = "";
            lPrice.Content = "I alt: 00,00,-";

            tbCustomerId.Text = "";
            lbOrderLines.Items.Clear();
            lTotal.Content = "I alt: 00,00,-";
        }
    }
}
