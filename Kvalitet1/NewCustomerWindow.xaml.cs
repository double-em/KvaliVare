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

namespace Kvalitet1
{
    /// <summary>
    /// Interaction logic for OpretKundeWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        private Controller control;
        public NewCustomerWindow(Controller control)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerNameTxtBox.Text = "";
            AdressTxtBox.Text = "";
            ZipTxtBox.Text = "";
            TownTxtBox.Text = "";
            PhoneTxtBox.Text = "";

            control.CreateCustomerandAdd(CustomerNameTxtBox.Text, AdressTxtBox.Text, ZipTxtBox.Text, TownTxtBox.Text, PhoneTxtBox.Text);
        }
    }
}
