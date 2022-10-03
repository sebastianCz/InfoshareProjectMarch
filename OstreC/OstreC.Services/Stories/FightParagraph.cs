namespace OstreC.Services.Stories
{
    internal class FightParagraph : Paragraph
    {
        public override ParagraphType ParagraphType => ParagraphType.Fight;
        public FightParagraph(int idParagraph, string textParagraph) 
            : base(idParagraph, textParagraph)
        {
        }
    }
}
