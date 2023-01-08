using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Identity
{
    
    public class IdentityRepository  : IIdentityRepository
    {
        private readonly IPlayableCharacterFactory _playableCharacterFactory;
        private readonly IPlayableCharacterRepository _playableCharacterRepository;
        private OstreCWebContext _context { get; }
        public IdentityRepository(OstreCWebContext context ,IPlayableCharacterRepository playableCharacterRepository, IPlayableCharacterFactory playableCharacterFactory )
        {
            _playableCharacterFactory = playableCharacterFactory;
            _playableCharacterRepository = playableCharacterRepository;
            _context = context; 
        }
        public Task AddUser(User user)
        { 
            _context.Add(user);
            return Task.CompletedTask;
        }
        public async Task<User> GetUser(string id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u=>u.Id == id); 
            return user;
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(User user)
        {
             _context.Update(user);
             await _context.SaveChangesAsync();
        }  

    }
}
