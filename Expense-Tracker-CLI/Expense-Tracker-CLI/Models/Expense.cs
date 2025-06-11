using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker_CLI.Models
{
    internal class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        private static int counter = 0;

        public Expense(int id, string description, decimal amount, DateTime date)
        {
            Id = ++counter;
            Description = description;
            Amount = amount;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Id}: {Description} - {Amount:C} on {Date.ToShortDateString()}";
        }
    }
}
