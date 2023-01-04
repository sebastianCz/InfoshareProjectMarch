using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.Interfaces
{
    public interface ICharacterClassRepository
    {
        public Task<PlayableClass> GetById(int id);
        public Task<List<PlayableClass>> GetAll(int id);
        public Task Update(PlayableClass item);
        public Task Create(PlayableClass item);
        public Task Delete(PlayableClass item);
    }
}
