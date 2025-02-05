namespace SeleniumTests.Utilities
{
    [TestFixture]
    public class TestListener
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            TestReporter.InitializeDirectories();
        }

        [TearDown]
        public void AfterTest()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            // Generate report entry
            TestReporter.GenerateTestReport(testName, status, errorMessage);
        }
    }
}