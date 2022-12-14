using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;

namespace OstreCWEB.Data.Repository.StoryModels
{
    public class Paragraph
    {
        // General
        public int Id { get; set; }

        public ParagraphType ParagraphType { get; set; }
        public string StageDescription { get; set; }

        // Paragraph type properties
        public Fight? FightProp { get; set; }
        public Dialog? DialogProp { get; set; }
        public Test? TestProp { get; set; }
        public Shopkeeper? ShopkeeperProp { get; set; }

        // Choice options
        public List<NextParagraph> Choices { get; set; }

        // Db relations properties
        public int? FightId { get; set; }
        public int? DialogId { get; set; }
        public int? TestId { get; set; }
        public int? ShopkeeperId { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }

        public int GetAmountOfChoices()
        {
            return Choices.Count();
        }
    }
}
