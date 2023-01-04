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
        public Task<Status> GetById(int id);
        public Task<List<Status>> GetAll();
        public Task Update(Status Status);
        public Task Create(Status Status);
        public Task Delete(Status Status);
    }
}
