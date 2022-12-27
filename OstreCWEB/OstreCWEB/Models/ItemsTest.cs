using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.CoreClasses;

namespace OstreCWEB.Models
{
    public class ItemsTest
    {
        public Character Character1 { get; set; }
        public Character Character2 { get; set; }
        public List<Item> Items { get; set; }
        public List<CharacterAction> Actions { get; set; }

        public List<Enemy> ActiveEnemies { get; set; } = new List<Enemy>();
    }
}
