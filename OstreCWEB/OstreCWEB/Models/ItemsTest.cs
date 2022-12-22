using OstreCWEB.Data.Repository.Characters.CoreClasses;
using OstreCWEB.Data.Repository.Items;

namespace OstreCWEB.Models
{
    public class ItemsTest
    {
        public Character Character1 { get; set; }
        public Character Character2 { get; set; }
        public List<Item> Items { get; set; }
        public List<CharacterActions> Actions { get; set; }

        public List<Enemy> ActiveEnemies { get; set; } = new List<Enemy>();
    }
}
