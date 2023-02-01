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
        public Task<Item> GetByIdAsync(int id);
        public Task<List<Item>> GetAllAsync();
        public Task UpdateAsync(Item item);
        public Task CreateAsync(Item item);
        public Task DeleteAsync(Item item);
    }
}
