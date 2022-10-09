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
            //string projectName = "OstreC.Database\\Data\\bin\\debug\\net";

            //string solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //string solutiondir2 = Directory.GetParent(solutiondir).Parent.FullName;
            //string solutiondir3 = solutiondir2 + "\\" + projectName + "\\" + fileName + extension;
 
            var currentDirectory = Directory.GetCurrentDirectory();
            var fileNamePath = Path.Combine(currentDirectory, "data", fileName+ ".json");
             

       
            return File.ReadAllText(fileNamePath);


        }

        

    }
}