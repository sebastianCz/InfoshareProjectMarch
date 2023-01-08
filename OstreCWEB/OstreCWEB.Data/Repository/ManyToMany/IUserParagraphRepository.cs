using OstreCWEB.Data.DataBase.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    public interface IUserParagraphRepository
    {
        public Task<UserParagraph> Add(); 
        public Task<List<UserParagraph>> GetAll();
        public Task<UserParagraph> Create(string userId, int characterTemplateId, int storyId);
        public Task<UserParagraph> Update(UserParagraph gameSession);
        public Task Delete(UserParagraph gameSession);
        public Task<UserParagraph> GetByUserParagraphIdAsync(int userParagraphId);
    }
}
