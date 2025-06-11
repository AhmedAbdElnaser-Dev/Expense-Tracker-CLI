using Expense_Tracker_CLI.Models;
using Expense_Tracker_CLI.Repositories;
using Expense_Tracker_CLI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker_CLI.Services
{
    internal class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public void AddExpense()
        {
            Console.Write("Enter description: ");
            string? desc = Console.ReadLine();

            Console.Write("Enter amount: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);

            Console.Write("Enter date (yyyy-mm-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);

            var expense = new Expense(_repository.NextId(), desc ?? "", amount, date);
            _repository.Add(expense);
            Console.WriteLine("Expense added.");
        }

        public void UpdateExpense()
        {
            Console.Write("Enter ID to update: ");
            int.TryParse(Console.ReadLine(), out int id);
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("Expense not found.");
                return;
            }

            Console.Write("Enter new description: ");
            string? desc = Console.ReadLine();

            Console.Write("Enter new amount: ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);

            Console.Write("Enter new date (yyyy-mm-dd): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);

            var updated = new Expense(id, desc ?? "", amount, date);
            _repository.Update(id, updated);
            Console.WriteLine("Expense updated.");
        }

        public void DeleteExpense()
        {
            Console.Write("Enter ID to delete: ");
            int.TryParse(Console.ReadLine(), out int id);
            _repository.Delete(id);
            Console.WriteLine("Expense deleted.");
        }

        public void ViewAllExpenses()
        {
            var all = _repository.GetAll();
            if (all.Count == 0)
            {
                Console.WriteLine("No expenses found.");
                return;
            }

            foreach (var e in all)
                Console.WriteLine(e);
        }

        public void ViewExpensesByMonth()
        {
            Console.Write("Enter month (1-12): ");
            int.TryParse(Console.ReadLine(), out int month);
            var byMonth = _repository.GetByMonth(month);

            foreach (var e in byMonth)
                Console.WriteLine(e);

            Console.WriteLine($"Total: {_repository.GetTotalByMonth(month):C}");
        }

        public void ViewTotalExpenses()
        {
            Console.WriteLine($"Total spent: {_repository.GetTotal():C}");
        }

        public void SaveToCSV()
        {
            var expenses = _repository.GetAll();
            var csvHandler = new CSVFileHandler<Expense>();
            csvHandler.WriteToCSV(expenses);
            Console.WriteLine("Exported to expenses.csv");
        }
    }
}
