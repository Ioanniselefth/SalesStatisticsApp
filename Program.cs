using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SalesStatisticsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Sales Statistics Application =====");
            
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            Console.Write("Enter delimiter (default ##): ");
            string delimiter = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(delimiter)) delimiter = "##";

            Console.Write("Enter date format (default dd/MM/yyyy): ");
            string dateFormat = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(dateFormat)) dateFormat = "dd/MM/yyyy";

            Console.WriteLine("Loading data...");
            var sales = LoadSales(filePath, delimiter, dateFormat);

            if (sales.Count == 0)
            {
                Console.WriteLine("No data found. Exiting...");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Average earnings for a range of years");
                Console.WriteLine("2. Standard deviation within a specific year");
                Console.WriteLine("3. Standard deviation for a range of years");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter start year: ");
                        int startAvg = int.Parse(Console.ReadLine());
                        Console.Write("Enter end year: ");
                        int endAvg = int.Parse(Console.ReadLine());
                        var avg = AverageForRange(sales, startAvg, endAvg);
                        Console.WriteLine($"Average earnings ({startAvg}-{endAvg}): {avg:F2}");
                        break;

                    case "2":
                        Console.Write("Enter year: ");
                        int year = int.Parse(Console.ReadLine());
                        var stdYear = StdDevForYear(sales, year);
                        Console.WriteLine($"Standard deviation for {year}: {stdYear:F2}");
                        break;

                    case "3":
                        Console.Write("Enter start year: ");
                        int startStd = int.Parse(Console.ReadLine());
                        Console.Write("Enter end year: ");
                        int endStd = int.Parse(Console.ReadLine());
                        var stdRange = StdDevForRange(sales, startStd, endStd);
                        Console.WriteLine($"Standard deviation ({startStd}-{endStd}): {stdRange:F2}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        // Load sales from file
        static List<(DateTime Date, double Amount)> LoadSales(string filePath, string delimiter, string dateFormat)
        {
            var sales = new List<(DateTime, double)>();
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(new string[] { delimiter }, StringSplitOptions.None);
                if (parts.Length != 2) continue;

                if (DateTime.TryParseExact(parts[0], dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date)
                    && double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double amount))
                {
                    sales.Add((date, amount));
                }
            }
            return sales;
        }

        static double AverageForRange(List<(DateTime Date, double Amount)> sales, int startYear, int endYear)
        {
            var filtered = sales.Where(s => s.Date.Year >= startYear && s.Date.Year <= endYear).Select(s => s.Amount);
            return filtered.Any() ? filtered.Average() : 0.0;
        }

        static double StdDevForYear(List<(DateTime Date, double Amount)> sales, int year)
        {
            var filtered = sales.Where(s => s.Date.Year == year).Select(s => s.Amount).ToList();
            return CalculateStdDev(filtered);
        }

        static double StdDevForRange(List<(DateTime Date, double Amount)> sales, int startYear, int endYear)
        {
            var filtered = sales.Where(s => s.Date.Year >= startYear && s.Date.Year <= endYear).Select(s => s.Amount).ToList();
            return CalculateStdDev(filtered);
        }

        static double CalculateStdDev(List<double> values)
        {
            if (values.Count == 0) return 0.0;
            double avg = values.Average();
            double sumSqDiff = values.Sum(v => (v - avg) * (v - avg));
            return Math.Sqrt(sumSqDiff / values.Count);
        }
    }
}
