using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Services.StoryService
{
    public interface IStoryService
    {
        public IReadOnlyCollection<Story> GetAllStories();
        public Story GetStoryById(int idStory);
        public IReadOnlyCollection<Paragraph> GetParagraphsById(int idStory);
        public Paragraph GetParagraphById(int idParagraph);
        public IReadOnlyCollection<Paragraph> GetPreviousParagraphsById(int idParagraph, int idStory);
        public IReadOnlyCollection<Paragraph> GetNextParagraphsById(int idParagraph, int idStory);
    }
}
