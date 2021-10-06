using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CourseWork2
{
    public partial class WindowEditProduct : Window
    {
        public WindowEditProduct()
        {
            InitializeComponent();
            ResultTextBlock.Text = MainWindow.productList[WindowRemoveProduct.index].Print() + "\n";
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {//it's okay even when fields are not filled
                if (NameTextBox.Text.Length != 0)
                {
                    MainWindow.productList[WindowRemoveProduct.index].Name = NameTextBox.Text;
                }
                if (QuantityTextBox.Text.Length != 0)
                {
                    MainWindow.productList[WindowRemoveProduct.index].Quantity = int.Parse(QuantityTextBox.Text);
                }
                if (PriceTextBox.Text.Length != 0)
                {
                    MainWindow.productList[WindowRemoveProduct.index].Price = int.Parse(PriceTextBox.Text);
                }
            }
            catch (Exception)//but they must be filled correctly
            {
                MessageBox.Show("Ви ввели щось невірно");
                return;
            }
            ResultTextBlock.Text = MainWindow.productList[WindowRemoveProduct.index].Print() + "\n";
        }
        private void Back_Click(object sender, RoutedEventArgs e)//to remove window
        {
            WindowRemoveProduct windowRemoveProduct = new WindowRemoveProduct();
            windowRemoveProduct.Show();
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
