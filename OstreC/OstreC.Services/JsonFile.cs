using Newtonsoft.Json;
using OstreC.Database;
using OstreC.Services;

namespace OstreC.Services
{
    public  class JsonFile
    {
         public static UsersList DeserializeUsersList(string nameFile)
        {
            string textFromFile =  ReaderJson.readFile(nameFile);
            UsersList UsersList = JsonConvert.DeserializeObject<UsersList>(textFromFile);

            return UsersList;
        }

        public static Story DeserializeStory(string nameFile)
        {
            string textFromFile = ReaderJson.readFile(nameFile);
            Story story = JsonConvert.DeserializeObject<Story>(textFromFile);
            story.AddAllParagraph();
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

        public static void serializedToJson(string serializedObject , string fileName)
        {
            string dir = ReaderJson.dbDirectory();
            var fileNamePath = Path.Combine(dir, "JsonLib", fileName + ".json");
            File.WriteAllText(fileNamePath, serializedObject);
        }
    }
}
