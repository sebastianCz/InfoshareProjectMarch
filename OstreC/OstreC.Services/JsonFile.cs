
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
    public static class JsonFile
    {


        //I asumme all Json files are under Data.S
        public static string deserializeJsonFile(string fileName)
        {
            string projectName = "OstreC.Database\\Data";
            string extension = ".json";
            string solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string solutiondir2 = Directory.GetParent(solutiondir).Parent.FullName;
            string solutiondir3 = solutiondir2 + "\\" + projectName + "\\" + fileName + extension;


            var x = File.ReadAllText(solutiondir3);
            return x;


        }




    }



}
