using OstreCWEB.Data.Repository.StoryModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class ParagraphCreateView
    { 

        [Display(Name = "Paragraph Type")]
        public ParagraphType ParagraphType { get; set; }

        [Display(Name = "Stage Description")]
        public string StageDescription { get; set; }

        public int StoryId { get; set; }
    }
}
