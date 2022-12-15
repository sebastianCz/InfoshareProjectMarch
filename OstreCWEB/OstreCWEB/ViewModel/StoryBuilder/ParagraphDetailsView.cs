using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.ViewModel.StoryBuilder.Properties;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class ParagraphDetailsView
    {
        public int Id { get; set; }

        [Display(Name = "Paragraph Type")]
        public ParagraphType ParagraphType { get; set; }

        [Display(Name = "Stage Description")]
        public string StageDescription { get; set; }

        // Paragraph type properties
        public FightPropView? FightPropView { get; set; }
        public TestPropView? TestPropView { get; set; }

        // Choice options
        public List<NextParagraph> Choices { get; set; } = new List<NextParagraph>();
    }
}
