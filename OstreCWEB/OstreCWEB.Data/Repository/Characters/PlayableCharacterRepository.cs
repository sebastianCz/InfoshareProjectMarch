using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;

namespace OstreCWEB.Data.Repository.Characters
{
    internal class PlayableCharacterRepository : IPlayableCharacterRepository
    {
        private OstreCWebContext _db; 
        public PlayableCharacterRepository(OstreCWebContext db)
        {
            _db = db; 
        }

        public Task<PlayableCharacter> Create(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Add(playableCharacter);
            _db.SaveChanges();
            return Task.FromResult(playableCharacter);
        }
        public bool Exists(int id)
        {
            return _db.PlayableCharacters.Any(x => x.CharacterId ==id);
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
        public async Task UpdateAlreadyTrackedAsync(PlayableCharacter playableCharacter)
        { 
            var tracked = await _db.PlayableCharacters.FindAsync(playableCharacter.CharacterId);
            tracked = playableCharacter; 
        }

        public async Task<PlayableCharacter> GetByIdNoTrackingAsync(int characterTemplateId)
        { 
            return await _db.PlayableCharacters
                 .Include(x=>x.CharacterClass)
                 .ThenInclude(y=>y.ActionsGrantedByClass)
                 .Include(x => x.CharacterClass)
                 .ThenInclude(y => y.ItemsGrantedByClass)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(x => x.CharacterId == characterTemplateId); 
        }
    }
}
