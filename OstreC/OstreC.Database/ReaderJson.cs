namespace OstreC.Database
{
    /// <summary>
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
        /// Checks if file exists in given directory. It assumes file is in JsonLib
        /// </summary>
        /// <returns>Bool</returns>
        public static bool FileExitsInDirectory(string fileName)
        {
            string dir = DbDirectory();
            string filePath = Path.Combine(dir, "JsonLib", fileName + ".json");
            return File.Exists(filePath);
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
    }
}