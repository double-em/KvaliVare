﻿using System;
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
    /// Interaction logic for OpretOrdreWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        private Controller control;
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

        private void OrderNameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DescriptonTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PriceTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StockTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}