using OstreCWEB.Data.DataBase.ManyToMany;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    public interface IUserParagraphRepository
    {
        public Task<UserParagraph> Add();
        public Task<UserParagraph> GetByUserId(string userId, int characterTemplateId, int storyId);
        public Task<List<UserParagraph>> GetAll();
        public Task<UserParagraph> Create(string userId, int characterTemplateId, int storyId);
        public Task Update(UserParagraph gameSession);
        public Task Delete(UserParagraph gameSession);
        public Task<UserParagraph> GetActiveByUserId(string userId);
    }
}
