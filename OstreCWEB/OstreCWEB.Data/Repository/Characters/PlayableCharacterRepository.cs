using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using OstreCWEB.Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OstreCWEB.Data.Repository.Characters
{
    public class PlayableCharacterRepository : IPlayableCharacterRepository
    {
        private OstreCWebContext _db;
        private readonly IPlayableCharacterFactory _playableCharacterFactory;
        public PlayableCharacterRepository(OstreCWebContext db,IPlayableCharacterFactory playableCharacterFactory)
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

        public async Task Delete(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Remove(playableCharacter);
            await _db.SaveChangesAsync();
        }

        public async Task<List<PlayableCharacter>> GetAllTemplates()
        {
            return await _db.PlayableCharacters.ToListAsync();
        }
        /// <summary>
        /// Gets all playable characters except those belonging to a given user.
        /// </summary>
        /// <param name="userCharacters"></param>
        /// <returns></returns>
        public async Task<List<PlayableCharacter>> GetAllTemplates(string userId)
        {
            return await _db.PlayableCharacters.Where(c => c.UserId != userId && c.IsTemplate == true).ToListAsync();
        }

        public async Task<PlayableCharacter> GetById(int id)
        {
            return await _db.PlayableCharacters.FirstAsync(c => c.CharacterId == id);
        }

        public async Task Update(PlayableCharacter playableCharacter)
        {
            _db.PlayableCharacters.Update(playableCharacter);
            await _db.SaveChangesAsync();
        }
       
    }
}
