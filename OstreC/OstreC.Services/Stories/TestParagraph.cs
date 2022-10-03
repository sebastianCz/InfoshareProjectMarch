namespace OstreC.Services.Stories
{
    internal class TestParagraph : Paragraph
    {
        public override ParagraphType ParagraphType => ParagraphType.Test;
        public TestParagraph(int idParagraph, string textParagraph) 
            : base(idParagraph, textParagraph)
        {
        }        
    }
}
