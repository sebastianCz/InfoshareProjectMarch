namespace OstreC.Services
{
    //Type of paragraph
    public class DialogParagraph : Paragraph
    {
        public override ParagraphType ParagraphType => ParagraphType.Dialog;
        public DialogParagraph(int idParagraph, string textParagraph = "")
            : base(idParagraph, textParagraph)
        { 
        }
        public void DefaultChoice()
        {
            NextParagraphs.Add(new NextParagraph(ParagraphType.DescOfStage, "Go back to menu!", 0));
        }
        public void AddNewChoice(NextParagraph newChioce)
        {
            NextParagraphs.Add(newChioce);
        }
    }
}
 