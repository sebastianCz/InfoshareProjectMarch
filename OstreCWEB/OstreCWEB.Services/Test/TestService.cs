using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Items;
using OstreCWEB.Data.Repository.Characters;
using Newtonsoft.Json;

namespace OstreCWEB.Services.Test
{
    public class TestService 
    {
       private StaticLists _db { get;} = new StaticLists();
        
       private static List<Enemy> _enemies { get; set; } = new List<Enemy>();

        public void GenerateEnemies(int amountToGenerate)
        {
            for(int i = 0; i < amountToGenerate; i++)
            {
                var enemyAsText = JsonConvert.SerializeObject(
                        _db.GetEnemy(),
                    new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });
                 
              var newEnemyInstance = JsonConvert.DeserializeObject<Enemy>(
                  enemyAsText,
                  new JsonSerializerSettings()
                  {
                      TypeNameHandling = TypeNameHandling.Auto
                  });
              _enemies.Add(newEnemyInstance);
            }
        }
        public Enemy GetEnemy(int enemyPositionInList)
        {
            return _enemies[enemyPositionInList];
        }
        public List<Item> GetItems()
        {
            return _db.GetItems();
        }
        public List<Enemy> GetActiveEnemies()
        {
            return _enemies;
        }
        public List<CharacterActions> GetActions()
        {
            return _db.GetActions();
        }
        

    }
}
