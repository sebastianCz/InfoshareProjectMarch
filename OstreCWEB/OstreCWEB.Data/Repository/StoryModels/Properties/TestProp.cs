using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.StoryModels.Enums;

namespace OstreCWEB.Data.Repository.StoryModels.Properties
{
    public class TestProp
    {
        // General
        public int Id { get; set; }

        public AbilityScores AbilityScores { get; set; }
        public TestDifficulty TestDifficulty { get; set; }

        // Db relations properties
        public int ParagraphId { get; set; }
        public Paragraph Paragraph { get; set; }
    }
}
