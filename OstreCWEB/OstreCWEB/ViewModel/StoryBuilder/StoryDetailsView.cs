using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class StoryDetailsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Amount Of Paragraphs")]
        public int AmountOfParagraphs { get; set; }

        public List<ParagraphView> PreviousParagraphs { get; set; } = new List<ParagraphView>();
        public ParagraphView CurrentParagraphView { get; set; }
        public List<ParagraphView> NextParagraphs { get; set; } = new List<ParagraphView>();

        public int FirstParagraphId { get; set; }
    }
}
