namespace OstreCWEB.ViewModel.StoryReader
{
    public class GameStageView
    {
        public CurrentParagraphView CurrentParagraph { get; set; }
        public CurrentCharacterView CurrentCharacter { get; set; }
        public TestParagraphView TestParagraphView { get; set; }

        public bool Rest { get; set; }
    }
}
