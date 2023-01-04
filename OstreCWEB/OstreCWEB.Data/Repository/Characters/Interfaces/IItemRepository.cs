using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.Interfaces
{
    public interface IItemRepository
    {
        public Task<Item> GetById(int id);
        public Task<List<Item>> GetAll(int id);
        public Task Update(Item item);
        public Task Create(Item item);
        public Task Delete(Item item);
    }
}
