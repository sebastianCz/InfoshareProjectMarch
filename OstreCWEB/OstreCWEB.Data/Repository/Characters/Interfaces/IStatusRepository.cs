using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.Interfaces
{
    public interface IStatusRepository
    {
        public Task<Status> GetByIdAsync(int id);
        public Task<List<Status>> GetAllAsync();
        public Task UpdateAsync(Status Status);
        public Task CreateAsync(Status Status);
        public Task DeleteAsync(Status Status);
    }
}
