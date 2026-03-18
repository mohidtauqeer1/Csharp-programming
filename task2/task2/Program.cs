using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        class Calculator
        {
            public int add(int a, int b)
            {
                return a + b; 
            }
            public int sub(int a, int b)
            {
                return a - b;
            }
            public int mul(int a, int b)
            {
                return a * b;
            }
            public int div(int a, int b)
            {
                return a/b;
            }
            public Calculator(int a, int b)
            {
                Console.WriteLine("Addition: " + calculator.add(a, b));
                Console.WriteLine("Subtraction: " + sub(a, b));
                Console.WriteLine("Multiplication: " + mul(a, b));
                Console.WriteLine("Division: " + div(a, b));
            }
        }
        
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator(10, 5);
            Console.WriteLine("ADDITION: " + calculator.add(10, 5));
            Console.WriteLine("SUBTRACTION: " + calculator.sub(10, 5));
            Console.WriteLine("MULTIPLY: " + calculator.mul(10, 5));
            Console.WriteLine("DIVIDE: " + calculator.div(10, 5));
        }
    }
}
