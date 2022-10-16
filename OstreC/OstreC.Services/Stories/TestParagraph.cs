namespace OstreC.Services
{
    //Paragraph used to make a dice roll. For instance a perception test dice roll. 
    public class TestParagraph : Paragraph
    {
        public override ParagraphType ParagraphType => ParagraphType.Test;
        public TestParagraph(int idParagraph, string? textParagraph = "") 
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
