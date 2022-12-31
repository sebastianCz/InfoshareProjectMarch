using OstreCWEB.Data.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Identity
{
    internal class IdentityRepository  
    {
        private OstreCWebContext _context { get; set; }
        
        public void AddUser(User user)
        {

            _context.Add(user);
        }
        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(/*u => u.Id == id*/);
        }
    }
}
