using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.MetaTags;

namespace OstreCWEB.ViewModel.Characters
{
    public class PlayableCharacterDetailsView
    { 
        public int CharacterId { get; set; }
        public List<ActionCharacter>? LinkedActions { get; set; }
        public List<ItemCharacter>? LinkedItems { get; set; }
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
        public List<Item> EquippedItems { get; set; }
        public Item[] Inventory { get; set; }
        public List<CharacterAction>? InnateActions { get; set; } 
        public List<CharacterAction> AllAvailableActions
        {
            get
            {
                var allAvailableActions = new List<CharacterAction>();
                foreach (var item in EquippedItems) { if (item.ActionToTrigger != null) { allAvailableActions.Add(item.ActionToTrigger); } }
                foreach (var action in InnateActions) { if (action != null) { allAvailableActions.Add(action); } }
                foreach (var item in Inventory)
                {
                    if (item != null && item.ActionToTrigger != null)
                    {
                        allAvailableActions.Add(item.ActionToTrigger);
                    }
                }
                return allAvailableActions;
            }
            set
            {
                //Should be removed. For now it will cause compile errors in fight ( it needs the SET )
            }
        }
        //This was required because enemies and playable characters used to be in two seperate tables.
        //Their ids weren't unique. Now they are.  
        public int CombatId { get; set; } 
        public List<Status> ActiveStatuses { get; set; }

        //Can be removed since we can have  an equipped items list. 
        public Item EquippedArmor { get; set; } 
        public Item EquippedWeapon { get; set; } 
        public Item EquippedSecondaryWeapon { get; set; } 
        public PlayableRace Race { get; set; } 
        public PlayableClass CharacterClass { get; set; }  
    }
}