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
    public partial class WindowRemoveProduct : Window
    {
        private static int indx;

        public static int index
        {
            get { return indx; }
            private set { indx = value - 1; }
        }

        public WindowRemoveProduct()
        {
            InitializeComponent();
            Search();
        }

        private void Search()
        {
            ResultTextBlock.Text = "";//clear previous search result
            int i = 1;
            bool isFound = false;
            try
            {
                MainWindow.productList.FindAll(
                    delegate (Product temp)
                    {   //filter for search
                        if (temp.Name.Contains(NameTextBox.Text) && temp.Quantity.ToString().Contains(QuantityTextBox.Text) &&
                               temp.Price.ToString().Contains(PriceTextBox.Text))
                        {
                            isFound = true;
                            ResultTextBlock.Text += temp.Print() + $"\nНомер: {i}" + "\n\n";
                        }
                        i++;
                        return true;
                    });
            }
            catch (Exception)//fields must be filled correctly
            {
                MessageBox.Show("Ви щось ввели невірно");
                return;
            }
            if (isFound == false)
            {
                MessageBox.Show("Нічого не було знайдено");
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                index = int.Parse(IndexTextBox.Text);
                MainWindow.productList.RemoveAt(index);
                MessageBox.Show("Товар був успішно видалений");
                Search();
            }
            catch (Exception)
            {
                MessageBox.Show("Ви щось ввели невірно");
                return;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                index = int.Parse(IndexTextBox.Text);
                WindowEditProduct windowEditProduct = new WindowEditProduct();
                windowEditProduct.Show();
                Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Ви щось ввели невірно");
                return;
            }
            
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
