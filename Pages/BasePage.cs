using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Core.Configuration;
using SeleniumTests.Utilities;
using OpenQA.Selenium.Interactions;

namespace SeleniumTests.Pages
{
     /// <summary>
    /// Base page class that provides common functionality for all page objects.
    /// Contains wrapper methods for common Selenium operations with built-in waits and error handling.
    /// </summary>
    public class BasePage
{
    /// <summary>
    /// WebDriver instance for the page
    /// </summary>
    protected readonly IWebDriver Driver;
    /// <summary>
    /// WebDriverWait instance configured with default timeout
    /// </summary>
    protected readonly WebDriverWait Wait;
     /// <summary>
    /// Actions instance for advanced user interactions
    /// </summary>
    protected readonly Actions Actions;

    /// <summary>
    /// Initializes a new instance of the BasePage class.
    /// </summary>
    /// <param name="driver">The WebDriver instance to use for this page</param>
    public BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestSettings.DefaultTimeout));
        Actions = new Actions(driver);
    }
    
    /// <summary>
    /// Finds an element with built-in wait for visibility.
    /// </summary>
    /// <param name="by">The locator to find the element</param>
    /// <returns>The located IWebElement</returns>
    protected IWebElement FindElement(By by) => Driver.WaitUntilElementVisible(by);
    
    protected IReadOnlyCollection<IWebElement> FindElements(By by) => 
        Wait.Until(d => d.FindElements(by));
    
    /// <summary>
    /// Clicks an element with built-in wait.
    /// </summary>
    /// <param name="by">The locator of the element to click</param>
    protected void Click(By by) => FindElement(by).Click();
    
     /// <summary>
    /// Sends keys to an element after clearing its existing value.
    /// </summary>
    /// <param name="by">The locator of the element</param>
    /// <param name="text">The text to send</param>
    protected void SendKeys(By by, string text)
    {
        var element = FindElement(by);
        element.Clear();
        element.SendKeys(text);
    }

    /// <summary>
    /// Sends keys to an element and tabs out of it.
    /// </summary>
    /// <param name="by">The locator of the element</param>
    /// <param name="text">The text to send</param>
    protected void SendKeysWithTab(By by, string text)
    {
        var element = FindElement(by);
        element.Clear();
        element.SendKeys(text + Keys.Tab);
        // Add small delay to ensure tab completion
        WaitForAnimation(100);
    }
    
    /// <summary>
    /// Selects an option from a dropdown by visible text.
    /// </summary>
    /// <param name="by">The locator of the dropdown</param>
    /// <param name="text">The text of the option to select</param>
    protected void SelectDropdownByText(By by, string text)
    {
        var select = new SelectElement(FindElement(by));
        select.SelectByText(text);
    }

    /// <summary>
    /// Gets the text of an element.
    /// </summary>
    /// <param name="by">The locator of the element</param>
    /// <returns>The text of the element</returns>
    protected string GetText(By by) => FindElement(by).Text;

    /// <summary>
    /// Navigates to a specified URL.
    /// </summary>
    /// <param name="url">The URL to navigate to</param>
    protected void NavigateToUrl(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    /// <summary>
    /// Switches to an iframe using a locator.
    /// </summary>
    /// <param name="frameLocator">The locator of the iframe</param>
    protected void SwitchToFrame(By frameLocator)
    {
        var frame = Wait.Until(d => d.FindElement(frameLocator));
        Driver.SwitchTo().Frame(frame);
    }

    /// <summary>
    /// Switches back to the default content from an iframe.
    /// </summary> 
    protected void SwitchToDefaultContent()
    {
        Driver.SwitchTo().DefaultContent();
    }

     /// <summary>
    /// Performs a drag and drop operation.
    /// </summary>
    /// <param name="sourceLocator">The locator of the element to drag</param>
    /// <param name="targetLocator">The locator of the drop target</param>
    protected void DragAndDrop(By sourceLocator, By targetLocator)
    {
        var source = FindElement(sourceLocator);
        var target = FindElement(targetLocator);
        Actions.DragAndDrop(source, target).Perform();
    }

     /// <summary>
    /// Adds a delay to allow animations to complete.
    /// </summary>
    /// <param name="milliseconds">The number of milliseconds to wait</param>
    protected void WaitForAnimation(int milliseconds = 500)
    {
        Thread.Sleep(milliseconds);
    }
    
    /// <summary>
    /// Checks if an element is selected.
    /// </summary>
    /// <param name="by">The locator of the element</param>
    /// <returns>True if the element is selected, false otherwise</returns>
    protected bool IsElementSelected(By by)
    {
        return FindElement(by).Selected;
    }
 
    /// <summary>
    /// Checks if an element is displayed.
    /// </summary>
    /// <param name="by">The locator of the element</param>
    /// <returns>True if the element is displayed, false otherwise</returns>
    protected bool IsElementDisplayed(By by)
    {
        try
        {
            return FindElement(by).Displayed;
        }
        catch (WebDriverException)
        {
            return false;
        }
    }
 }

}