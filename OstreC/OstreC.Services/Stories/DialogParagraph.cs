namespace OstreC.Services
{
    public class DialogParagraph : Paragraph
    {
        public override ParagraphType ParagraphType => ParagraphType.Dialog;
        public DialogParagraph(int idParagraph, string textParagraph) 
            : base(idParagraph, textParagraph)
        {
        }
    }
}
 