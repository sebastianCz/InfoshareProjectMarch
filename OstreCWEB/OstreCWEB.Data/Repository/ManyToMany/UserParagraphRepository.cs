using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Services.Factory;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    public class UserParagraphRepository : IUserParagraphRepository
    {
        private OstreCWebContext _context;
        private readonly IIdentityRepository _identityRepository;
        private readonly IPlayableCharacterRepository _playableCharacterRepository;
        private readonly IPlayableCharacterFactory _playableCharacterFactory;
        public UserParagraphRepository(IPlayableCharacterFactory playableCharacterFactory, OstreCWebContext context,IIdentityRepository indentityRepository, IPlayableCharacterRepository playableCharacterRepository )
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
        public  async Task<UserParagraph> Create(string userId,int characterTemplateId,int storyId)
        {
            var user = await _identityRepository.GetUser(userId);
            if(user.UserParagraphs.Count >= 5) { throw new Exception(); }

            var newGameInstance = new UserParagraph();

            newGameInstance.UserId = userId;
            newGameInstance.ParagraphId = _context.Stories.Where(s => s.Id == storyId).FirstOrDefault().FirstParagraphId;

            var notTrackedCharacter = _context.PlayableCharacters
                 .AsNoTracking()
                 .SingleOrDefault(x => x.CharacterId == characterTemplateId);
            var newCharacterInstance = _playableCharacterFactory.CreatePlayableCharacterInstance(notTrackedCharacter).Result; 

            newGameInstance.CharacterId = newCharacterInstance.CharacterId;
            newGameInstance.ActiveGame = true;

            
            user.UserParagraphs.Add(newGameInstance);
            await _identityRepository.Update(user);
            return  newGameInstance;
        } 
        public Task<UserParagraph> Delete()
        {
            throw new NotImplementedException();
        } 
        public async Task<List<UserParagraph>> GetAll()
        {
           return await _context.UserParagraphs.ToListAsync();
        } 
        public Task<UserParagraph> Update()
        {
            throw new NotImplementedException();
        } 
        public Task<UserParagraph> GetByUserId(string userId, int characterTemplateId, int storyId)
        {
            throw new NotImplementedException();
        } 
    }
}
