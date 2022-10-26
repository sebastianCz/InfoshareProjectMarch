using Newtonsoft.Json;

namespace OstreC.Services
{
    //Story object. Contains all paragraphs for a given story. 
    public class Story
    {
        public string NameOfStory { get; private set; }
        [JsonIgnore]
        public int AmountOfParagrafh { get { return FightParagraphs.Count() + TestParagraphs.Count() + DialogParagraphs.Count() + DescOfStages.Count(); } }
        public List<FightParagraph> FightParagraphs { get; } = new List<FightParagraph>();
        public List<TestParagraph> TestParagraphs { get; } = new List<TestParagraph>();
        public List<DialogParagraph> DialogParagraphs { get; } = new List<DialogParagraph>();
        public List<DescOfStage> DescOfStages { get; } = new List<DescOfStage>();

        public Story(string nameOfStory)
        {
            NameOfStory = nameOfStory;
        }

        public void DeafaultParagraph()
        {
            DescOfStage menu = new DescOfStage(0, "menu");
            DescOfStage dead = new DescOfStage(1, "dead");

            menu.DefaultChoice();
            dead.DefaultChoice();

            DescOfStages.Add(menu);
            DescOfStages.Add(dead);
        }

        public void AddNewDescOfStageParagraph(DescOfStage newDescOfStage)
        {
            DescOfStages.Add(newDescOfStage);
        }
        public void AddNewFightParagraph(FightParagraph newFightParagraph)
        {
            FightParagraphs.Add(newFightParagraph);
        }
        public void AddNewDialogParagraph(DialogParagraph newDialogParagraph)
        {
            DialogParagraphs.Add(newDialogParagraph);
        }
        public void AddNewTestParagraph(TestParagraph newTestParagraph)
        {
            TestParagraphs.Add(newTestParagraph);
        }
    }
}
