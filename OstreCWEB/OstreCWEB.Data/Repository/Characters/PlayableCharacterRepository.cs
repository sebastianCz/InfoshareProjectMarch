using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;

namespace OstreCWEB.Data.Repository.Characters
{
    public class PlayableCharacterRepository : IPlayableCharacterRepository
    {
        private OstreCWebContext _db;
        public PlayableCharacterRepository(OstreCWebContext db)
        {
            _db = db;
        }
    
        public async Task Create(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Add(playableCharacter);
            await _db.SaveChangesAsync(); 
        }

        public async Task Delete(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Remove(playableCharacter);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PlayableCharacter>> GetAll(int id)
        {
             return await _db.PlayableCharacters.ToListAsync();
        }

        public async Task<PlayableCharacter> GetById(int id)
        {
            return await _db.PlayableCharacters.FirstAsync(c=>c.CharacterId ==id);
        }

        public async Task Update(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Update(playableCharacter);
            await _db.SaveChangesAsync();
        }
    }
}
