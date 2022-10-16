namespace OstreC.Services
{
    //Type of paragraph
    public class DescOfStage : Paragraph
    {
        public sealed override ParagraphType ParagraphType => ParagraphType.DescOfStage;
        public DescOfStage(int idParagraph, string textParagraph = "") 
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
