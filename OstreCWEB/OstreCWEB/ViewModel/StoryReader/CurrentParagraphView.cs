using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;

namespace OstreCWEB.ViewModel.StoryReader
{
    public class CurrentParagraphView
    {
        public ParagraphType ParagraphType { get; set; }
        public string StageDescription { get; set; }
        public List<CurrentChoicesView> Choices { get; set; }
    }
}
