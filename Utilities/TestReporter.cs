// TestReporter.cs
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace SeleniumTests.Utilities
{
    public class TestReporter
    {
        // Get the project directory path
        private static readonly string _projectDirectory = Directory.GetCurrentDirectory();
        private static readonly string _reportDirectory = Path.Combine(_projectDirectory, "Reports");
        private static readonly string _screenshotDirectory = Path.Combine(_reportDirectory, "Screenshots");
        
        public static void InitializeDirectories()
        {
            // Create directories if they don't exist
            if (!Directory.Exists(_reportDirectory))
                Directory.CreateDirectory(_reportDirectory);
            if (!Directory.Exists(_screenshotDirectory))
                Directory.CreateDirectory(_screenshotDirectory);

            // Create a new report file or clear existing one
            var reportPath = Path.Combine(_reportDirectory, "TestReport.txt");
            File.WriteAllText(reportPath, $"Test Execution Report - {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n");
        }

        public static void CaptureScreenshot(IWebDriver driver, string testName, TestStatus status)
        {
            try
            {
                if (driver == null) return;

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}_{status}.png";
                var filePath = Path.Combine(_screenshotDirectory, fileName);
                
                byte[] screenshotBytes = Convert.FromBase64String(screenshot.AsBase64EncodedString);
                File.WriteAllBytes(filePath, screenshotBytes);
                
                // Add relative path to test context
                var relativePath = Path.GetRelativePath(_projectDirectory, filePath);
                TestContext.AddTestAttachment(filePath, $"Screenshot: {relativePath}");
            }
            catch (Exception ex)
            {
                TestContext.Error.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }

        public static void GenerateTestReport(string testName, TestStatus status, string? errorMessage = null)
        {
            var reportPath = Path.Combine(_reportDirectory, "TestReport.txt");
            var reportEntry = $"""
                Test: {testName}
                Status: {status}
                Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}
                {(!string.IsNullOrEmpty(errorMessage) ? $"Error: {errorMessage}" : string.Empty)}
                ------------------------------------------
                """;

            File.AppendAllText(reportPath, reportEntry + Environment.NewLine);
        }
    }
}