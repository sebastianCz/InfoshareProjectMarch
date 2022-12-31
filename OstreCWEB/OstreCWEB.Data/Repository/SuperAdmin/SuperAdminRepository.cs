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




            //var playerId = 4;
            //var Actionid = 3;
            //var cartItem = _db.actionCharactersRelation.First(row => row.CharacterActionId == Actionid && row.CharacterId == playerId);

            //_db.actionCharactersRelation.Remove(cartItem);
            //_db.SaveChanges();
            //var t1 = _db.Enemies
            // .Include(x => x.LinkedActions)
            // .ThenInclude(y => y.Status)
            // .ToList();


            //var t2 = _db.PlayableCharacters
            //    .Include(x => x.DefaultActions)
            //    .ThenInclude(y => y.Status)
            //    .ToList();
            var user = _db.Users.First();
            //_db.PlayableCharacters.Remove(t2[0]);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
