using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker_CLI.Services
{
    internal interface IExpenseService
    {
        void AddExpense();
        void UpdateExpense();
        void DeleteExpense();
        void ViewAllExpenses();
        void ViewExpensesByMonth();
        void ViewTotalExpenses();
        void SaveToCSV();
    }
}
