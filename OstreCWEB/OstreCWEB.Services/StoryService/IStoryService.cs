using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Services.StoryService
{
    public interface IStoryService
    {
        //Tools
        Task<IReadOnlyCollection<Story>> GetAllStories();
        Task<Story> GetStoryById(int idStory);
        Task<Paragraph> GetParagraphById(int idParagraph);
        Task<IReadOnlyCollection<Paragraph>> GetPreviousParagraphsById(int idParagraph, int idStory);
        Task<IReadOnlyCollection<Paragraph>> GetNextParagraphsById(int idParagraph, int idStory);

        //Story
        Task UpdateStory(int idStory, string Name, string Description);
        Task AddStory(Story story);
        Task DeleteStory(int idStory);

        //Paragraph
        Task AddParagraph(Paragraph paragraph);
    }
}
