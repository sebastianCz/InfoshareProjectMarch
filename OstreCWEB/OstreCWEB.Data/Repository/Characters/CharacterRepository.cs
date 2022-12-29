using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OstreCWEB.Data.Repository.Characters
{
    public class CharacterRepository : ICharacterRepository
    {

        private readonly OstreCWebContext _db;

        public CharacterRepository(OstreCWebContext ostreCWebContext)
        {
            _db = ostreCWebContext;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _db.Items
                .Include(i => i.ActionToTrigger)
                    .ThenInclude(i => i.Status) 
                .ToListAsync();
        }


    } 
}
