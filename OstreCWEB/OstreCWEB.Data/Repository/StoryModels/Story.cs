namespace OstreCWEB.Data.Repository.StoryModels
{
    public class Story
    {
        // General
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public int FirstParagraphId { get; set; }

        // DB
        public int UserId { get; set; }
    }
}
