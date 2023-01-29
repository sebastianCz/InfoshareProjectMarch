using OstreCWEB.Data.DataBase.ManyToMany;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    public interface IUserParagraphRepository
    {
        public Task<UserParagraph> Add(); 
        public Task<List<UserParagraph>> GetAll();
        public Task Create(UserParagraph newGameSession);
        public Task UpdateAsync(UserParagraph gameSession);
        public Task Delete(UserParagraph gameSession);
        public Task<UserParagraph> GetActiveByUserIdAsync(string userId);
        public Task<UserParagraph> GetByUserParagraphIdAsync(int userParagraphId);
        public Task<UserParagraph> GetActiveByUserIdNoTrackingAsync(string userId);
        public UserParagraph GetActiveByUserIdNoTracking(string userId);
        public Task SaveChangesAsync();
    }
}
