using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
  
    internal class Program
    {
        class Transaction
        {
            public int TransactionId;
            public string TransactionName;
            public double Amount;
            public DateTime DateTime;

            public Transaction()
            {
                TransactionId = 0;
                TransactionName = "unknown";
                Amount = 0;
                DateTime = DateTime.Now;
            }
            public Transaction(Transaction transaction)
            {
                TransactionId = transaction.TransactionId;
                TransactionName = transaction.TransactionName;
                Amount = transaction.Amount;
                DateTime = transaction.DateTime;
            }
        }
        

        static void Main(string[] args)
        {
            Transaction t=new Transaction();
            t.TransactionId = 1;
            t.TransactionName = "nano";
            t.Amount = 1000;    
            t.DateTime = DateTime.Now;
            Console.WriteLine("TransactionId="+t.TransactionId);
            Console.WriteLine("TransactionName=" + t.TransactionName);

            Console.WriteLine("Amount=" + t.Amount);
            Console.WriteLine("DateTime=" + t.DateTime);

        }
    }
}
