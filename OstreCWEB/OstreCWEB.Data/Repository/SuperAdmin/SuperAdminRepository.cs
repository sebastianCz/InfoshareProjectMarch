using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.SuperAdmin
{
    
    public class SuperAdminRepository : ISuperAdminRepository
    {
        public OstreCWebContext _db;
        public SuperAdminRepository(OstreCWebContext db)
        {
            _db = db;
        }

        public void Test()
        {
            var x = _db.PlayableCharacters.ToList();
               
            var z = 1 + 2;
               
        }
    }
}
