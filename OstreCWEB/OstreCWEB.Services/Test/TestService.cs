using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Items;

namespace OstreCWEB.Services.Test
{
    public class TestService :ITestService
    {
       private StaticLists _db { get;} = new StaticLists();
        public List<Item> GetItems()
        {
         return _db.GetItems();
        }
         
    }
}
