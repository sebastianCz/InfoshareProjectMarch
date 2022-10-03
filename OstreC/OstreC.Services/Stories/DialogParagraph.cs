namespace OstreC.Services.Stories
{
    internal class DialogParagraph : Paragraph
    {
        public override ParagraphType ParagraphType => ParagraphType.Dialog;
        public DialogParagraph(int idParagraph, string textParagraph) 
            : base(idParagraph, textParagraph)
        {
        }
    }
}
