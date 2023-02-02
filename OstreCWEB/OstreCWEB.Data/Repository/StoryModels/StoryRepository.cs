using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.StoryModels.Enums;

#nullable disable

namespace OstreCWEB.Data.Repository.StoryModels
{
    internal class StoryRepository : IStoryRepository
    {
        private readonly OstreCWebContext _ostreCWebContext;

        public StoryRepository(OstreCWebContext ostreCWebContext)
        {
            _ostreCWebContext = ostreCWebContext;
        }

        public bool Exists(int storyId)
        {
            return _ostreCWebContext.Stories.Any(story => story.Id == storyId);
        }
        public async Task<IReadOnlyCollection<Story>> GetAllStories()
        {
            return _ostreCWebContext.Stories
                .Include(s => s.Paragraphs)
                .ToList();
        }

        public async Task<Story> GetStoryById(int idStory)
        {
            return _ostreCWebContext.Stories
                .Include(s => s.Paragraphs)
                    .ThenInclude(p => p.Choices)
                .Include(s => s.Paragraphs)
                    .ThenInclude(p => p.FightProp)
                        .ThenInclude(f => f.ParagraphEnemies)
                .Include(s => s.Paragraphs)
                    .ThenInclude(p => p.DialogProp)
                .Include(s => s.Paragraphs)
                    .ThenInclude(p => p.TestProp)
                .Include(s => s.Paragraphs)
                    .ThenInclude(p => p.ShopkeeperProp)
                .SingleOrDefault(s => s.Id == idStory);
        }
        public async Task<Story> GetStoryNoIncludesAsync(int storyId)
        {
            return await _ostreCWebContext.Stories.SingleOrDefaultAsync(s => s.Id == storyId);
        }

        public async Task<Paragraph> GetParagraphById(int idParagraph)
        { 
            return _ostreCWebContext.Paragraphs
                .Include(p => p.paragraphItems)
                .SingleOrDefault(p => p.Id == idParagraph);
        }
        public async Task<Paragraph> GetCombatParagraphById(int idParagraph)
        {
            return await _ostreCWebContext.Paragraphs
                            .Include(p => p.FightProp)
                            .SingleOrDefaultAsync();
        }
        public async Task AddStory(Story story)
        {
            _ostreCWebContext.Stories.Add(story);
            await _ostreCWebContext.SaveChangesAsync();
        }

        public async Task UpdateStory(Story story)
        {
            _ostreCWebContext.Stories.Update(story);
            await _ostreCWebContext.SaveChangesAsync();
        }

        public async Task DeleteStory(Story story)
        {
            _ostreCWebContext.Stories.Remove(story);
            await _ostreCWebContext.SaveChangesAsync();
        }

        public async Task AddParagraph(Paragraph paragraph)
        {
            _ostreCWebContext.Paragraphs.Add(paragraph);
            await _ostreCWebContext.SaveChangesAsync();
        }

    }
}
