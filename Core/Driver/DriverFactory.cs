using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTests.Core.Driver
{
    /// <summary>
    /// Factory class responsible for creating and configuring WebDriver instances.
    /// Supports multiple browser types and handles driver setup.
    /// </summary>
    public class DriverFactory
    {
        /// <summary>
        /// Creates and configures a new WebDriver instance based on the specified browser type.
        /// </summary>
        /// <param name="browserType">The type of browser to create (Chrome or Firefox)</param>
        /// <returns>Configured IWebDriver instance</returns>
        /// <exception cref="ArgumentException">Thrown when WebDriver creation fails</exception>
        public static IWebDriver CreateDriver(BrowserType browserType)
{
    IWebDriver? driver = null;
    
    switch (browserType)
    {
        case BrowserType.Chrome:
         // Setup ChromeDriver using WebDriverManager
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            break;
            
        case BrowserType.Firefox:
        // Setup FirefoxDriver using WebDriverManager
            new DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            break;
    }
    
    if (driver == null)
    {
        throw new ArgumentException("Failed to create WebDriver instance");
    }
    
    // Configure browser window and timeouts
    driver.Manage().Window.Maximize();
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    return driver;
}
    }
}