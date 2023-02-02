using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.StoryModels.Enums;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class CreatNewParagraphView
    {
        // General
        public ParagraphType ParagraphType { get; set; }
        public string StageDescription { get; set; }
        public bool RestoreRest { get; set; }

        // Choice Properties
        //public string ChoiceText { get; set; }
        //public int NextParagraphId { get; set; }

        // Items Properties

        //public int AmountOfItems { get; set; }
        //public int ItemId { get; set; }

        // Story relations
        public int StoryId { get; set; }
    }
}
