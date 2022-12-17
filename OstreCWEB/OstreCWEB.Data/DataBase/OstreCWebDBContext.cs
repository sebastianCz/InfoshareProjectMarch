using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.Repository;

namespace OstreCWEB.Data.DataBase
{
    public class OstreCWebContext : DbContext
    {
        public OstreCWebContext(DbContextOptions options) : base(options) 
        { 
        }
    }
}