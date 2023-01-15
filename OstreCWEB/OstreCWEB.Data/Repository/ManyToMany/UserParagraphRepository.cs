﻿using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Factory;

#nullable disable

namespace OstreCWEB.Data.Repository.ManyToMany
{
    internal class UserParagraphRepository : IUserParagraphRepository
    {
        private OstreCWebContext _context;
        private readonly IIdentityRepository _identityRepository;
        private readonly IPlayableCharacterRepository _playableCharacterRepository;
        private readonly ICharacterFactory _playableCharacterFactory;
        public UserParagraphRepository(ICharacterFactory playableCharacterFactory, OstreCWebContext context, IIdentityRepository indentityRepository, IPlayableCharacterRepository playableCharacterRepository)
        {
            _context = context;
            _identityRepository = indentityRepository;
            _playableCharacterRepository = playableCharacterRepository;
            _playableCharacterFactory = playableCharacterFactory;
        }

        public Task<UserParagraph> Add()
        {
            throw new NotImplementedException();
        }
        public async Task<UserParagraph> Create(string userId, int characterTemplateId, int storyId)
        {
            var user = await _identityRepository.GetUser(userId);
            if (user.UserParagraphs.Count >= 5) { throw new Exception(); }

            var newGameInstance = new UserParagraph();

            newGameInstance.User = user;
            var storyFirstParaId = _context.Stories.Where(s => s.Id == storyId).FirstOrDefault().FirstParagraphId;

            newGameInstance.Paragraph = _context.Paragraphs.Where(s => s.Id == storyFirstParaId).FirstOrDefault();

            var notTrackedCharacter = _context.PlayableCharacters
                 .AsNoTracking()
                 .SingleOrDefault(x => x.CharacterId == characterTemplateId);
            var newCharacterInstance = _playableCharacterFactory.CreatePlayableCharacterInstance(notTrackedCharacter).Result;

            newGameInstance.ActiveCharacter = newCharacterInstance;
            newGameInstance.ActiveGame = true;

            user.UserParagraphs.ForEach(c => c.ActiveGame = false);
            user.UserParagraphs.Add(newGameInstance);
            await _identityRepository.Update(user);
            return newGameInstance;
        }
        public async Task Delete(UserParagraph gameSession) 
        {
            _context.PlayableCharacters.Remove(gameSession.ActiveCharacter);
            _context.UserParagraphs.Remove(gameSession); 
            await _context.SaveChangesAsync(); 
        }
        public async Task<List<UserParagraph>> GetAll()
        {
            return await _context.UserParagraphs.ToListAsync();
        }
        public async Task<UserParagraph> GetById(int id )
        {
            return await _context.UserParagraphs.SingleOrDefaultAsync(c=>c.UserParagraphId == id);
        }
        public async Task Update(UserParagraph gameSession)
        {
            _context.UserParagraphs.Update(gameSession);
            await _context.SaveChangesAsync();
        } 
       
        public async Task<UserParagraph> GetByUserParagraphIdAsync(int userParagraphId)
        {
            return await _context.UserParagraphs.SingleOrDefaultAsync(u=>u.UserParagraphId == userParagraphId);

        } 

        public async Task<UserParagraph> GetActiveByUserId(string userId)
        {
            return _context.UserParagraphs
                .Include(x => x.Paragraph)
                    .ThenInclude(p => p.Choices)
                .Include(x => x.Paragraph)
                    .ThenInclude(x => x.TestProp)
                .Include(x => x.ActiveCharacter)
                .SingleOrDefault(s => s.User.Id == userId && s.ActiveGame);
        }
    }
}
