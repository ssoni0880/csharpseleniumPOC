using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests.Pages
{
    public class CountryDropdownPage : BasePage
{
    private readonly By _countryDropdown = By.TagName("select");
    private readonly By _informationText = By.CssSelector("div.information strong");
    private readonly string _pageUrl = "https://www.globalsqa.com/demo-site/select-dropdown-menu/";

    public CountryDropdownPage(IWebDriver driver) : base(driver) { }

    public CountryDropdownPage NavigateToDropdownPage()
    {
        NavigateToUrl(_pageUrl);
        return this;
    }

    public CountryDropdownPage SelectCountry(string countryName)
    {
        SelectDropdownByText(_countryDropdown, countryName);
        return this;
    }

    public CountryDropdownPage SelectCountryByCode(string countryCode)
    {
        var dropdown = new SelectElement(FindElement(_countryDropdown));
        dropdown.SelectByValue(countryCode);
        return this;
    }

    public string GetSelectedCountry()
    {
        var dropdown = new SelectElement(FindElement(_countryDropdown));
        return dropdown.SelectedOption.Text;
    }

    public string GetSelectedCountryCode()
    {
        var dropdown = new SelectElement(FindElement(_countryDropdown));
        return dropdown.SelectedOption.GetAttribute("value");
    }

    public bool IsCountryAvailable(string countryName)
    {
        var dropdown = new SelectElement(FindElement(_countryDropdown));
        return dropdown.Options.Any(option => 
            option.Text.Equals(countryName, StringComparison.OrdinalIgnoreCase));
    }

    public string GetInformationMessage()
    {
        return GetText(_informationText);
    }

    public int GetCountryCount()
    {
        var dropdown = new SelectElement(FindElement(_countryDropdown));
        return dropdown.Options.Count;
    }
}
}