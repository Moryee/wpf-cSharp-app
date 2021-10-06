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
    public partial class WindowSellProduct : Window
    {
        public int IndexOfProduct { get; set; }
        Customer dude;

        public WindowSellProduct()
        {
            InitializeComponent();
            FillText();
        }

        private bool Check()
        {
            if (MainWindow.productList.Count() == 0)
            {
                MessageBox.Show("У вас немає товарів на продажу");
                CustomerTextBlock.Text = "";
                return true;
            }
            return false;
        }

        public void FillText()//new customer which can buy product
        {
            if (Check())
            {
                return;
            }
            

            Random rnd = new Random();
            IndexOfProduct = rnd.Next(0, MainWindow.productList.Count());

            dude = new Customer(MainWindow.productList[IndexOfProduct].Price + rnd.Next(0, 100000));
            CustomerTextBlock.Text = $"Доброго дня. Я б хотів у вас купити '{MainWindow.productList[IndexOfProduct].Name}' за {MainWindow.productList[IndexOfProduct].Price} \nВ моєму бюджеті є {dude.Cash} гривень";
        }

        private void Next_Click(object sender, RoutedEventArgs e)//next customer
        {
            FillText();
        }

        private void Sell_Click(object sender, RoutedEventArgs e)//earning money by selling products
        {
            if (Check())
            {
                return;
            }

            //MainWindow.owner.Cash += MainWindow.productList[IndexOfProduct].Price;
            //MainWindow.productList.RemoveAt(IndexOfProduct);

            MainWindow.owner.EarnMoney(MainWindow.productList[IndexOfProduct].Price);
            MainWindow.productList.RemoveAt(IndexOfProduct);

            FillText();
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
