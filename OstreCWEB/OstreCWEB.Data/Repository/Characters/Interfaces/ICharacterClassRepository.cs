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
        public Task<PlayableClass> GetByIdAsync(int id);
        public Task<List<PlayableClass>> GetAllAsync();
        public Task UpdateAsync(PlayableClass item);
        public Task CreateAsync(PlayableClass item);
        public Task DeleteAsync(PlayableClass item);
    }
}
