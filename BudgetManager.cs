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

            if (category == "Other")
            {
                category = AnsiConsole.Ask<string>("[grey]Enter custom category:[/]");
            }

            //Create transaction
            Transaction newTransaction = new Transaction()
            {
                Date = DateTime.Now,
                Description = description,
                Amount = amount,
                Category = category
            };

            // 🔹 Add to list
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
    }
}

