using OstreCWEB.Data.DataBase;

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
