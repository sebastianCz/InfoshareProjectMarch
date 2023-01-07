using OstreCWEB.Data.DataBase.ManyToMany;

namespace OstreCWEB.Data.Interfaces
{
    public interface IUserParagraphRepostiory
    {
        public Task AddSave(UserParagraph userParagraph);
        public Task<bool> HasPlayerGameOpened(string userId);
        public Task<UserParagraph> GetLastCreateGame(string userId);
    }
}
