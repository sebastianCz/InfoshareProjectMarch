namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class ChoiceCreatorView
    {
        public string ChoiceText { get; set; }
        public bool ChangePlaces { get; set; }

        public int ParagraphId { get; set; }
        public ParagraphElementView PreviousParagraph { get; set; }
       
        public int NextParagraphId { get; set; }
        public ParagraphElementView NextParagraph { get; set; }

        public int StoryId { get; set; }
    }
}
