using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.ViewModel.StoryBuilder.Properties;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class ParagraphView
    {
        public int Id { get; set; }

        [Display(Name = "Paragraph Type")]
        public ParagraphType ParagraphType { get; set; }

        [Display(Name = "Stage Description")]
        public string StageDescription { get; set; }

        [Display(Name = "Amount Of Choices")]
        public int AmountOfChoices { get; set; }

        // Choice options
        public List<ChoiceView> Choices { get; set; }

        public int StoryId { get; set; }
    }
}
