# Selenium Automation Framework with C#

## Overview
This project is a test automation framework built using Selenium WebDriver with C#. It follows the Page Object Model (POM) design pattern for better maintainability and reusability of code.

## Project Structure
```
SeleniumTest
├── Core/
│   ├── Configuration/
│   │   ├── BaseTest.cs         # Base test class with common test setup
│   │   └── TestSettings.cs     # Global test settings and configuration
│   └── Driver/
│       ├── BrowserType.cs      # Enum for supported browsers
│       └── DriverFactory.cs    # WebDriver initialization factory
├── Pages/
│   ├── BasePage.cs            # Base page with common page operations
│   ├── CountryDropdownPage.cs # Page object for country dropdown functionality
│   ├── DragAndDropPage.cs     # Page object for drag and drop functionality
│   └── SampleFormPage.cs      # Page object for sample form functionality
├── Tests/
│   ├── CountryDropdownTests.cs # Tests for country dropdown functionality
│   ├── DragAndDropTest.cs     # Tests for drag and drop functionality
│   └── SampleFormTests.cs     # Tests for sample form functionality
└── Utilities/
    ├── Constants.cs           # Project-wide constants
    └── WaitHelpers.cs         # Custom wait utility methods
```

## Prerequisites
- .NET 6.0 or later
- Visual Studio 2019 or later
- Chrome and/or Firefox browser installed

## Setup Instructions

### 1. Clone the Repository
```bash
git clone <repository-url>
cd SeleniumTest
```

### 2. Install NuGet Packages
Open the solution in Visual Studio and restore NuGet packages, or run:
```bash
dotnet restore
```

### 3. Install Required Packages
```bash
dotnet add package Selenium.WebDriver
dotnet add package Selenium.Support
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package WebDriverManager
```

### 4. Configure Test Settings
Update the `TestSettings.cs` file with your desired configuration:
```csharp
public static class TestSettings
{
    public const string BaseUrl = "https://www.globalsqa.com/samplepagetest/";
    public const int DefaultTimeout = 10;
}
```

## Running Tests

### Running Tests from Visual Studio
1. Open Test Explorer (View → Test Explorer)
2. Click "Run All" or run specific tests

### Running Tests from Command Line
```bash
# Run all tests
dotnet test

# Run specific test class
dotnet test --filter "FullyQualifiedName~SeleniumTests.Tests.CountryDropdownTests"

# Run tests with specific category
dotnet test --filter "TestCategory=Smoke"
```

## Framework Features

### 1. Page Object Model
- Each web page has its corresponding page class
- Page classes inherit from BasePage
- All page elements and methods are encapsulated within their respective classes

### 2. Waits and Utilities
- Custom wait helpers for better element handling
- Utility methods for common operations
- Constants class for managing static values

### 3. Cross-Browser Testing
- Supports Chrome and Firefox
- Easily extendable for other browsers
- Browser configuration in DriverFactory

### 4. Base Classes
- BaseTest: Common test setup and teardown
- BasePage: Common page operations and waits

## Test Categories
Tests can be categorized using NUnit attributes:
```csharp
[Test]
[Category("Smoke")]
public void TestMethod() { }
```

## Writing Tests
Example of a test case:
```csharp
[Test]
public void SelectCountry_ShouldSelectCorrectCountry()
{
    string expectedCountry = "India";
    _countryDropdownPage
        .NavigateToDropdownPage()
        .SelectCountry(expectedCountry);
    Assert.That(_countryDropdownPage.GetSelectedCountry(), Is.EqualTo(expectedCountry));
}
```

## Best Practices
1. Follow the Page Object Model pattern
2. Use meaningful names for tests and method
3. Keep tests independent and atomic
4. Use appropriate waits instead of Thread.Sleep
5. Add comments and documentation
6. Follow AAA (Arrange, Act, Assert) pattern in tests

## Troubleshooting

### Common Issues and Solutions

1. **WebDriver initialization fails**
   - Ensure WebDriverManager is properly installed
   - Check browser version compatibility
   - Verify browser installation

2. **Element not found exceptions**
   - Check if locators are correct and unique
   - Verify if sufficient wait time is provided
   - Check if element is in an iframe

3. **Test execution is slow**
   - Review and optimize waits
   - Check for unnecessary delays
   - Verify network connectivity

## Features Implemented
1. Page Object Model Implementation
2. Fluent Interface Design Pattern
3. Cross Browser Testing Support
4. Custom Wait Utilities
5. Reusable Base Classes
6. File Upload Functionality
7. Drag and Drop Operations
8. Form Handling
9. Dropdown Operations

## Test Scenarios Covered
1. Country Dropdown Selection
2. Drag and Drop Operations
3. Sample Form Submission
   - File Upload
   - Form Field Validation
   - Multiple Input Types (text, dropdown, checkboxes, radio buttons)

## Contributing
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request


## Reporting

### NUnit Test Results
The framework uses NUnit's built-in test reporting capabilities. Test results can be generated in various formats:

1. **HTML Report**
```bash
# Install the NUnit.ConsoleRunner package globally
dotnet tool install --global NUnit.ConsoleRunner

# Run tests and generate HTML report
dotnet test --settings:test.runsettings

# For specific test category
nunit3-console.exe "bin/Debug/net6.0/SeleniumTests.dll" --where "cat == Smoke" --result=SmokeTestResults.html;format=nunit3
```#   S e l e n i u m C - 
 
 #   S e l e n i u m C - 
 
 