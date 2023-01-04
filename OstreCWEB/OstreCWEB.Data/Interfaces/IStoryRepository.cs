using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Data.Interfaces
{
    public interface IStoryRepository
    {
        Task<IReadOnlyCollection<Story>> GetAllStories();
        Task<Story> GetStoryById(int idStory);
        Task<Paragraph> GetParagraphById(int idParagraph);

        Task UpdateStory(Story story);
        Task AddStory(Story story);
        Task DeleteStory(Story story);
        
        Task AddParagraph(Paragraph paragraph);
    }
}
