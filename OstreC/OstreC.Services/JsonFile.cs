using Newtonsoft.Json;
using OstreC.Database;
using OstreC.Services;
using System.Linq;

namespace OstreC.Services
{
    //Contains methods to deserialize and serialize Json Files to lists of given type. 
    public static class JsonFile
    {

        public static Player DeserializeCharacter(string name)
        {
            var dir = ReaderJson.ReadFile(name);
            Player player = JsonConvert.DeserializeObject<Player>(name);
            
            return player;
        }
        public static bool SerializeCharacter(Player player)
        {
            string dir = ReaderJson.DbDirectory() + "\\JsonLib\\Characters\\" ;
            string serializedPlayer = JsonConvert.SerializeObject(player);
           
            if (ReaderJson.FindAllFilesPaths("\\JsonLib\\Characters\\")[0].Contains(player.Name)) ;
                        File.Create(dir+"\\"+ player.Name+".json").Close();

            SerializedToJson(serializedPlayer,player.Name);

            return true;
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

        public static void SerializedToJson(string serializedObject , string fileName)
        {
            string dir = ReaderJson.DbDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib", fileName + ".json");
            File.WriteAllText(fileNamePath, serializedObject);
        }
        public static void SerializedToJson(string serializedObject, string fileName,string folderName)
        {
            string dir = ReaderJson.DbDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib\\"+folderName, fileName + ".json");
            File.WriteAllText(fileNamePath, serializedObject);
        }
    }
}
