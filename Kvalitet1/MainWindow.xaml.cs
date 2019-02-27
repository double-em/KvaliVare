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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kvalitet1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewOrderbutton_Click(object sender, RoutedEventArgs e)
        {
            NewOrderWindow order = new NewOrderWindow();
            order.Show();
            this.Close();
        
        }

        private void NewCustomerbutton_Click(object sender, RoutedEventArgs e)
        {
            NewCustomerWindow newcustomer = new NewCustomerWindow();
            newcustomer.Show();
            this.Close();

        }

        private void FindCustomerbutton_Click(object sender, RoutedEventArgs e)
        {
            FindCustomerWindow findcustomer = new FindCustomerWindow();
            findcustomer.Show();
            this.Close();

        }
    }
}
