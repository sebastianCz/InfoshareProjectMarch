namespace OstreC.Services.Stories
{
    public class Story
    {
        public string NameOfStory { get; private set; }
        public int AmountOfParagrafh { get { return Paragraphs.Count(); } }
        public List<Paragraph> Paragraphs { get; } = new List<Paragraph>();

        public List<FightParagraph> FightParagraphs { get; } = new List<FightParagraph>();

        //public List<TestParagraph> TestParagraphs { get; } = new List<TestParagraph>();
        //public List<DialogParagraph> DialogParagraphs { get; } = new List<DialogParagraph>();
        public List<DescOfStage> DescOfStages { get; } = new List<DescOfStage>();

        public void ChangeNameOfStory(string nameOfStory)
        {
            NameOfStory = nameOfStory;
        }

        public void AddNewFightParagraph(FightParagraph newFightParagraph)
        {
            Paragraphs.Add(newFightParagraph);
            FightParagraphs.Add(newFightParagraph);
        }

        public void AddNewFightPDescOfStage(DescOfStage newDescOfStage)
        {
            Paragraphs.Add(newDescOfStage);
            DescOfStages.Add(newDescOfStage);
        }
    }
}
