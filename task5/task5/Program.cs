using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{   class Product
    {
        public int ID;
        public string Name;
        public double Price;
        public string Category;
        public string Brand;
        public string Country;

        public Product(int id, string name, double price, string category, string brand, string country)
        {
            ID = id;
            Name = name;
            Price = price;
            Category = category;
            Brand = brand;
            Country = country;
        }

        public void ShowProduct()
        {;
            Console.WriteLine("ID       : " + ID);
            Console.WriteLine("Name     : " + Name);
            Console.WriteLine("Price    : $" + Price);
            Console.WriteLine("Category : " + Category);
            Console.WriteLine("Brand    : " + Brand);
            Console.WriteLine("Country  : " + Country);
        }
    }

    class ProductManagement
    {
        static List<Product> products = new List<Product>();
        static int nextId = 1;

        static void AddProduct()
        {
            Console.Write("Enter product name     : "); string name = Console.ReadLine();
            Console.Write("Enter price            : "); double price = double.Parse(Console.ReadLine());
            Console.Write("Enter category         : "); string category = Console.ReadLine();
            Console.Write("Enter brand            : "); string brand = Console.ReadLine();
            Console.Write("Enter country of origin: "); string country = Console.ReadLine();
            products.Add(new Product(nextId++, name, price, category, brand, country));
            Console.WriteLine("Product added successfully");
        }

        static void ShowAllProducts()
        {
            if (products.Count == 0) { Console.WriteLine("No products found."); return; }
            Console.WriteLine(" All Products ");
            foreach (Product p in products) p.ShowProduct();
        }

        static void TotalStoreWorth()
        {
            double total = 0;
            foreach (Product p in products) total += p.Price;
            Console.WriteLine("Total Store Worth: " + total);
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine(" Product Management ");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Total Store Worth");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddProduct(); break;
                    case 2: ShowAllProducts(); break;
                    case 3: TotalStoreWorth(); break;
                    case 0: Console.WriteLine("Exiting"); break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            } while (choice != 0);
        }
    }
}