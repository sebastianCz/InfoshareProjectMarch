using Newtonsoft.Json;
using OstreC.Database;

namespace OstreC.Services
{   
    //Contains methods to deserialize and serialize Json Files to lists of given type. 
    public static class JsonFile  
    {
        /// <summary>
        /// Deserializes given json filename to provided Type. 
        /// Invoke: JsonFile.DeserializeFile<Player>("\\Stories\\ExampleCharacterName");
        /// </summary>
        /// <typeparam name="T">Class you want to deserialize to.</typeparam>
        /// <param name="fileName">Name of json file. </param>
        /// <returns>Object of class T</returns>
        public static T DeserializeFile<T>(string fileName)
        {
            bool fileExists = ReaderJson.FileExitsInDirectory(fileName);
            if (fileExists)
            {
                var textFromFile = ReaderJson.ReadFile(fileName);
                return JsonConvert.DeserializeObject<T>(textFromFile);
            }
            return default;
        }
        /// <summary>
        /// saves given json string under the given file. Provide 3rd param string yourFolderName for overload. 
        /// </summary>
        public static void SerializedToJson<T>(T objectToSerialize, string fileName)
        {
            var dir = ReaderJson.DbDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib", fileName + ".json");
            File.WriteAllText(fileNamePath, JsonConvert.SerializeObject(objectToSerialize));
        }
        public static void DeleteJsonFile(string fileName)
        {
            var dir = ReaderJson.DbDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib", fileName + ".json");
            File.Delete(fileNamePath);
        }
    }
}
