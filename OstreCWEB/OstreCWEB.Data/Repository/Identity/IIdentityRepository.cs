using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Identity
{
    public interface IIdentityRepository
    {
        public Task AddUser(User user);
        public Task<User> GetUser(string id);
        public  Task<List<User>> GetAll();
        public   Task<UserParagraph> CreateGameInstance(string userId,int charachterTemplateId,int storyId);
    }
}
