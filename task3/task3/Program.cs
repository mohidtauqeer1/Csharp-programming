using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Program
    {
        class ATM
        {
            private double balance;
            private List<string> transactionHistory;

            public ATM(double initialBalance)
            {
                balance = initialBalance;
                transactionHistory = new List<string>();
                Console.WriteLine("Initial Balance is " + balance);
            }
            public void deposit(double amount) {
                balance += amount;
                transactionHistory.Add("Deposited: " + amount);
                Console.WriteLine("Amount deposited successfully.");
            }
            public void withdraw(double amount)
            {
                if (amount <= balance)
                {
                    balance-= amount;
                    transactionHistory.Add("Deposited: " + amount);
                    Console.WriteLine("Amount deposited successfully.");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            public void checkbalance()
            {
                Console.WriteLine("Current Balance: " + balance);
            }
            public void ShowTransactionHistory()
            {
                Console.WriteLine("\nTransaction History:");
                foreach (string transaction in transactionHistory)
                {
                    Console.WriteLine(transaction);
                }
            }
        }
        static void Main(string[] args)
        {
            ATM atm = new ATM(1000);
            atm.deposit(500);
            atm.withdraw(200);
            atm.checkbalance();
            atm.ShowTransactionHistory();
        }
    }
    }
}
