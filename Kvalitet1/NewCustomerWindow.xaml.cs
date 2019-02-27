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

namespace Kvalitet1
{
    /// <summary>
    /// Interaction logic for OpretKundeWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        public NewCustomerWindow()
        {
            InitializeComponent();
        }

        private void TilbageButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void CustomerNameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AdressTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ZipTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TownTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhoneTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
