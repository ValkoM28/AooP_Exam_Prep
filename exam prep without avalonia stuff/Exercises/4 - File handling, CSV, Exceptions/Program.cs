using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;

namespace EmployeeReportApp
{
    // TODO: Create Employee class with Name, Department, Salary
    // TODO: Create CompanySettings class with BonusThreshold (decimal)

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // TODO: Read employees from "employees.csv"
                // TODO: Read company settings from "settings.json"
                // TODO: Filter high earners and write report to "high_earners.txt"
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }
    }
}
