using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Utilities
{
    public static class WaitHelpers
    {
        public static IWebElement WaitUntilElementVisible(this IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => {
                var element = drv.FindElement(by);
                return element.Displayed ? element : null;
            });
        }
    }
}