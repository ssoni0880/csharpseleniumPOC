using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

public static class ExcelDataReader
{
    public static IEnumerable<FormData> ReadFormTestData(string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets["FormData"];
            var rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++) // Skip header row
            {
                yield return new FormData
                {
                    Name = worksheet.Cells[row, 1].Value?.ToString(),
                    Email = worksheet.Cells[row, 2].Value?.ToString(),
                    Website = worksheet.Cells[row, 3].Value?.ToString(),
                    Experience = worksheet.Cells[row, 4].Value?.ToString(),
                    Comment = worksheet.Cells[row, 5].Value?.ToString(),
                    FilePath = worksheet.Cells[row, 6].Value?.ToString()
                };
            }
        }
    }

    public static IEnumerable<CountryData> ReadCountryTestData(string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets["CountryData"];
            var rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                yield return new CountryData
                {
                    CountryName = worksheet.Cells[row, 1].Value?.ToString(),
                    ExpectedCode = worksheet.Cells[row, 2].Value?.ToString()
                };
            }
        }
    }
}