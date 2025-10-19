using System;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
    public class Menu
    {
        private static void DisplayMainMenu()
        {
            AnsiConsole.MarkupLine("[bold green underline] Budget Tracker Main Menu [/]");
        }
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
                    //TransactionManager.ViewTransactions();
                    break;
                case "Add Transaction":
                    //TransactionManager.AddTransaction();
                    break;
                case "Delete Transaction":
                    //TransactionManager.DeleteTransaction();
                    break;
                case "View Budget Summary":
                    //BudgetSummary.DisplaySummary();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[bold red]Exiting Budget Tracker. Goodbye![/]");
                    return;
            }
            AnsiConsole.MarkupLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            ShowMainMenu();
            Console.ReadLine();


        }
    }
}
