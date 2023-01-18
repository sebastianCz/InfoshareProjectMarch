using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Factory;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Data.Repository.Identity; 

#nullable disable

namespace OstreCWEB.Data.Repository.ManyToMany
{
    internal class UserParagraphRepository : IUserParagraphRepository
    {
        private OstreCWebContext _context;
        private readonly IIdentityRepository _identityRepository;
        private readonly IPlayableCharacterRepository _playableCharacterRepository; 
        public UserParagraphRepository(OstreCWebContext context, IIdentityRepository indentityRepository, IPlayableCharacterRepository playableCharacterRepository)
        {
            _context = context;
            _identityRepository = indentityRepository;
            _playableCharacterRepository = playableCharacterRepository; 
        }

        public Task<UserParagraph> Add()
        {
            throw new NotImplementedException();
        }
        public async Task Create(UserParagraph newGameSession)
        {
            _context.UserParagraphs.AddAsync(newGameSession);
            await _context.SaveChangesAsync();
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
