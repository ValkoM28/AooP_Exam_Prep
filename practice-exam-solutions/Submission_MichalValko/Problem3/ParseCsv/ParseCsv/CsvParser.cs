using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace ParseCsv;

public static class CsvParser
{
    
    public static List<Comic> LoadData(string csvFilePath)
    {

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };

        using StreamReader reader = new(csvFilePath);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<Comic>().ToList();
        return records; 
    }


}