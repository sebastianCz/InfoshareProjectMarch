namespace OstreC.Services
{
    //Object in each paragraph. Contains the information about what should be the next paragraph to select, and the text shown to user. 
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
