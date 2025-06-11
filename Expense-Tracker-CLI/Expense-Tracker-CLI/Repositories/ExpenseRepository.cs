using Expense_Tracker_CLI.Models;

namespace Expense_Tracker_CLI.Repositories
{
    internal class ExpenseRepository : IExpenseRepository
    {
        private readonly List<Expense> expenses = new();

        public void Add(Expense expense)
        {
            expense.Id = NextId();
            expenses.Add(expense);
        }

        public void Update(int id, Expense updatedExpense)
        {
            var index = expenses.FindIndex(e => e.Id == id);
            if (index >= 0)
            {
                updatedExpense.Id = id;
                expenses[index] = updatedExpense;
            }
        }

        public void Delete(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expenses.Remove(expense);
            }
        }

        public List<Expense> GetAll() => expenses;

        public Expense? GetById(int id) =>
            expenses.FirstOrDefault(e => e.Id == id);

        public List<Expense> GetByMonth(int month) =>
            expenses.Where(e => e.Date.Month == month).ToList();

        public decimal GetTotal() =>
            expenses.Sum(e => e.Amount);

        public decimal GetTotalByMonth(int month) =>
            expenses.Where(e => e.Date.Month == month).Sum(e => e.Amount);

        public int NextId() =>
            expenses.Count == 0 ? 1 : expenses.Max(e => e.Id) + 1;
    }
}
