namespace OstreC.Services.Stories
{
    internal class Story
    {
        public string NameOfStory { get; }
        public int AmountOfParagrafh { get { return Paragraphs.Count(); } }
        public List<Object> Paragraphs { get; } = new List<Object>();

        //public List<FightParagraph> FightParagraphs { get; } = new List<FightParagraph>();
        //public List<TestParagraph> TestParagraphs { get; } = new List<TestParagraph>();
        //public List<DialogParagraph> DialogParagraphs { get; } = new List<DialogParagraph>();
        //public List<DescOfStage> DescOfStages { get; } = new List<DescOfStage>();

        public Story(string nameOfStory)
        {
            NameOfStory = nameOfStory;
        }

        public void AddNewParagraph(Object newParagraph)
        {
            Paragraphs.Add(newParagraph);
        }
    }
}
