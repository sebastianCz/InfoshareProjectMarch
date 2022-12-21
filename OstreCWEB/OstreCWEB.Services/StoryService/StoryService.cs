using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Services.StoryService
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;

        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public IReadOnlyCollection<Story> GetAllStories()
        {
            return _storyRepository.GetAllStories();
        }

        public Story GetStoryById(int idStory)
        {
            return _storyRepository.GetStoryById(idStory);
        }

        public Paragraph GetParagraphById(int idParagraph)
        {
            return _storyRepository.GetParagraphById(idParagraph);
        }

        public IReadOnlyCollection<Paragraph> GetPreviousParagraphsById(int idParagraph, int idStory)
        {
            var story = _storyRepository.GetStoryById(idStory);
            return story.Paragraphs.Where(s => s.Choices.Any(c => c.NextParagraphId == idParagraph)).ToList();
        }

        public IReadOnlyCollection<Paragraph> GetNextParagraphsById(int idParagraph, int idStory)
        {
            var story = _storyRepository.GetStoryById(idStory);
            var paragraph = story.Paragraphs.FirstOrDefault(p => p.Id == idParagraph);
            var result = new List<Paragraph>();
            foreach (var item in paragraph.Choices)
            {
                result.Add(story.Paragraphs.FirstOrDefault(p => p.Id == item.NextParagraphId));
            }
            return result;
        }
    }
}
