using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Factory
{
    public interface IPlayableCharacterFactory
    {
        public Task<PlayableCharacter> CreatePlayableCharacterInstance(int playableCharacterTemplateId);
    }
}
