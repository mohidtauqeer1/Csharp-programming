using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizza_points
{
    internal class Program
    {
        static void Main(string[] args)
        {
            pizza_points(5, 20);
        }

        static void pizza_points(int minorders, int minprice)
        {
            string path = "C:\\Users\\mohid\\OneDrive\\Desktop\\tasks\\tasks\\ConsoleApp8.txt";

            if (File.Exists(path) == false)
            {
                Console.WriteLine("file not found");
                return;
            }

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                string[] parts = line.Split(' ');

                string name = parts[0];
                int totalorders = int.Parse(parts[1]);
                int start = line.IndexOf('[');
                int end = line.IndexOf(']');

                string pricespart = line.Substring(start + 1, end - start - 1);

                string[] prices = pricespart.Split(',');

                int count = 0;

                for (int j = 0; j < prices.Length; j++)
                {
                    int price = int.Parse(prices[j].Trim());

                    if (price >= minprice)
                    {
                        count = count + 1;
                    }
                }

                if (totalorders >= minorders && count >= minorders)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}

