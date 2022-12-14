using OstreCWEB.Data.Repository.StoryModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class ParagraphView
    {
        public int Id { get; set; }

        public ParagraphType ParagraphType { get; set; }
        public string StageDescription { get; set; }

        [Display(Name = "Amount Of Paragraphs")]
        public int AmountOfChoices { get; set; }

        public StoryView Story { get; set; }
    }
}
