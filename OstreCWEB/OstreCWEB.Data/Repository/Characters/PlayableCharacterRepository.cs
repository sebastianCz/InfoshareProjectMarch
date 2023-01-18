using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Factory;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces; 

namespace OstreCWEB.Data.Repository.Characters
{
    internal class PlayableCharacterRepository : IPlayableCharacterRepository
    {
        private OstreCWebContext _db;
        private readonly ICharacterFactory _playableCharacterFactory;
        public PlayableCharacterRepository(OstreCWebContext db,ICharacterFactory playableCharacterFactory)
        {
            _db = db;
            _playableCharacterFactory = playableCharacterFactory;
        }

        public Task<PlayableCharacter> Create(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Add(playableCharacter);
            _db.SaveChanges();
            return Task.FromResult(playableCharacter);
        }

        public async Task DeleteAsync(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Remove(playableCharacter);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PlayableCharacter>> GetAllTemplatesAsync()
        {
            return await _db.PlayableCharacters.ToListAsync();
        }
        /// <summary>
        /// Gets all playable characters except those belonging to a given user.
        /// </summary>
        /// <param name="userCharacters"></param>
        /// <returns></returns>
        public async Task<List<PlayableCharacter>> GetAllTemplatesExceptAsync(string userId)
        {
            return await _db.PlayableCharacters.Where(c => c.UserId != userId && c.IsTemplate == true).ToListAsync();
        }

        public async Task<PlayableCharacter> GetByIdAsync(int id)
        {
            return await _db.PlayableCharacters.FirstAsync(c => c.CharacterId == id);
        }

        public async Task UpdateAsync(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Update(playableCharacter);
            await _db.SaveChangesAsync();
        }
       
        public async Task<PlayableCharacter> GetByIdNoTrackingAsync(int characterTemplateId)
        { 
            return await _db.PlayableCharacters
                 .AsNoTracking()
                 .SingleOrDefaultAsync(x => x.CharacterId == characterTemplateId);
        }
    }
}
