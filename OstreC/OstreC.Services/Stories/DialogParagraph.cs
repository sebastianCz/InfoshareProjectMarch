namespace OstreC.Services
{
    public class DialogParagraph : Paragraph
    {
        public override ParagraphType ParagraphType => ParagraphType.Dialog;
        public DialogParagraph(int idParagraph, string textParagraph) 
            : base(idParagraph, textParagraph)
        {
            NextParagraphs.Add(new NextParagraph(ParagraphType.DescOfStage, "Go back to menu!", 0));
        }
    }
}
 