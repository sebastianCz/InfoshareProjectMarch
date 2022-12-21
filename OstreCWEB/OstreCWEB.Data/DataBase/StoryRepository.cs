using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Data.DataBase
{
    public class StoryRepository : IStoryRepository
    {
        private readonly OstreCWebContext _ostreCWebContext;

        public StoryRepository(OstreCWebContext ostreCWebContext)
        {
            _ostreCWebContext = ostreCWebContext;
        }

        public IReadOnlyCollection<Story> GetAllStories()
        {
            return _ostreCWebContext.Stories
                .Include(s => s.Paragraphs)
                .ToList();
        }

        public Story GetStoryById(int idStory)
        {
            return _ostreCWebContext.Stories
                .Include(s => s.Paragraphs)
                    .ThenInclude(p => p.Choices)
                .SingleOrDefault(s => s.Id == idStory);
        }

        public Paragraph GetParagraphById(int idParagraph)
        {
            return _ostreCWebContext.Paragraphs
                .SingleOrDefault(p => p.Id == idParagraph);
        }
    }
}
