using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

public static class CsvDataReader
{
    public static IEnumerable<FormData> ReadFormTestData(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<FormData>().ToList();
        }
    }

    public static IEnumerable<CountryData> ReadCountryTestData(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<CountryData>().ToList();
        }
    }
}