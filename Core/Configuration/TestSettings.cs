namespace SeleniumTests.Core.Configuration
{
    /// <summary>
    /// Static class containing global test configuration settings.
    /// Provides centralized access to common test parameters.
    /// </summary>
    public static class TestSettings
    {   
        /// <summary>
        /// The base URL for the test application.
        /// All test navigation will start from this URL.
        /// </summary>  
        public const string BaseUrl = "https://www.globalsqa.com/samplepagetest/";
        /// <summary>
        /// Default timeout value in seconds for wait operations.
        /// Used across the framework for explicit and implicit waits.
        /// </summary>
        public const int DefaultTimeout = 10;
    }
}