using OstreCWEB.Data.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
