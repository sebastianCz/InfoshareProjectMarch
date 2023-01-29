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
        public Task Create(PlayableCharacter playableCharacter)
        {
            playableCharacter.CurrentHealthPoints = 10;
            playableCharacter.MaxHealthPoints = 10;
            playableCharacter.IsTemplate = true;

            return _playableCharacterRepository.Create(playableCharacter);
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
        #region
        public void CreateNew(PlayableCharacter model)
        {
            _playableCharacterRepository.CreateNew(model);
        }
        public List<PlayableRace> GetAllRaces()
        {
            return _playableCharacterRepository.GetAllRaces();
        }
        public List<PlayableClass> GetAllClasses()
        {
            return _playableCharacterRepository.GetAllClasses();
        }
        public void RollAttributes(PlayableCharacter model)
        {
            _playableCharacterRepository.RollAttributes(model);
        }

        #endregion
        #region quickAutisticMethod
        public int RollDice(int maxValue = 7)
        {
            int[] rolls = new int[4];

            Random rng = new Random();
            for (int i = 0; i < rolls.Length; i++)
            {
                rolls[i] = rng.Next(1, maxValue);
            }
            Array.Sort(rolls);
            Array.Reverse(rolls);

            int sum = rolls.Take(3).Sum();
            return sum;
        }
        private List<int> attributeList = new List<int>();

        #endregion
    }
}
