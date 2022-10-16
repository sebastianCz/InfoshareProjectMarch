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
    }
}