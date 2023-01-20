using Microsoft.AspNetCore.Authorization.Infrastructure;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.Characters.Interfaces;

namespace OstreCWEB.Services.Characters
{
    public class PlayableCharacterService : IPlayableCharacterService 
    {
        private readonly IPlayableCharacterRepository _playableCharacterRepository;
        public PlayableCharacterService(IPlayableCharacterRepository characterRepository)
        {
            _playableCharacterRepository = characterRepository;
        } 
        public Task Add(Character charater)
        {
            throw new NotImplementedException();
        } 
        public Task<List<PlayableCharacter>> GetAll()
        {
            return _playableCharacterRepository.GetAllTemplatesAsync();
        }
        /// <summary>
        /// Gets all playable characters except those belonging to a given  user
        /// </summary>
        /// <param name="userCharacters"></param>
        /// <returns></returns>
        public async Task<List<PlayableCharacter>> GetAllTemplates(string userId)
        {
            return await _playableCharacterRepository.GetAllTemplatesExceptAsync(userId);
        } 
        public async Task<PlayableCharacter> GetById(int id)
        {
            return await _playableCharacterRepository.GetByIdAsync(id);
        } 
        public Task Remove(Character charater)
        {
            throw new NotImplementedException();
        } 
        public Task Update(Character charater)
        {
            throw new NotImplementedException();
        }
    }
}
