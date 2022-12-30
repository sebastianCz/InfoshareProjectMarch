using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace OstreCWEB.Data.Repository.Characters
{
    public class StatusRepository : IStatusRepository
    {
        private readonly OstreCWebContext _db;
        public StatusRepository(OstreCWebContext db)
        {
            _db = db;
        }

        public async Task Create(Status status)
        {
            _db.Statuses.AddAsync(status);
            await _db.SaveChangesAsync(); 
        }

        public async Task Delete(Status status)
        { 
            _db.Statuses.Remove(status);
          
            await _db.SaveChangesAsync();
        }

        public async Task<List<Status>> GetAll()
        {
         
            return await _db.Statuses.Include(p => p.CharacterActions).ToListAsync(); ;
        }
 

        public async Task<Status> GetById(int id)
        {
            return await _db.Statuses.SingleOrDefaultAsync(s => s.StatusId == id);
        }

        public async Task Update(Status status)
        {
            _db.Statuses.Update(status);
            await _db.SaveChangesAsync(); 
        }
    }
}
