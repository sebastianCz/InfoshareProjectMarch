using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.Data.Repository.StoryModels;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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
        public Fight? FightProp { get; set; }
        public Dialog? DialogProp { get; set; }
        public Test? TestProp { get; set; }
        public Shopkeeper? ShopkeeperProp { get; set; }

        // Choice options
        public List<NextParagraph> Choices { get; set; } = new List<NextParagraph>();
    }
}
