using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class StoriesView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Amount Of Paragraphs")]
        public int AmountOfParagraphs { get; set; }
    }
}
