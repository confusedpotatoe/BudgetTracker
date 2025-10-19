using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BudgetTracker
{
    public class Menu
    {
        private static void DisplayMainMenu()
        {
            AnsiConsole.MarkupLine("[bold green underline] Budget Tracker Main Menu [/]");
        }

        private static BudgetManager budgetManager = new BudgetManager();

        public static void ShowMainMenu()
        {
            AnsiConsole.Clear();
            DisplayMainMenu();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[grey]Select an option:[/]")
                    .AddChoices(new[] {
                        "View Transactions",
                        "Add Transaction",
                        "Delete Transaction",
                        "View Budget Summary",
                        "Exit"
                    }));
            
            switch (choice)
            {
                case "View Transactions":
                    budgetManager.ShowAllTransactions();
                    break;

                case "Add Transaction":
                    budgetManager.AddTransactionFromInput();
                    break;

                case "Delete Transaction":
                    budgetManager.DeleteTransaction();
                    break;

                case "View Budget Summary":
                    //BudgetSummary.DisplaySummary();
                    break;

                case "Exit":
                    AnsiConsole.MarkupLine("[bold red]Exiting Budget Tracker. Goodbye![/]");
                    return;
            }

            ShowMainMenu();
            Console.ReadLine();


        }
    }
}
