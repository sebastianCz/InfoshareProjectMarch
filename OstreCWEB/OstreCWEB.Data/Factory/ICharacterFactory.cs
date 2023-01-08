using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Factory
{
    public interface ICharacterFactory
    {
        public Task<PlayableCharacter> CreatePlayableCharacterInstance(PlayableCharacter playableCharacter);
    }
}
