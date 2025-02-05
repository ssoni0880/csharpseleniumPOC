namespace SeleniumTests.Utilities
{
    public static class Constants
    {
        public static class FileUpload
        {
            private const string RelativeFilePath = "TestData/photo.avif";
            
            public static string UploadFilePath 
            { 
                get { return PathHelper.GetAbsolutePath(RelativeFilePath); }
            }
        }
    }
}