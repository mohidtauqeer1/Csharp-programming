



using System;
using System.Collections.Generic;
using System.IO;

namespace task6
{

    class MUser
    {
        public string Username;
        public string Password;
        public string Role;

        public MUser(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }

    class UserSystem
    {
        static List<MUser> users = new List<MUser>();
        static string filePath = "users.txt";
        static void LoadFromFile()
        {
            if (!File.Exists(filePath)) return;
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                    users.Add(new MUser(parts[0], parts[1], parts[2]));
            }
            Console.WriteLine(users.Count + " users loadedfrom file.");
        }
        static void SaveToFile(MUser u)
        {
            File.AppendAllText(filePath, u.Username + "," + u.Password + "," + u.Role + "\n");
        }

        static void SignUp()
        {
            Console.Write("Enter username : "); string username = Console.ReadLine();
            foreach (MUser u in users)
                if (u.Username == username) { Console.WriteLine("Username already taken!"); return; }

            Console.Write("Enter password : "); string password = Console.ReadLine();
            Console.Write("Enter role (Admin/User): "); string role = Console.ReadLine();

            MUser newUser = new MUser(username, password, role);
            users.Add(newUser);
            SaveToFile(newUser);
            Console.WriteLine("Sign up successful! Welcome, " + username);
        }

        static void SignIn()
        {
            Console.Write("Enter username : "); string username = Console.ReadLine();
            Console.Write("Enter password : "); string password = Console.ReadLine();

            foreach (MUser u in users)
            {
                if (u.Username == username && u.Password == password)
                {
                    Console.WriteLine("Login successful! Welcome, " + u.Username + " [" + u.Role + "]");
                    return;
                }
            }
            Console.WriteLine("Invalid username or password!");
        }

        static void Main(string[] args)
        {
            LoadFromFile();

            int choice;
            do
            {
                Console.WriteLine("\n User System ");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: SignUp(); break;
                    case 2: SignIn(); break;
                    case 0: Console.WriteLine("Goodbye"); break;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            } while (choice != 0);
        }
    }
}