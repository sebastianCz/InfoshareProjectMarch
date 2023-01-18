using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.Interfaces
{
    public interface IEnemyRepository
    {
        public Task<Enemy> GetByIdAsync(int id);
        public Task<List<Enemy>> GetAllTemplatesAsync();
        public Task UpdateAsync(Enemy item);
        public Task CreateAsync(Enemy item);
        public Task DeleteAsync(Enemy item);
    }
}
