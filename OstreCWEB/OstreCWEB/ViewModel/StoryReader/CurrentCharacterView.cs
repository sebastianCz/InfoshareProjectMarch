using OstreCWEB.Data.Repository.Characters.MetaTags;
using OstreCWEB.ViewModel.Characters;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstreCWEB.ViewModel.StoryReader
{
    public class CurrentCharacterView
    {
        public string CharacterName { get; set; }
        public int MaxHealthPoints { get; set; }
        public int CurrentHealthPoints { get; set; }
        public int Level { get; set; }
        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public PlayableRaceView Race { get; set; }
        public PlayableClassView CharacterClass { get; set; }
        public List<ItemCharacterView> LinkedItems { get; set; }
        public List<ActionCharacterView> LinkedActions { get; set; }
        
        public IEnumerable<ItemCharacterView> ItemCharacterWithAction { get { return LinkedItems.Where(l => l.Item.ActionToTrigger != null);  } }
        public int CombatId { get; set; }
        public int NotEquippedItemsCount  
        { 
            get
            {
                return LinkedItems.Where(i => i.IsEquipped == true).Count();
            } 
        }
        public int CurrentHealthPercentage { get { return CalculateCurrentHealthPercentage(); } }

        public int CalculateCurrentHealthPercentage()
        {
            return (CurrentHealthPoints*100)/ MaxHealthPoints;
        }
        public bool HasShowableActions { get { return LinkedActions.Where(a => a.IsShowable).Count() > 0; } }

    }
}
