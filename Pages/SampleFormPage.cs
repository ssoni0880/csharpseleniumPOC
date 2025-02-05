using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumTests.Pages
{
    public class SampleFormPage : BasePage
{
    protected readonly By _fileUploadInput = By.Name("file-553");
    protected readonly By _nameField = By.Id("g2599-name");
    protected readonly By _emailField = By.Id("g2599-email");
    protected readonly By _websiteField = By.Id("g2599-website");
    protected readonly By _experienceDropdown = By.Id("g2599-experienceinyears");
    protected readonly By _expertiseCheckboxes = By.CssSelector("input[name='g2599-expertise[]']");
    protected readonly By _educationRadios = By.CssSelector("input[name='g2599-education']");
    protected readonly By _commentBox = By.CssSelector("textarea[id*='contact-form-comment']");
    protected readonly By _submitButton = By.CssSelector("button.pushbutton-wide");
    protected readonly By _formResponse = By.XPath("//div[contains(@id, 'contact-form-')]/h3");

    public SampleFormPage(IWebDriver driver) : base(driver) { }

    public SampleFormPage UploadFile(string filePath)
    {
        SendKeys(_fileUploadInput, filePath);
        return this;
    }

    public SampleFormPage EnterNameWithTab(string name)
    {
        SendKeysWithTab(_nameField, name);
        return this;
    }

    public SampleFormPage EnterEmailWithTab(string email)
    {
        SendKeysWithTab(_emailField, email);
        return this;
    }

    public SampleFormPage EnterWebsiteWithTab(string website)
    {
        SendKeysWithTab(_websiteField, website);
        return this;
    }

    public SampleFormPage SelectExperience(string years)
    {
        SelectDropdownByText(_experienceDropdown, years);
        return this;
    }

    public SampleFormPage SelectAutomatioTestingExpertise()
    {
        // Find the checkbox element associated with the expertise using XPath
        var checkbox = FindElement(By.XPath("//label[@class='grunion-checkbox-multiple-label checkbox-multiple'][2]/input[@class='checkbox-multiple']"));

        // If the checkbox is not already selected, click it
        if (checkbox != null && !checkbox.Selected)
        {
            checkbox.Click();
        }

        return this;
    }

    public SampleFormPage SelectEducation()
    {
    // Find the radio button associated with the given education using XPath
    var radioButton = FindElement(By.XPath("//label[@class='grunion-radio-label radio'][2]/input[@class='radio']"));

    // If the radio button is found and is not selected, click it
    if (radioButton != null && !radioButton.Selected)
    {
        radioButton.Click();
    }

    return this;
   }

    public SampleFormPage EnterComment(string comment)
    {
        SendKeys(_commentBox, comment);
        return this;
    }

    public bool IsFieldFocused(By by)
    {
        return Driver.SwitchTo().ActiveElement().Equals(FindElement(by));
    }

    public void SubmitForm()
    {
        Click(_submitButton);
        Wait.Until(drv => IsElementDisplayed(_formResponse));
    }
}
}