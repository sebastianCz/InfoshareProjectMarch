using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters
{
    internal class CharacterClassRepository : ICharacterClassRepository
    {
        OstreCWebContext _context;
        public CharacterClassRepository(OstreCWebContext context)
        {
            _context = context;
        }

        public OstreCWebContext Context { get; }

        public Task CreateAsync(PlayableClass item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PlayableClass item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PlayableClass>> GetAllAsync()
        {
            return await _context.PlayableCharacterClasses.ToListAsync();
        }

        public Task<PlayableClass> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PlayableClass item)
        {
            throw new NotImplementedException();
        }
    }
}
