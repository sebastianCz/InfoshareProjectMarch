using OstreCWEB.Data.Repository.StoryModels;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class StoryDetailsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ParagraphView> ParagraphsView { get; set; } = new List<ParagraphView>();

        [Display(Name = "Amount Of Paragraphs")]
        public int AmountOfParagraphs { get; set; }

    }
}
