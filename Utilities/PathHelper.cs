using System;
using System.IO;

namespace SeleniumTests.Utilities
{
    public static class PathHelper
    {
        public static string GetProjectRootPath()
        {
            // Get the current directory where the test is running
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            
            // Navigate up to the project root (3 levels up from bin/Debug/net8.0)
            return Path.GetFullPath(Path.Combine(baseDirectory, "..", "..", ".."));
        }

        public static string GetAbsolutePath(string relativePath)
        {
            // Remove leading ./ or .\ if present
            relativePath = relativePath.TrimStart('.', '\\', '/');
            
            // Combine project root with the relative path
            string fullPath = Path.Combine(GetProjectRootPath(), relativePath);
            
            // Verify the file exists
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"File not found at path: {fullPath}");
            }

            return fullPath;
        }
    }
}