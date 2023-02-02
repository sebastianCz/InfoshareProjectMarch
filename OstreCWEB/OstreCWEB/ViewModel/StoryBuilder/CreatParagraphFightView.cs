using OstreCWEB.Data.Repository.StoryModels.Enums;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class CreatParagraphFightView
    {
        // ParagraphFight Properties
        public int EnemyId { get; set; }
        public int AmountOfEnemy { get; set; }

        // General
        public ParagraphType ParagraphType { get; set; }
        public string StageDescription { get; set; }
        public bool RestoreRest { get; set; }
        public int StoryId { get; set; }
    }
}
