using OstreCWEB.Data.DataBase;

namespace OstreCWEB.Services.Test
{
    public class SeedService
    {
        public ISeeder _db { get; set; }
        public SeedService(ISeeder db)
        {
            _db = db;
        } 
        public void SeedData()
        {
            _db.SeedDataBase();
        } 
    }
}
