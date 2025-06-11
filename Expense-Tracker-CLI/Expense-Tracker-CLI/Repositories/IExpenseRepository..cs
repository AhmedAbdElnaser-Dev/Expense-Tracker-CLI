using Expense_Tracker_CLI.Models;

namespace Expense_Tracker_CLI.Repositories
{
    internal interface IExpenseRepository
    {
        void Add(Expense expense);
        void Update(int id, Expense expense);
        void Delete(int id);
        List<Expense> GetAll();
        Expense? GetById(int id);
        List<Expense> GetByMonth(int month);
        decimal GetTotal();
        decimal GetTotalByMonth(int month);
        int NextId();
    }
}
