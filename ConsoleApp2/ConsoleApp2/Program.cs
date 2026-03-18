using System;
using System.Collections.Generic;
using System.IO;
class User
{
    public string username;
    public string password;
    public string role;

    public User(string u, string p, string r)
    {
        username = u;
        password = p;
        role = r;
    }
}

class Product
{
    public int id;
    public string name;
    public double price;

    public Product(int i, string n, double p)
    {
        id = i;
        name = n;
        price = p;
    }
}

class Program
{
    static List<User> users = new List<User>();
    static List<Product> products = new List<Product>();
    static string currentRole = "";
    static int nextId = 1;

    static void Main()
    {
        users.Add(new User("admin", "admin123", "admin"));
        LoadUsers();
        LoadProducts();

        int choice;
        do
        {
            Console.WriteLine("\n=== MAIN MENU ===");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) SignUp();
            else if (choice == 2) SignIn();

        } while (choice != 3);
    }

    // ── SIGN UP ──

    static void SignUp()
    {
        Console.Write("Enter username: ");
        string u = Console.ReadLine();

        Console.Write("Enter password: ");
        string p = Console.ReadLine();

        User newUser = new User(u, p, "user");
        users.Add(newUser);

        SaveUsers();
        Console.WriteLine("Account created successfully!");
    }

    // ── SIGN IN ────

    static void SignIn()
    {
        Console.Write("Enter username: ");
        string u = Console.ReadLine();

        Console.Write("Enter password: ");
        string p = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].username == u && users[i].password == p)
            {
                found = true;
                currentRole = users[i].role;
                Console.WriteLine("Login successful! Role: " + currentRole);
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Wrong username or password!");
            return;
        }

        if (currentRole == "admin")
            AdminMenu();
        else
            UserMenu();
    }

    // ── ADMIN MENU ────

    static void AdminMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n=== ADMIN MENU ===");
            Console.WriteLine("1. Show all products");
            Console.WriteLine("2. Add product");
            Console.WriteLine("3. Update product");
            Console.WriteLine("4. Delete product");
            Console.WriteLine("5. Logout");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) ShowProducts();
            else if (choice == 2) AddProduct();
            else if (choice == 3) UpdateProduct();
            else if (choice == 4) DeleteProduct();

        } while (choice != 5);
    }

    // ── USER MENU ──

    static void UserMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("\n=== USER MENU ===");
            Console.WriteLine("1. Show all products");
            Console.WriteLine("2. Search product");
            Console.WriteLine("3. Logout");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) ShowProducts();
            else if (choice == 2) SearchProduct();

        } while (choice != 3);
    }

    // ── CRUD FUNCTIONS ─────────────

    static void ShowProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }

        Console.WriteLine("\nID | Name         | Price");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine(products[i].id + "  | " + products[i].name + "  | " + products[i].price);
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter price: ");
        double price = double.Parse(Console.ReadLine());

        Product p = new Product(nextId, name, price);
        nextId++;
        products.Add(p);

        SaveProducts();
        Console.WriteLine("Product added!");
    }

    static void UpdateProduct()
    {
        ShowProducts();
        Console.Write("Enter product ID to update: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].id == id)
            {
                Console.Write("Enter new name: ");
                products[i].name = Console.ReadLine();

                Console.Write("Enter new price: ");
                products[i].price = double.Parse(Console.ReadLine());

                SaveProducts();
                Console.WriteLine("Product updated!");
                return;
            }
        }
        Console.WriteLine("Product not found.");
    }

    static void DeleteProduct()
    {
        ShowProducts();
        Console.Write("Enter product ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].id == id)
            {
                products.RemoveAt(i);
                SaveProducts();
                Console.WriteLine("Product deleted!");
                return;
            }
        }
        Console.WriteLine("Product not found.");
    }

    static void SearchProduct()
    {
        Console.Write("Enter product name to search: ");
        string keyword = Console.ReadLine();

        bool found = false;
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].name.Contains(keyword))
            {
                Console.WriteLine(products[i].id + " | " + products[i].name + " | " + products[i].price);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No product found.");
    }

    // ── FILE FUNCTIONS

    static void SaveUsers()
    {
        StreamWriter sw = new StreamWriter("users.txt");
        for (int i = 0; i < users.Count; i++)
        {
            sw.WriteLine(users[i].username + "," + users[i].password + "," + users[i].role);
        }
        sw.Close();
    }

    static void LoadUsers()
    {
        if (!File.Exists("users.txt")) return;

        StreamReader sr = new StreamReader("users.txt");
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            users.Add(new User(parts[0], parts[1], parts[2]));
        }
        sr.Close();
    }

    static void SaveProducts()
    {
        StreamWriter sw = new StreamWriter("products.txt");
        for (int i = 0; i < products.Count; i++)
        {
            sw.WriteLine(products[i].id + "," + products[i].name + "," + products[i].price);
        }
        sw.Close();
    }

    static void LoadProducts()
    {
        if (!File.Exists("products.txt")) return;

        StreamReader sr = new StreamReader("products.txt");
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            products.Add(new Product(int.Parse(parts[0]), parts[1], double.Parse(parts[2])));
            nextId = int.Parse(parts[0]) + 1;
        }
        sr.Close();
    }
}