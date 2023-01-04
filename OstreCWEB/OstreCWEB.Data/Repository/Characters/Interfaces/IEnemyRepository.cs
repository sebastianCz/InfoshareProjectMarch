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
        public Task<Enemy> GetById(int id);
        public Task<List<Enemy>> GetAll();
        public Task Update(Enemy item);
        public Task Create(Enemy item);
        public Task Delete(Enemy item);
    }
}
