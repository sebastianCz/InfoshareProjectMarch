
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstreC.Database;
using System.IO;

namespace OstreC.Services
{
    public  class JsonFile
    {


         public static UsersList  Deserialize(string X)
        {
            string x =  ReaderJson.readFile(X);
            UsersList UsersList = JsonConvert.DeserializeObject<UsersList>(x);



            return UsersList;


        }

        public static string Serialize(UsersList x)
        {
            string y = JsonConvert.SerializeObject(x);

            return y;

        }

        public static void arrrayToJson(string serializedObject , string fileName)
        {
             string dir = ReaderJson.dbDirectory();
            var fileNamePath = Path.Combine(dir, "data", fileName + ".json");
            File.WriteAllText(fileNamePath, serializedObject);
        }



    }



}
