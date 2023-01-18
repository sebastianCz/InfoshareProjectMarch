﻿using OstreCWEB.Data.DataBase.ManyToMany;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    public interface IUserParagraphRepository
    {
        public Task<UserParagraph> Add(); 
        public Task<List<UserParagraph>> GetAll();
        public Task Create(UserParagraph newGameSession);
        public Task Update(UserParagraph gameSession);
        public Task Delete(UserParagraph gameSession);
        public Task<UserParagraph> GetActiveByUserId(string userId);
        public Task<UserParagraph> GetByUserParagraphIdAsync(int userParagraphId);
    }
}
