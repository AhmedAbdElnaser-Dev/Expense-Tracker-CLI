using Expense_Tracker_CLI.Repositories;
using Expense_Tracker_CLI.Services;

namespace Expense_Tracker_CLI
{
    internal class Program
    {
        private readonly IExpenseService _service;

        public Program(IExpenseService service)
        {
            _service = service;
        }

        static void Main(string[] args)
        {
            IExpenseRepository repository = new ExpenseRepository();
            IExpenseService service = new ExpenseService(repository);
            var app = new Program(service);
            app.Run();
        }

        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                Console.Write("Select an option: ");
                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1": _service.AddExpense(); break;
                    case "2": _service.UpdateExpense(); break;
                    case "3": _service.DeleteExpense(); break;
                    case "4": _service.ViewAllExpenses(); break;
                    case "5": _service.ViewExpensesByMonth(); break;
                    case "6": _service.ViewTotalExpenses(); break;
                    case "7": _service.SaveToCSV(); break;
                    case "8": return;
                    default: Console.WriteLine("Invalid option.\n"); break;
                }
                Console.WriteLine();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("===== Expense Tracker Menu =====");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. Update Expense");
            Console.WriteLine("3. Delete Expense");
            Console.WriteLine("4. View All Expenses");
            Console.WriteLine("5. View Expenses by Month");
            Console.WriteLine("6. View Total Expenses");
            Console.WriteLine("7. Save to CSV file");
            Console.WriteLine("8. Exit");
            Console.WriteLine("================================");
        }
    }
}
