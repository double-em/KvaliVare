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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KvalitetLibrary;
using KvalitetLibrary.App;
using KvalitetLibrary.Domain;

namespace Kvalitet1
{
    /// <summary>
    /// Interaction logic for FindKundeWindow.xaml
    /// </summary>
    public partial class FindCustomerWindow : Window
    {
        private Controller control;
        public FindCustomerWindow(Controller control)
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

        private void CustomerIDTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Customer customer = control.GetCustomer(CustomerIDTxtBox.Text);

            lFindID.Content = "ID: " + customer.Id;
            lFindName.Content = "Navn: " + customer.Name;
            lFindAddress.Content = "Adresse: " + customer.Address;
            lFindZIP.Content = "ZIP: " + customer.ZIP;
            lFindTown.Content = "By: " + customer.Town;
            lFindTelephone.Content = "Telefonnummer: " + customer.Telephone;
        }
    }
}
