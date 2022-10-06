namespace OstreC.Services.Stories
{
    public class DescOfStage : Paragraph
    {
        public sealed override ParagraphType ParagraphType => ParagraphType.DescOfStage;
        public DescOfStage(int idParagraph, string textParagraph) 
            : base(idParagraph, textParagraph)
        {
        }
    }
}
