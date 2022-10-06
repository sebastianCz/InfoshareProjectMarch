namespace OstreC.Services.Stories
{
    public class NextParagraph
    {
        public string ChoiceText { get; set; }
        public int IdParagraph { get; set; }

        public NextParagraph(string choiceText, int idParagraph)
        {
            ChoiceText = choiceText;
            IdParagraph = idParagraph;
        }
    }
}
