using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeleniumTests.Core.TestData
{
    public static class TestDataProvider
    {
        private static readonly string DataFile;
        private static Dictionary<string, object> _cachedData = new();

        static TestDataProvider()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            // Get the project directory path
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, "..", "..", ".."));
            DataFile = Path.Combine(projectDirectory, "TestData", "TestData.xlsx");

            if (!File.Exists(DataFile))
            {
                throw new FileNotFoundException($"Test data file not found at: {DataFile}");
            }

            LoadAllTestData();
        }

        private static void LoadAllTestData()
        {
            using var package = new ExcelPackage(new FileInfo(DataFile));
            LoadFormData(package);
            LoadCountryData(package);
        }

        private static void LoadFormData(ExcelPackage package)
        {
            var worksheet = package.Workbook.Worksheets["FormData"];
            if (worksheet == null)
            {
                throw new InvalidOperationException("FormData worksheet not found");
            }

            var formDataList = new List<FormData>();
            var rowCount = worksheet.Dimension?.Rows ?? 0;

            for (int row = 2; row <= rowCount; row++) // Skip header row
            {
                var formData = new FormData
                {
                    Name = worksheet.Cells[row, 1].Text,
                    Email = worksheet.Cells[row, 2].Text,
                    Website = worksheet.Cells[row, 3].Text,
                    Experience = worksheet.Cells[row, 4].Text,
                    Comment = worksheet.Cells[row, 5].Text,
                    FilePath = worksheet.Cells[row, 6].Text
                };
                formDataList.Add(formData);
            }

            _cachedData["FormData"] = formDataList;
        }

        private static void LoadCountryData(ExcelPackage package)
        {
            var worksheet = package.Workbook.Worksheets["CountryData"];
            if (worksheet == null)
            {
                throw new InvalidOperationException("CountryData worksheet not found");
            }

            var countryDataList = new List<CountryData>();
            var rowCount = worksheet.Dimension?.Rows ?? 0;

            for (int row = 2; row <= rowCount; row++)
            {
                var countryData = new CountryData
                {
                    CountryName = worksheet.Cells[row, 1].Text,
                    ExpectedCode = worksheet.Cells[row, 2].Text
                };
                countryDataList.Add(countryData);
            }

            _cachedData["CountryData"] = countryDataList;
        }

        public static IEnumerable<FormData> GetFormTestData()
        {
            return (_cachedData.TryGetValue("FormData", out var data) ? data as List<FormData> : null) ?? new List<FormData>();
        }

        public static IEnumerable<CountryData> GetCountryTestData()
        {
            return (_cachedData.TryGetValue("CountryData", out var data) ? data as List<CountryData> : null) ?? new List<CountryData>();
        }

        public static FormData? GetFormDataByName(string name)
        {
            return GetFormTestData().FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static CountryData? GetCountryDataByName(string countryName)
        {
            return GetCountryTestData().FirstOrDefault(d => d.CountryName.Equals(countryName, StringComparison.OrdinalIgnoreCase));
        }
    }
}