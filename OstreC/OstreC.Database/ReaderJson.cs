using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace OstreC.Database

 
{/// <summary>
/// Contains static methods to help deal with Json files.
/// </summary>
    public static class ReaderJson 
    {
        /// <summary>
        /// Provides the current directory
        /// </summary>
        /// <returns>string with current project directory</returns>
        public static string DbDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory;
        }
        //Returns a string containing the entirety of a Json file.

        /// <summary>
        /// Provide 1 string to read all json file content. Provide 2 strings ( filename + folder name) to read from a specific folder.
        /// </summary>
        /// <returns>String with content of file</returns>
        public static string ReadFile(string fileName)
        {
            var dir = Directory.GetCurrentDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib", fileName + ".json");
            return File.ReadAllText(fileNamePath);
        }
        /// <summary>
        /// Provide 1 string to read all json file content. Provide 2 strings ( filename + folder name) to read from a specific folder.
        /// </summary>
        /// <returns>String with content of file</returns>
        public static string ReadFile(string fileName,string folder)
        {
            var dir = Directory.GetCurrentDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib",folder, fileName + ".json");
            return File.ReadAllText(fileNamePath);
        }

        /// <summary>
        /// Checks if file exists in given directory. It assumes file is in JsonLib
        /// </summary>
        /// <returns>Bool</returns>
        public static bool FileExitsInDirectory(string folder,string fileName)
        {
            string dir = DbDirectory();
            string filePath = Path.Combine(dir, "JsonLib",folder);
            string[] filesInDirectory = Directory.GetFiles(filePath);
            //If directory is empty LinQ will throw an " value cannot be null " exception
            if(filesInDirectory != null && filesInDirectory.Length != 0)
            {
                string path= filesInDirectory.FirstOrDefault(o => o.Contains(fileName));

                if (path != null)
                {
                    bool pathContains = path.Contains(fileName);
                    if (pathContains)
                    {
                        return true;

                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Provide 1 string with the path you want to navigate to .  
        /// </summary>
        /// <param name="relationalPath"></param>
        /// <returns> a string array with all file paths in given directory </returns>
        public static string[] FindAllFilesPaths(string relationalPath)
        {
            var dir = DbDirectory();
            string[] allFiles = Directory.GetFiles(dir + relationalPath);
            return allFiles;
        }
        /// <summary>
        /// Provide 1 string with the path you want to navigate to .  
        /// </summary>
        /// <param name="relationalPath"></param>
        /// <returns> a string array with all file names in given directory</returns>
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
        /// <summary>
        /// Provide 2 string to create a file with given extension. 3 strings to create a file in a folder.
        /// If file with given name exists it will override it. Use carefully. 
        /// </summary>
        public static void CreateFile(string fileName,string extension)
        {
            var dir = Directory.GetCurrentDirectory();
            var path = Path.Combine(dir,"JsonLib", fileName+extension);
            File.Create(path).Close();
        }
        /// <summary>
        /// Provide 2 string to create a file with given extension. 3 strings to create a file in a folder.
        /// If file with given name exists it will override it. Use carefully. 
        /// </summary>
        public static void CreateFile(string fileName,string folder, string extension)
        {
            var dir = Directory.GetCurrentDirectory();
            var path = Path.Combine(dir,"JsonLib", folder,fileName+ extension);
            File.Create(path).Close();
        }
    }
}