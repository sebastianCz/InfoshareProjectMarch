using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;

namespace OstreCWEB.Data.Repository.Characters
{
    internal class CharacterActionRepository : ICharacterActionsRepository
    {
        private OstreCWebContext _db;
        public CharacterActionRepository(OstreCWebContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(CharacterAction characterAction)
        {
           _db.CharacterActions.Add(characterAction);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(CharacterAction characterAction)
        {
            _db.CharacterActions.Remove(characterAction);
             await _db.SaveChangesAsync();
        }

        public async Task<List<CharacterAction>> GetAllAsync()
        {
            return await _db.CharacterActions
                .Include(s => s.Status)
                .Include(s => s.LinkedCharacter)
                .ToListAsync();
        }

        public async Task<CharacterAction> GetByIdAsync(int id)
        {
            return await _db.CharacterActions
                .Include(s=>s.Status)
                .Include(s=>s.LinkedCharacter) 
                .SingleOrDefaultAsync(s => s.CharacterActionId == id);
        }

        public async Task UpdateAsync(CharacterAction characterAction)
        {
            _db.CharacterActions.Update(characterAction);
           await _db.SaveChangesAsync();
        }
    }
}
