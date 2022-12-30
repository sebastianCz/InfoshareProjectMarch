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
        public Task<CharacterAction> GetById(int id);
        public Task<List<CharacterAction>> GetAll(int id);
        public Task Update(CharacterAction item);
        public Task Create(CharacterAction item);
        public Task Delete(CharacterAction item);
    }
}
