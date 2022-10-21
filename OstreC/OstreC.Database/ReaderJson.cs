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
            var dir = Directory.GetCurrentDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib", fileName + ".json");
            return File.ReadAllText(fileNamePath);
        }
 /// <summary>
 /// Checks if file exists in given directory. It assumes file is in JsonLib
 /// </summary>
 /// <param name="folder">Folder name</param>
 /// <param name="fileName">File name</param>
 /// <returns></returns>
        public static bool FileExitsInDirectory(string folder,string fileName)
        {
            string dir = DbDirectory();
            string filePath = Path.Combine(dir, "JsonLib",folder);
            string[] filesInDirectory = Directory.GetFiles(filePath);
            //If directory is empty LinQ will throw an " value cannot be null " exception
            if(filesInDirectory != null && filesInDirectory.Length != 0)
            {
                var x= filesInDirectory.FirstOrDefault(o => o.Contains(fileName));
               
                if (filesInDirectory.Contains(fileName))
                {
                    return true;

                }; 
            }
            return false;
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