// // Tests/CountryDropdownTests.cs
// using NUnit.Framework;
// using SeleniumTests.Core.TestData;
// using SeleniumTests.Pages;
// using System.Collections.Generic;
// using System.Linq;

// namespace SeleniumTests.Tests
// {
//     [TestFixture]
//     public class CountryDropdownTests : BaseTest
//     {
//         private CountryDropdownPage _countryDropdownPage;

//         [SetUp]
//         public void TestSetup()
//         {
//             _countryDropdownPage = new CountryDropdownPage(Driver);
//         }

//         [Test]
//         [TestCaseSource(nameof(GetTestData))]
//         public void SelectCountry_ShouldSelectCorrectCountry(CountryData testData)
//         {
//             _countryDropdownPage
//                 .NavigateToDropdownPage()
//                 .SelectCountry(testData.CountryName);

//             Assert.That(_countryDropdownPage.GetSelectedCountry(), Is.EqualTo(testData.CountryName));
//             Assert.That(_countryDropdownPage.GetSelectedCountryCode(), Is.EqualTo(testData.ExpectedCode));
//         }

//         private static IEnumerable<TestCaseData> GetTestData()
//         {
//             return TestDataProvider.GetCountryTestData()
//                 .Select(data => new TestCaseData(data)
//                     .SetName($"Country_Test_{data.CountryName}"));
//         }
//     }
// }
