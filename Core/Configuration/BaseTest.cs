using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Core.Driver;
using SeleniumTests.Core.Configuration;
using System;

namespace SeleniumTests.Tests
    /// <summary>
    /// Base test class that provides common setup, cleanup, and configuration for all test classes.
    /// Implements IDisposable for proper resource cleanup.
    /// </summary>
{
    public class BaseTest : IDisposable
    {
        /// <summary>
        /// Protected WebDriver instance accessible to all derived test classes
        /// </summary>
        protected IWebDriver Driver;

        /// <summary>
        /// One-time setup method that runs before any tests in the class.
        /// Initializes Allure reporting and creates the WebDriver instance.
        /// </summary>
        [OneTimeSetUp]
        public void InitializeTest()
        {
            Driver = DriverFactory.CreateDriver(BrowserType.Chrome);
        }

        /// <summary>
        /// One-time teardown method that runs after all tests in the class are complete.
        /// Calls Dispose to clean up resources.
        /// </summary>
        [OneTimeTearDown]
        public void CleanupTest()
        {
            Dispose();
        }

        /// <summary>
        /// Implements IDisposable to properly clean up the WebDriver instance.
        /// Takes a screenshot if possible before quitting the driver.
        /// </summary>
        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }

        /// <summary>
        /// Setup method that runs before each individual test.
        /// Navigates to the base URL defined in TestSettings.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl(TestSettings.BaseUrl);
        }
    }
}