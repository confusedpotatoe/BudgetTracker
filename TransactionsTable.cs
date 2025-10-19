using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Transactions;

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

            //total amount
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

        // Method to show summary of transactions
        public static void DisplaySummary( List<Transaction> transactions, string Tital = "summary")
        {

            Console.Clear();
            AnsiConsole.MarkupLine("[bold cyan] SUMMARY OF TRANSACTIONS [/]\n");

            // Check if there are transactions
            if (transactions == null || transactions.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]No transactions available.[/]");
                Console.ReadKey();
                return;
            }

            // Seperates incomes and expenses
            var incomes = transactions.Where(t => t.Amount >= 0).ToList();
            var expenses = transactions.Where(t => t.Amount < 0).ToList();

            //Incomes table
            AnsiConsole.MarkupLine("[bold green]INCOMES[/]");
            if (incomes.Count == 0)
            {
                AnsiConsole.MarkupLine("  [grey]No incomes[/]");
            }
            else
            {
                var incomeTable = new Table();
                incomeTable.Border = TableBorder.Rounded;
                incomeTable.AddColumn("Date");
                incomeTable.AddColumn("Description");
                incomeTable.AddColumn("Amount");

                foreach (var t in incomes)
                {
                    incomeTable.AddRow(
                        t.Date.ToShortDateString(),
                        t.Description,
                        $"[green]{t.Amount:C}[/]"
                    );
                }

                AnsiConsole.Write(incomeTable);
                decimal totalIncome = incomes.Sum(t => t.Amount);
                AnsiConsole.MarkupLine($"[bold green]Total Income:[/] [green]{totalIncome:C}[/]\n");
            }

            //Expenses table
            AnsiConsole.MarkupLine("[bold red]EXPENSES[/]");
            if (expenses.Count == 0)
            {
                AnsiConsole.MarkupLine("  [grey]No expenses[/]");
            }
            else
            {
                var expenseTable = new Table();
                expenseTable.Border = TableBorder.Rounded;
                expenseTable.AddColumn("Date");
                expenseTable.AddColumn("Description");
                expenseTable.AddColumn("Amount");

                foreach (var t in expenses)
                {
                    expenseTable.AddRow(
                        t.Date.ToShortDateString(),
                        t.Description,
                        $"[red]{t.Amount:C}[/]"
                    );
                }

                AnsiConsole.Write(expenseTable);
                decimal totalExpenses = expenses.Sum(t => t.Amount);
                AnsiConsole.MarkupLine($"[bold red]Total Expenses:[/] [red]{totalExpenses:C}[/]\n");
            }

            //Last calculation of net total
            decimal net = incomes.Sum(t => t.Amount) + expenses.Sum(t => t.Amount);
            string netText = net >= 0 ? $"[green]{net:C}[/]" : $"[red]{net:C}[/]";
            AnsiConsole.MarkupLine($"[grey]Net Total:[/] {netText}");

            // Wait for user input before returning
            AnsiConsole.MarkupLine("\n[grey]Press any key to return...[/]");
            Console.ReadKey();
        }
    }
}