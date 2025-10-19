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
        // Display the main menu header
        private static void DisplayMainMenu()
        {
            AnsiConsole.MarkupLine("[bold green underline] Budget Tracker Main Menu [/]");
        }

        // Instance of BudgetManager to handle budget operations
        private static BudgetManager budgetManager = new BudgetManager();

        // Show the main menu and handle user selections
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
                // Handle each menu option
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
                    budgetManager.SummaryTransactions();
                    break;

                case "Exit":
                    AnsiConsole.MarkupLine("[bold red]Exiting Budget Tracker. Goodbye![/]");
                    return;
            }

            // Return to main menu after completing an action
            ShowMainMenu();
            Console.ReadLine();


        }
    }
}
