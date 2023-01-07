using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Data.DataBase
{
    public class UserParagraphRepostiory : IUserParagraphRepostiory
    {
        private readonly OstreCWebContext _ostreCWebContext;

        public UserParagraphRepostiory(OstreCWebContext ostreCWebContext)
        {
            _ostreCWebContext = ostreCWebContext;
        }

        public async Task AddSave(UserParagraph userParagraph)
        {
            _ostreCWebContext.UserParagraphs.Add(userParagraph);
            await _ostreCWebContext.SaveChangesAsync();
        }

        public async Task<bool> HasPlayerGameOpened(string userId)
        {
            var save = _ostreCWebContext.UserParagraphs.Where(x => x.UserId.Equals(userId)).ToList();

            return save.Any(x => x.ActiveGame == true);
        }

        public async Task<UserParagraph> GetLastCreateGame(string userId)
        { 
            var saves = _ostreCWebContext.UserParagraphs.Where(x => x.UserId.Equals(userId)).ToList();

            return saves.FirstOrDefault(s => s.Id == saves.Max(x => x.Id));
        }
    }
}
