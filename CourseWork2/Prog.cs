using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class Product//class of products
    {
        //fields
        private string name;//contains name of product
        public string Name
        {
            get { return name; }
            set 
            {
                if (value.Length > 20 || value.Length < 3)//what length of name should be
                {
                    throw new Exception();
                }
                name = value; 
            }
        }
        public string Measure { get; } = "тон";//contains measure of product

        private int quantity;//quantity of product
        public int Quantity
        {
            get { return quantity; }
            set 
            {
                if (value < 1 || value > 25)//what range of quantity should be
                {
                    throw new Exception();
                }
                quantity = value; 
            }
        }

        public int Price { get; set; }//price of product

        private string date;//date of adding to storage
        public string Date
        {
            get { return date; }
        }

        //ctors
        public Product()
        {
            Name = "DefaultName";
            Quantity = 1;
            Price = 1000;
            date = DateTime.Now.ToString("HH:mm");
        }
        public Product(string name, int quantity, int price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            date = DateTime.Now.ToString("HH:mm");
        }

        //methods
        public string Print()//printing info of product
        {
            string str = "";
            str += $"Назва: {Name} \nКількість: {Quantity} {Measure} \nЦіна: {Price} \nДата надходження: {Date}";
            return str;
        }
    }

    abstract public class Person//parent class
    {
        abstract public int Cash { get; set; }//cash of person

    }
    class Customer : Person//person, who buys product
    {
        public override int Cash { get; set; }//cash of customer
        
        public Customer(int cash)
        {
            Cash = cash;
        }

    }

    public class Owner : Person//class for user
    {
        public override int Cash { get; set; }//cash of owner
        public int MoneySpent { get; private set; }
        private readonly string savePath = @"C:\Users\WWW\source\repos\CourseWork2\CourseWork2\OwnerSave.txt";

        public Owner()
        {
            Cash = 0;
        }

        //methods
        public void EarnMoney(int money)//method which allow earn money
        {
            Cash += money;
            
            Delivery();
        }

        public void Delivery()//delivery for products
        {
            int deliveryPrice = 100;
            MoneySpent += deliveryPrice;
            Cash -= deliveryPrice;
        }

        public void Load()//load save
        {
            Cash = int.Parse(Regex.Replace(Regex.Match(File.ReadAllText(savePath), @"(C|c)ash *\d+").ToString(), @"(C|c)ash *", ""));
            MoneySpent = int.Parse(Regex.Replace(Regex.Match(File.ReadAllText(savePath), @"(M|m)oney(S|s)pent *\d+").ToString(), @"(M|m)oney(S|s)pent *", ""));
        }

        public void Save()
        {
            File.WriteAllText(savePath, $"cash {Cash}\nmoneySpent {MoneySpent}");
        }
    }
}
