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
    /// <summary>
    /// Interaction logic for WindowAddProduct.xaml
    /// </summary>
    public partial class WindowAddProduct : Window
    {

        public WindowAddProduct()
        {
            InitializeComponent();
        }

        private void Done_Click(object sender, RoutedEventArgs e)//add product to list
        {
            try
            {   //if at least one of fields are not filled - exception
                if (NameTextBox.Text.Length < 1 || QuantityTextBox.Text.Length < 1 || NameTextBox.Text.Length < 1)
                {
                    throw new Exception();
                }
                MainWindow.productList.Add(new Product(NameTextBox.Text, int.Parse(QuantityTextBox.Text), int.Parse(PriceTextBox.Text)));
                MainWindow.owner.Delivery();
                MessageBox.Show("Готово");
            }
            catch (Exception)
            {
                MessageBox.Show("Ви щось ввели невірно");
                return;
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)//to main window
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
