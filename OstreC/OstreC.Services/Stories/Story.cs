namespace OstreC.Services.Stories
{
    internal class Story
    {
        public string NameOfStory { get; }
        public int AmountOfParagrafh { get { return Paragraphs.Count(); } }
        public List<Paragraph> Paragraphs { get; } = new List<Paragraph>();

        public Story(string nameOfStory)
        {
            NameOfStory = nameOfStory;
        }

        public void AddNewParagraph(Paragraph newParagraph)
        {
            Paragraphs.Add(newParagraph);
        }
    }
}
