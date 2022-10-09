namespace OstreC.Database
{
    public static class ReaderJson
    {


        public static string dbDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory;
        }

          public static string readFile(string fileName)
        {

            var currentDirectory = Directory.GetCurrentDirectory();
            var fileNamePath = Path.Combine(currentDirectory, "data", fileName + ".json");

            return File.ReadAllText(fileNamePath);
        }
    }
}