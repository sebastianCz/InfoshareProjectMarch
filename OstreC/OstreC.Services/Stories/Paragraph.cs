namespace OstreC.Services.Stories
{
    public abstract class Paragraph
    {
        public int IdParagraph { get; }
        public string TextParagraph { get; }
        public int HowManyOptions { get { return NextParagraphs.Count(); } }
        public abstract ParagraphType ParagraphType { get; }
        public List<NextParagraph> NextParagraphs { get; } = new List<NextParagraph>();

        public Paragraph(int idParagraph, string textParagraph)
        {
            IdParagraph = idParagraph;
            TextParagraph = textParagraph;
        }

        public void AddNewChoice(NextParagraph newParagraph)
        {
            NextParagraphs.Add(newParagraph);
        }
    }
    public enum ParagraphType
    {
        DescOfStage,
        Fight,
        Dialog,
        Test
    }
}
