using Newtonsoft.Json;
using OstreC.Database;
using OstreC.Services;
using System.Linq;

namespace OstreC.Services
{
   
    //Contains methods to deserialize and serialize Json Files to lists of given type. 
    public static class JsonFile  
    {
/// <summary>
/// Provide character name. It will deserialize it and return a Player object or null if it failed to retrieve it. 
/// </summary>
/// <param name="fileName"></param>
/// <returns></returns>
        public static Player DeserializeCharacter(string fileName)
        {
            bool fileExists = ReaderJson.FileExitsInDirectory("Characters", fileName);
            if (fileExists) 
            {
                string playerFile = ReaderJson.ReadFile(fileName,"Characters");
                Player player = JsonConvert.DeserializeObject<Player>(playerFile);
                return player;
            }  



            return null; 
        }


        /// <summary>
        /// Deserializes given json filename to provided Type. 
        ///Invoke: JsonFile.DeserializeFile<Player>("\\Stories\\ExampleCharacterName");
        /// </summary>
        /// <typeparam name="T">Class you want to deserialize to.</typeparam>
        /// <param name="fileName">Name of json file. </param>
        /// <returns>Object of class T</returns>
        public static T DeserializeFile<T>(string fileName)
        {
            string textFromFile = ReaderJson.ReadFile(fileName);
            return JsonConvert.DeserializeObject<T>(textFromFile);
        }
        /// <summary>
        /// Serializes character and saves him under a new file with character name. 
        /// </summary>
        public static void SerializeCharacter(Player character)
        {
            string dir = ReaderJson.DbDirectory();
            string serializedPlayer = JsonConvert.SerializeObject(character);
            ReaderJson.CreateFile(character.Name,"Characters", ".json");
            SerializedToJson(serializedPlayer, character.Name,"Characters");
   
        }

        public static SaveFile DeserializeSaveFile(string nameFIle)
        {
           
            string textFromFile = ReaderJson.ReadFile(nameFIle);
            SaveFile saveFile = JsonConvert.DeserializeObject<SaveFile>(textFromFile);
            return saveFile;

        }
        public static AllEnemyList DeserializeEnemyList(string nameFIle)
        {
            string textFromFile = ReaderJson.ReadFile(nameFIle);
            AllEnemyList enemyList = JsonConvert.DeserializeObject<AllEnemyList>(textFromFile);
            return enemyList;
        }

         public static UsersList DeserializeUsersList(string nameFile)
        {
            string textFromFile =  ReaderJson.ReadFile(nameFile);
            UsersList UsersList = JsonConvert.DeserializeObject<UsersList>(textFromFile);

            return UsersList;
        }

        public static Story DeserializeStory(string nameFile)
        {
            string textFromFile = ReaderJson.ReadFile("Stories\\"+nameFile);
            Story story = JsonConvert.DeserializeObject<Story>(textFromFile);
            //story.AddAllParagraph();
            return story;
        }

        public static string SerializeUsersList(UsersList usersList)
        {
            string textToFile = JsonConvert.SerializeObject(usersList);
            return textToFile;
        }

        public static string SerializeStory(Story story)
        {
            string textToFile = JsonConvert.SerializeObject(story);
            return textToFile;
        }
        public static string SerializeSaveFile(SaveFile saveFile)
        {
            string textToFile = JsonConvert.SerializeObject(saveFile);
            return textToFile;
        }
        /// <summary>
        /// saves given json string under the given file. Provide 3rd param string yourFolderName for overload. 
        /// </summary>

        public static void SerializedToJson(string serializedObject , string fileName)
        {
            string dir = ReaderJson.DbDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib", fileName + ".json");
            File.WriteAllText(fileNamePath, serializedObject);
        }
        public static void SerializedToJson(string serializedObject, string fileName,string folderName)
        {
            string dir = ReaderJson.DbDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib",folderName, fileName + ".json");
            File.WriteAllText(fileNamePath, serializedObject);
        }
    }
}
