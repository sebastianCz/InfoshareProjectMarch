using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.StoryModels.Enums;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class CreatParagraphTestView
    {
        // ParagraphTest Properties
        public AbilityScores AbilityScores { get; set; }
        public TestDifficulty TestDifficulty { get; set; }

        // General
        public ParagraphType ParagraphType { get; set; }
        public string StageDescription { get; set; }
        public bool RestoreRest { get; set; }
        public int StoryId { get; set; }
    }
}
