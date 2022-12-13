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
        public Fight? Fight { get; set; }
        public Dialog? Dialog { get; set; }
        public Test? Test { get; set; }
        public Shopkeeper? Shopkeeper { get; set; }

        // Choice options
        public List<NextParagraph> Choices { get; set; }

        // Db relations properties
        public int? FightId { get; set; }
        public int? DialogId { get; set; }
        public int? TestId { get; set; }
        public int? ShopkeeperId { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
