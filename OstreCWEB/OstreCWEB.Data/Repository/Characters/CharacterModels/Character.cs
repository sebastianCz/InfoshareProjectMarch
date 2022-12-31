using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    public abstract class Character
    {
        //Ef Config
        [Key]
        public int CharacterId { get; set; }
        //Actions granted on level 1 based on class+race+ user choices. 
        public List<ActionCharacter>? LinkedActions { get; set; }
        public List<ItemCharacter>? LinkedItems { get; set; }

        //This is required because Characters IDs can be the same as enemies...Combat needs to generate it's own IDs
        //This is not saved to data base.
        [NotMapped]
        public Item[] Inventory { get; set; }
        [NotMapped]
        public List<Item> EquippedItems { get; set; }
        [NotMapped]
        //Actions granted on level 1 based on class+race+ user choices. 
        public List<CharacterAction>? DefaultActions { get; set; }
        [NotMapped]
        public List<CharacterAction> AllAvailableActions { get; set; }
        [NotMapped]
        public List<Status> ActiveStatuses { get; set; }
        [NotMapped]
        public Item EquippedArmor { get; set; }
        [NotMapped]
        public Item EquippedWeapon { get; set; }
        [NotMapped]
        public Item EquippedSecondaryWeapon { get; set; }
        [NotMapped]
        public int CombatId { get; set; }
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
        [JsonConstructor]
        public Character()
        {
            Inventory = new Item[10];
            EquippedItems = new List<Item>();
            DefaultActions = new List<CharacterAction>();
            AllAvailableActions = new List<CharacterAction>();
            ActiveStatuses = new List<Status>();
            LinkedItems = new List<ItemCharacter>();

        }
    }
}

