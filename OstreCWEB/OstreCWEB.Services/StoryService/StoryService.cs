using OstreCWEB.Data.Repository.StoryModels;
using System.Runtime.CompilerServices;

namespace OstreCWEB.Services.StoryService
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;

        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task<IReadOnlyCollection<Story>> GetAllStories()
        {
            return await _storyRepository.GetAllStories();
        }

        public async Task<Story> GetStoryById(int idStory)
        {
            return await _storyRepository.GetStoryById(idStory);
        }

        public async Task<Paragraph> GetParagraphById(int idParagraph)
        {
            return await _storyRepository.GetParagraphById(idParagraph);
        }

        public async Task<IReadOnlyCollection<Paragraph>> GetPreviousParagraphsById(int idParagraph, int idStory)
        {
            var story = await _storyRepository.GetStoryById(idStory);
            return story.Paragraphs.Where(s => s.Choices.Any(c => c.NextParagraphId == idParagraph)).ToList();
        }

        public async Task<IReadOnlyCollection<Paragraph>> GetNextParagraphsById(int idParagraph, int idStory)
        {
            var story = await _storyRepository.GetStoryById(idStory);
            var paragraph = story.Paragraphs.FirstOrDefault(p => p.Id == idParagraph);
            var result = new List<Paragraph>();
            if (paragraph.Choices.Count() != 0)
            {
                foreach (var item in paragraph.Choices)
                {
                    result.Add(story.Paragraphs.FirstOrDefault(p => p.Id == item.NextParagraphId));
                }
            }
            return result;
        }

        //Story

        public async Task AddStory(Story story)
        {
            await _storyRepository.AddStory(story);
        }

        public async Task UpdateStory(int idStory, string Name, string Description)
        {
            var story = await _storyRepository.GetStoryById(idStory);
            story.Name = Name;
            story.Description = Description;

            await _storyRepository.UpdateStory(story);
        }

        public async Task DeleteStory(int idStory)
        {
            var story = await _storyRepository.GetStoryById(idStory);

            await _storyRepository.DeleteStory(story);
        }

        //Paragraph
        public async Task AddParagraph(Paragraph paragraph)
        {
            await _storyRepository.AddParagraph(paragraph);
            var story = await _storyRepository.GetStoryById(paragraph.StoryId);
            if (story.GetAmountOfParagraphs() == 1)
            {
                story.FirstParagraphId = story.Paragraphs[0].Id;
                await _storyRepository.UpdateStory(story);
            }          
        }
    }
}
