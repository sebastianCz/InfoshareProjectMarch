using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Identity
{
    
    public class IdentityRepository  : IIdentityRepository
    {
        private readonly IPlayableCharacterFactory _playableCharacterFactory;
        private OstreCWebContext _context { get; }
        public IdentityRepository(IPlayableCharacterFactory playableCharacterFactory, OstreCWebContext context)
        {
            _playableCharacterFactory = playableCharacterFactory;
            _context = context;
        }

        public Task AddUser(User user)
        { 
            _context.Add(user);
            return Task.CompletedTask;
        }
        public async Task<User> GetUser(string id)
        {
            return await _context.Users.SingleOrDefaultAsync(u=>u.Id == id);
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(User user)
        {
             _context.Update(user);
             await _context.SaveChangesAsync();
        }

        public async Task<UserParagraph> CreateGameInstance(string userId, int charachterTemplateId, int storyId)
        {
            var user = await GetUser(userId);

            var newGameInstance = new UserParagraph();
            newGameInstance.UserId = userId;
            newGameInstance.ParagraphId = _context.Stories.Where(s=>s.Id == storyId).FirstOrDefault().FirstParagraphId; 
            newGameInstance.Character = await _playableCharacterFactory.CreatePlayableCharacterInstance(charachterTemplateId);
            newGameInstance.ActiveGame = true; 

            user.UserParagraphs.Add(newGameInstance); 
            Update(user);
            _context.SaveChanges();

            return newGameInstance;
        }
    }
}
