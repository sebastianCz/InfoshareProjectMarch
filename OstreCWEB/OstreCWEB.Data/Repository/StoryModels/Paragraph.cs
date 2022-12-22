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
        public FightProp? FightProp { get; set; }
        public DialogProp? DialogProp { get; set; }
        public TestProp? TestProp { get; set; }
        public ShopkeeperProp? ShopkeeperProp { get; set; }

        // Choice options
        public List<Choice> Choices { get; set; } = new List<Choice>();

        // Db relations properties
        public int StoryId { get; set; }
        public Story Story { get; set; }

        public int GetAmountOfChoices()
        {
            return Choices.Count();
        }
    }
}
