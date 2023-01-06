using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Data.DataBase;
using Microsoft.EntityFrameworkCore;

namespace OstreCWEB.Services.Factory
{
    public class PlayableCharacterFactory : IPlayableCharacterFactory
    {
        private readonly IPlayableCharacterRepository _playableCharacterRepository; 
        public PlayableCharacterFactory(IPlayableCharacterRepository playableCharacterRepository)
        {
            _playableCharacterRepository = playableCharacterRepository; 
        }
    
        public async Task<PlayableCharacter> CreatePlayableCharacterInstance(int playableCharacterTemplateId)
        {
            var characterTemplate = await _playableCharacterRepository.GetByIdNoTracking( playableCharacterTemplateId );
            characterTemplate.IsTemplate = false; 
            //It will create a new row in db and increment the ID. 
            var newInstance = await _playableCharacterRepository.Create(characterTemplate); 
            return newInstance;

        }

        //public async Task<PlayableCharacter> DefineAsInstance(PlayableCharacter playableCharacter)
        //{
         
        //}

    }
}
