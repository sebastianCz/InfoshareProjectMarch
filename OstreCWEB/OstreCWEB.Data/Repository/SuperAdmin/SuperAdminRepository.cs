using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Identity;

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



        }
        public User GetRandomUser()
        {
            return _db.Users.First();
        }
    }
}
