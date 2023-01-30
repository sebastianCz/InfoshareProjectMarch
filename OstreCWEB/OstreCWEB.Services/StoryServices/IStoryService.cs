using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Services.Models;

namespace OstreCWEB.Services.StoryServices
{
    public interface IStoryService
    {
        //Tools
        public Task<IReadOnlyCollection<Story>> GetAllStories();
        public Task<Story> GetStoryById(int idStory);
        public Task<Story> GetStoryWithParagraphsById(int idStory);
        public Task<Paragraph> GetParagraphById(int idParagraph);
        public Task<IReadOnlyCollection<Paragraph>> GetPreviousParagraphsById(int idParagraph, int idStory);
        public Task<IReadOnlyCollection<Paragraph>> GetNextParagraphsById(int idParagraph, int idStory);

        //Story
        public Task UpdateStory(int idStory, string Name, string Description);
        public Task AddStory(Story story);
        public Task DeleteStory(int idStory);

        //Paragraph
        public Task<ParagraphDetails> GetParagraphDetailsById(int idParagraph, int idStory);
        public Task AddParagraph(Paragraph paragraph);
    }
}
