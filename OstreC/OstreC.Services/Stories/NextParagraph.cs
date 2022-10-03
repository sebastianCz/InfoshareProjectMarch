namespace OstreC.Services.Stories
{
    internal class NextParagraph
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
