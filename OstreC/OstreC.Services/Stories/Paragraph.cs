using Newtonsoft.Json;

namespace OstreC.Services
{
    //Main Paragraph object. 
    public abstract class Paragraph
    {
        public int IdParagraph { get; }
        public string TextParagraph { get; }
        [JsonIgnore]
        public int AmountOfOptions { get { return NextParagraphs.Count(); } }
        public abstract ParagraphType ParagraphType { get; }
        public List<NextParagraph> NextParagraphs { get; } = new List<NextParagraph>();

        public Paragraph(int idParagraph, string textParagraph = "")
        {
            IdParagraph = idParagraph;
            TextParagraph = textParagraph;
        }
    }
    public enum ParagraphType
    {
        DescOfStage = 0,
        Fight = 1,
        Dialog = 2,
        Test = 3
    }
}
