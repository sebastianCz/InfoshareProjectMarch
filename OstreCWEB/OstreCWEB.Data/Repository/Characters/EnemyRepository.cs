using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;

namespace OstreCWEB.Data.Repository.Characters
{
    internal class EnemyRepository : IEnemyRepository
    {
        private readonly OstreCWebContext _context;
        public EnemyRepository(OstreCWebContext _context)
        {
            Context = _context;
        } 
        public OstreCWebContext Context { get; }

        public async Task CreateAsync(Enemy item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Enemy item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Enemy>> GetAllTemplatesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Enemy> GetByIdAsync(int id)
        {
            return await _context.Enemies
                .Include(e => e.LinkedItems)
                .Include(e=>e.LinkedActions) 
                .SingleOrDefaultAsync(e => e.CharacterId == id);
        }

        public async Task<Enemy> GetByIdNoTrackingAsync(int id)
        {
            return await _context.Enemies
                .Include(e => e.LinkedItems)
                .Include(e => e.LinkedActions)
                .AsNoTracking()
                .SingleOrDefaultAsync(e => e.CharacterId == id);
        }
        public async Task UpdateAsync(Enemy item)
        {
            throw new NotImplementedException();
        }
    }
}
