using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
    public class Transaction
    {     
        // Properties of the Transaction.
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }

        // Constructor to initialize a Transaction object.
        public Transaction(DateTime date, string description, decimal amount, string category)
        {
            Date = date;
            Description = description;
            Amount = amount;
            Category = category;
        }

        public Transaction()
        {
        }

        // Method to display the transaction details.
        public void Display()
        {
            Console.WriteLine($"{Date.ToShortDateString()} | {Description} | {Amount:C} | {Category}");
        }

    }
}
