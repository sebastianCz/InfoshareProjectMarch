namespace OstreC.Services
{
    public class DescOfStage : Paragraph
    {
        public sealed override ParagraphType ParagraphType => ParagraphType.DescOfStage;
        public DescOfStage(int idParagraph, string textParagraph) 
            : base(idParagraph, textParagraph)
        {
            NextParagraphs.Add(new NextParagraph(ParagraphType.DescOfStage, "Go back to menu!", 0));
        }
    }
}
