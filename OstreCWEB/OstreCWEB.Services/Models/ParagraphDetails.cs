using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Services.Models
{
    public class ParagraphDetails
    {
        public int StoryId { get; set; }
        public string NameOfStory { get; set; }
        public string DescriptionOfStory { get; set; }
        public int AmountOfParagraphs { get; set; }

        public List<ParagraphWithCoice> PreviousParagraphs { get; set; } = new List<ParagraphWithCoice>();
        public Paragraph CurrentParagraphView { get; set; }
        public List<ParagraphWithCoice> NextParagraphs { get; set; } = new List<ParagraphWithCoice>();

        public bool Delete { get; set; }
    }
}
