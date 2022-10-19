using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace OstreC.Database
{
    public static class ReaderJson
    {
        //Returns the directory of current project. Depends where it gets invoked.
        public static string DbDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory;
        }
        //Returns a string containing the entirety of a Json file.

        public static string ReadFile(string fileName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var fileNamePath = Path.Combine(currentDirectory, "JsonLib", fileName + ".json");
            return File.ReadAllText(fileNamePath);
        }
        //Finds all paths for files inside the given path. Returns array of strings.
        public static string[] FindAllFilesPaths(string relationalPath)
        {
            var dir = DbDirectory();
            string[] allFiles = Directory.GetFiles(dir + relationalPath);
            return allFiles;
        }
        //Same as above method but provides file names without the path. 
        public static string[] FindAllFileNames(string relationalPath)
        {
            var dir = DbDirectory();
            string[] allFiles = Directory.GetFiles(dir + relationalPath);

            for (int i = 0; i < allFiles.Count(); i++)
            {
                allFiles[i] = Path.GetFileName(allFiles[i]).Split(".")[0];
            }

            return allFiles;
        }
    }
}