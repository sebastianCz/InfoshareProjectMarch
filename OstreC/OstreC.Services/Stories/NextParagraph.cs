namespace OstreC.Services
{
    public class NextParagraph
    {
        public ParagraphType ParagraphType { get; }
        public string ChoiceText { get; set; }
        public int IdParagraph { get; set; }

        public NextParagraph(ParagraphType paragraphType, string choiceText, int idParagraph)
        {
            ParagraphType = paragraphType;
            ChoiceText = choiceText;
            IdParagraph = idParagraph;
        }
    }
}
