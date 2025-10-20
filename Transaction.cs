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
            // Validate string inputs
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty.");

            // validate category input string
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty.");

            // validate amount to insure it's not zero
            if (amount == 0)
                throw new ArgumentException("Amount cannot be zero.");

            Date = date;
            Description = description;
            Amount = amount;
            Category = category;
        }

        // Default constructor.
        public Transaction()
        {
        }
    }
}
