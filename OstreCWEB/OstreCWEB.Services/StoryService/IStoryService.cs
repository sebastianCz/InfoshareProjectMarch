using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Services.StoryService
{
    public interface IStoryService
    {
        Task<IReadOnlyCollection<Story>> GetAllStories();
        Task<Story> GetStoryById(int idStory);
        Task<Paragraph> GetParagraphById(int idParagraph);
        Task<IReadOnlyCollection<Paragraph>> GetPreviousParagraphsById(int idParagraph, int idStory);
        Task<IReadOnlyCollection<Paragraph>> GetNextParagraphsById(int idParagraph, int idStory);
        Task UpdateStory(int idStory, string Name, string Description);
        Task AddStory(Story story);
        Task DeleteStory(int idStory);

        Task AddParagraph(Paragraph paragraph);
    }
}
