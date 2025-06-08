using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

namespace EmployeeReportApp
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }

    public class CompanySettings
    {
        public decimal BonusThreshold { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Read employees from CSV
                var employees = ReadEmployeesFromCsv("employees.csv");

                // 2. Read settings from JSON
                var settings = ReadSettingsFromJson("settings.json");

                // 3. Filter high earners
                var highEarners = employees.FindAll(e => e.Salary >= settings.BonusThreshold);

                // 4. Write report
                WriteReport("high_earners.txt", highEarners);
                Console.WriteLine("Report written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        static List<Employee> ReadEmployeesFromCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return new List<Employee>(csv.GetRecords<Employee>());
            }
        }

        static CompanySettings ReadSettingsFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<CompanySettings>(json);
        }

        static void WriteReport(string filePath, List<Employee> employees)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var emp in employees)
                {
                    writer.WriteLine($"{emp.Name} ({emp.Department}) - ${emp.Salary:F2}");
                }
            }
        }
    }
}
