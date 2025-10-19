using Spectre.Console;
using System;
using System.Collections.Generic;

namespace BudgetTracker
{
    public static class TransactionTable
    {
        // Metod för att visa en lista av transaktioner
        public static void Display(List<Transaction> transactions, string title = "Transactions")
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"[bold cyan]=== {title.ToUpper()} ===[/]\n");

            // Check if there are transactions to display
            if (transactions == null || transactions.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]No transactions to display.[/]");
                AnsiConsole.MarkupLine("[grey]Press any key to return...[/]");
                Console.ReadKey();
                return;
            }

            // Create table
            var table = new Table();
            table.Border = TableBorder.Rounded;

            // adding column
            table.AddColumn("Date");
            table.AddColumn("Description");
            table.AddColumn("Amount");
            table.AddColumn("Category");

            // Add rows
            foreach (var t in transactions)
            {
                string amountText = t.Amount >= 0
                    ? $"[green]{t.Amount:C}[/]"
                    : $"[red]{t.Amount:C}[/]";

                table.AddRow(
                    t.Date.ToShortDateString(),
                    t.Description,
                    amountText,
                    t.Category
                );
            }

            // Render table
            AnsiConsole.Write(table);

            // Optional: total amount
            decimal total = transactions.Sum(t => t.Amount);
            string totalText = total >= 0
                ? $"[green]{total:C}[/]"
                : $"[red]{total:C}[/]";

            AnsiConsole.MarkupLine($"\n[grey]Total Amount:[/] {totalText}");
            AnsiConsole.MarkupLine("\n[grey]Press any key to return...[/]");
            Console.ReadKey();

            // Wait for user input before returning
            AnsiConsole.MarkupLine("\n[grey]Press any key to return...[/]");
            Console.ReadKey();
        }
    }
}