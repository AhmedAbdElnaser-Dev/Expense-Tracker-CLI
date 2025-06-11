using System.Reflection;

namespace Expense_Tracker_CLI.Utils
{
    internal class CSVFileHandler<T> where T : class
    {
        public void WriteToCSV(List<T> data)
        {
            string fileName = "expenses.csv";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            
            Console.WriteLine($"Exporting to {filePath}");

            using var writer = new StreamWriter(filePath, false);
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Header
            writer.WriteLine(string.Join(",", properties.Select(p => p.Name)));

            // Rows
            foreach (var item in data)
            {
                var values = properties.Select(p => EscapeCsv(p.GetValue(item)?.ToString() ?? ""));
                writer.WriteLine(string.Join(",", values));
            }
        }

        private string EscapeCsv(string input)
        {
            if (input.Contains(",") || input.Contains("\""))
                return $"\"{input.Replace("\"", "\"\"")}\""; // Escape quotes and wrap in quotes
            return input;
        }
    }
}
