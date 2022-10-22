using Newtonsoft.Json;

namespace OstreC.Services
{ 
    public class SaveFile
    {
        public ParagraphType ActiveParagraphType { get; set; }
        public int ActiveParagraph { get; set; }
        public string NameOfStory { get; set; }
        public string LinkedCharacter { get; set; }//String including the name of the chosen character.Exists under UI.GameSession when story is launched. 

        public int HealthPoints { get; set; }
        public string CharacterName { get; set; }

        [JsonIgnore]
        public Story CurrentStory { get; private set; }
        public SaveFile(ParagraphType activeParagraphType, int activeParagraph, string nameOfStory)
        {
            ActiveParagraphType = activeParagraphType;
            ActiveParagraph = activeParagraph;
            NameOfStory = nameOfStory;
            CurrentStory = LoadStory(NameOfStory);
        }
        private static Story LoadStory(string nameOfStory)
        {
            return JsonFile.DeserializeStory(nameOfStory);
        }
    }
}
