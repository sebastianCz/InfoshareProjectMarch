using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Identity
{
    public class IdentityRepository  : IIdentityRepository
    {
        private OstreCWebContext _context { get; }
        public IdentityRepository(OstreCWebContext context)
        {
            _context = context;
        }
        
        public void AddUser(User user)
        {

            _context.Add(user);
        }
        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(/*u => u.Id == id*/);
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
