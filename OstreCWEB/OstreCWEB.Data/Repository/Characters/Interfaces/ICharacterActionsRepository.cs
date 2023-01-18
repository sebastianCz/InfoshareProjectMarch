using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.Interfaces
{
    public interface ICharacterActionsRepository
    {
        public Task<CharacterAction> GetByIdAsync(int id);
        public Task<List<CharacterAction>> GetAllAsync();
        public Task UpdateAsync(CharacterAction item);
        public Task CreateAsync(CharacterAction item);
        public Task DeleteAsync(CharacterAction item);
    }
}
