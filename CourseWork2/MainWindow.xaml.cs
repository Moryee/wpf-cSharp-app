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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork2
{
    public partial class MainWindow : Window
    {
        //fields
        public static List<Product> productList = new List<Product>();
        public static Owner owner = new Owner();

        public MainWindow()
        {
            InitializeComponent();

            PlayerUpdate();

            for (int j = 0; j <= productList.Count - 2; j++)//сортування за ціною
            {
                for (int i = 0; i <= productList.Count - 2; i++)
                {
                    if (productList[i].Price > productList[i + 1].Price)
                    {
                        var temp = productList[i + 1];
                        productList[i + 1] = productList[i];
                        productList[i] = temp;
                    }
                }
            }

            foreach (var item in productList)
            {
                MainTextBlock.Text += item.Print() + "\n\n";//виведення продуктів
            }
        }

        public void PlayerUpdate()
        {
            MoneyTextBlock.Text = $"${owner.Cash}";//виведення грошей на екран
            SpendMoneyTextBlock.Text = $"Витрачено:{owner.MoneySpent}";//грошей витрачено
        }

        private void Add_Product_Click(object sender, RoutedEventArgs e)//виклик вікна для добавлення товару
        {
            WindowAddProduct windowAddProduct = new WindowAddProduct();
            windowAddProduct.Show();
            Hide();
                       
        }

        private void Sell_Product_Click(object sender, RoutedEventArgs e)//виклик вікна для продажі товару
        {
            WindowSellProduct windowSellProduct = new WindowSellProduct();
            windowSellProduct.Show();
            Hide();
        }

        private void Remove_Product_Click(object sender, RoutedEventArgs e)//виклик видалення товару
        {
            WindowRemoveProduct windowRemoveProduct = new WindowRemoveProduct();
            windowRemoveProduct.Show();
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)//закінчення роботи програми клавішою закриття
        {
            Application.Current.Shutdown();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            owner.Save();
            PlayerUpdate();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            owner.Load();
            PlayerUpdate();
        }
    }
}
