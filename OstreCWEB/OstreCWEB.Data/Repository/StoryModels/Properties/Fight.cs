namespace OstreCWEB.Data.Repository.StoryModels.Properties
{
    public class Fight
    {
        // General
        public int Id { get; set; }
        public List<EnemyInParagraph> ParagraphEnemies { get; set; }

        // Db relations properties
        public int ParagraphId { get; set; }
        public Paragraph Paragraph { get; set; }
    }
}
