using OstreCWEB.Data.Repository.Characters.CharacterModels;

namespace OstreCWEB.Data.Factory
{
    public interface ICharacterFactory
    {
        public Task<PlayableCharacter> CreatePlayableCharacterInstance(PlayableCharacter playableCharacter);
    }
}
