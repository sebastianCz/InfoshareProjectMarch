using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;
namespace OstreCWEB.Services.Characters
{
    public interface IPlayableCharacterService
    {
        public Task<PlayableCharacter> GetById(int id); 
        public Task<List<PlayableCharacter>> GetAll(); 
        public Task<List<PlayableCharacter>> GetAllTemplates(string id);
        public Task Add(Character charater);
        public Task Update(Character charater);
        public Task Remove(Character charater);
        public bool Exists(int id);
    }
}
