using NUnit.Framework;
using SeleniumTests.Core.TestData;
using SeleniumTests.Pages;
using System.Collections.Generic;
using SeleniumTests.Utilities;
using System.Linq;

namespace SeleniumTests.Tests
{
    [TestFixture]
    public class SampleFormTests : BaseTest
    {
        private SampleFormPage _sampleFormPage;

        [SetUp]
        public void TestSetup()
        {
            _sampleFormPage = new SampleFormPage(Driver);
        }

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void SubmitSampleForm_WithValidData_ShouldSucceed(FormData testData)
        {
            _sampleFormPage
                .EnterNameWithTab(testData.Name)
                .EnterEmailWithTab(testData.Email)
                .EnterWebsiteWithTab(testData.Website)
                .SelectExperience(testData.Experience)
                .SelectAutomatioTestingExpertise()
                .SelectEducation()
                .EnterComment(testData.Comment)
                .UploadFile(Constants.FileUpload.UploadFilePath)
                .SubmitForm();
        }

        private static IEnumerable<TestCaseData> GetTestData()
        {
            return TestDataProvider.GetFormTestData()
                .Select(data => new TestCaseData(data)
                    .SetName($"Form_Test_{data.Name}"));
        }
    }
}