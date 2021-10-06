using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTemp
{
    class Test
    {
        public int Price { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Test()
        {
            Price = 0;
            Name = "Default_Name";
        }
        public Test(string name)
        {
            Price = 69;
            Name = name;
        }
        public Test(int price, string name)
        {
            Price = price;
            Name = name;
        }


        public void Show()
        {
            Console.WriteLine($"name: {Name}");
            Console.WriteLine($"price: {Price}");
        }
    }

    class Test1 : Test
    {
        public Test1()
        {
            Console.WriteLine("Test1 ctor");
        }
        public void Check()
        {
            Console.WriteLine("First class");
        }
    }

    class Test2 : Test
    {
        public void Check()
        {
            Console.WriteLine("Second class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            
            Console.ReadKey();
        }
    }
}
