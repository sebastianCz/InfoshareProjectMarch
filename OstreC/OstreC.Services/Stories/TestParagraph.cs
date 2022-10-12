namespace OstreC.Services
{
    public class TestParagraph : Paragraph
    {
        public override ParagraphType ParagraphType => ParagraphType.Test;
        public TestParagraph(int idParagraph, string textParagraph) 
            : base(idParagraph, textParagraph)
        {
            NextParagraphs.Add(new NextParagraph(ParagraphType.DescOfStage, "Go back to menu!", 0));
        }        
    }
}
