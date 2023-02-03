using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.StoryModels.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;

namespace OstreCWEB.ViewModel.StoryBuilder
{
    public class EditParagraphView
    {
        public int Id { get; set; }

        public ParagraphType ParagraphType { get; set; }
        public string StageDescription { get; set; }
        public bool RestoreRest { get; set; }

        // Paragraph Fight properties
        public List<EnemyInParagraphView> ParagraphEnemies { get; set; }

        public TestProp? TestProp { get; set; }

        // Db relations properties
        public List<ParagraphItem> ParagraphItems { get; set; }
    }
}
