using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Services.StoryServices.Models;

namespace OstreCWEB.Services.StoryServices
{
    public interface IStoryService
    {
        //Tools
        public Task<IReadOnlyCollection<Story>> GetAllStories();
        public Task<IReadOnlyCollection<Story>> GetStoriesByUserId(string userId);
        public Task<Story> GetStoryById(int idStory);
        public Task<Story> GetStoryWithParagraphsById(int idStory);

        //Story
        public Task UpdateStory(int idStory, string Name, string Description, string userId);
        public Task AddStory(Story story, string userId);
        public Task DeleteStory(int idStory, string userId);

        //Paragraph
        public Task<Paragraph> GetParagraphById(int idParagraphId);
        public Task<ParagraphDetails> GetParagraphDetailsById(int idParagraph, int idStory);
        public Task AddParagraph(Paragraph paragraph, string userId);
        public Task<IReadOnlyCollection<Enemy>> GetAllEnemies();
        public Task DeleteParagraph(int idParagraph, string userId);

        //Choice
        public Task<ChoiceDetails> GetChoiceDetailsById(int idChoice);
    }
}
