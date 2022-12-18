using OstreCWEB.Data.Enums;
using OstreCWEB.Data.Repository.StoryModels.Enums;

namespace OstreCWEB.ViewModel.StoryBuilder.Properties
{
    public class TestPropView
    {
        public int Id { get; set; }

        public Skills Skill { get; set; }
        public TestDifficulty TestDifficulty { get; set; }
    }
}
