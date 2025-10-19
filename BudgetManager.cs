using Microsoft.VisualBasic;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BudgetTracker
{
    public class BudgetManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        // Constructor to initialize with some sample data
        public BudgetManager()
        {
            // Sample transactions
            transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Salary",
                Amount = 25000m,
                Category = "Income"
            });

            // Sample expenses
            transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Rent",
                Amount = -8000m,
                Category = "Bills"
            });

            // Sample expenses
            transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Travel card",
                Amount = -890m,
                Category = "Bills"
            });
        }
        // Method to add a new transaction based on user input
        public void AddTransactionFromInput()
        {
            BudgetManager budgetManager = new BudgetManager();

            Console.Clear();
            AnsiConsole.MarkupLine("[bold green] ADD NEW TRANSACTION [/]");

            //Ask for description
            string description = AnsiConsole.Ask<string>("[grey]Enter description:[/]");

            //Ask for amount (validated numeric input)
            decimal amount = AnsiConsole.Prompt(
                new TextPrompt<decimal>("[grey]Enter amount:[/]")
                    .PromptStyle("green")
                    .Validate(x => x != 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Amount cannot be 0![/]"))
            );

            // Ask for category
            string category = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[grey]Select category[/]")
                    .AddChoices("Food", "Transport", "Bills", "Entertainment")
            );

            //Create transaction
            Transaction newTransaction = new Transaction()
            {
                Date = DateTime.Now,
                Description = description,
                Amount = amount,
                Category = category
            };

            //Add to list
            transactions.Add(newTransaction);

            //Confirmation message
            AnsiConsole.MarkupLine("\n[bold green]Transaction added successfully![/]\n");

            //Display in formatted table
            var table = new Table()
                .Border(TableBorder.Rounded)
                .Title("[bold cyan]Transaction Summary[/]");

            table.AddColumn("[bold]Field[/]");
            table.AddColumn("[bold]Value[/]");
            table.AddRow("Date", newTransaction.Date.ToString("f"));
            table.AddRow("Description", newTransaction.Description);
            table.AddRow("Amount", $"{newTransaction.Amount:C}");
            table.AddRow("Category", newTransaction.Category);

            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("\n[grey]Press any key to return to the menu...[/]");
            Console.ReadKey();
        }

        // Method to get all transactions in the list, put in a table for viewing
        public void ShowAllTransactions()
        {
            TransactionTable.Display(transactions, "All Transactions");
        }

        // Method to display a summary of transactions, such as total income and expenses
        public void SummaryTransactions()
        {
            TransactionTable.DisplaySummary(transactions, "Transaction Summary");
        }

        // Method to delete a transaction from the list
        public void DeleteTransaction()
        {
            // if there is no transactions, return
            if (transactions.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]No transactions available to delete.[/]");
                Console.ReadKey();
                return;
            }

            // creates a list of choices for the user to select from
            var choices = transactions
                .Select((t, index) => $"{index + 1}. {t.Date.ToShortDateString()} | {t.Description} | {t.Amount:C} | {t.Category}")
                .ToList();

            // prompt user to select a transaction to delete
            string selected = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[grey]Select a transaction to delete:[/]")
                    .PageSize(10)
                    .AddChoices(choices)
            );

            // find index of choice
            int indexToDelete = int.Parse(selected.Split('.')[0]) - 1;

            // remove the transaction
            var removed = transactions[indexToDelete];
            transactions.RemoveAt(indexToDelete);

            // confirmation message
            AnsiConsole.MarkupLine($"\n[bold red]Transaction '{removed.Description}' deleted![/]");
            Console.ReadKey();
        }

        
    }
}




