using OstreCWEB.Data.Repository.Items;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OstreCWEB.Data.Repository.Characters
{
    public abstract class Character
    {
        [Required]
        public int ID { get; set; }
        //This is required because Characters IDs can be the same as enemies...Combat needs to generate it's own IDs
        //This is not saved to data base.
        public int CombatId { get; set; }

        [Required]
        public string CharacterName { get; set; }
        [Required]
        public int HealthPoints { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Alignment { get; set; }
        [Required]
        public Item EquippedArmor { get; set; }
        [Required]
        public Item EquippedWeapon { get; set; }
        [Required]
        public Item EquippedSecondaryWeapon { get; set; }

        public Item[] Inventory { get; set; }
        public List<CharacterActions> AllAvailableActions { get; set; }
        public List<CharacterActions> DefaultActions { get; set; }

        public List<Status> ActiveStatuses { get; set; }

        [Required]
        public int Strenght { get; set; }
        [Required]
        public int ModStrenght { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int ModDexterity { get; set; }
        [Required]
        public int Constitution { get; set; }
        [Required]
        public int ModConstitution { get; set; }
        [Required]
        public int Intelligence { get; set; }
        [Required]
        public int ModIntelligence { get; set; }
        [Required]
        public int Wisdom { get; set; }
        [Required]
        public int ModWisdom { get; set; }
        [Required]
        public int Charisma { get; set; }
        [Required]
        public int ModCharisma { get; set; }


        [JsonConstructor]
        public Character()
        {

        }
    }
   
    //public Character(int id,string characterName,string race,int healtPoints,int level,string alignment,Item equippedArmor,Item equippedWeapon,
    //    Item equippedSecondaryWeapon, Item[] items,int strenght,int modStrenght,int dexterity,int modDexterity,int constitution,int modConstitution,
    //    int intelligence,int modIntelligence,int wisdom,int modWisdom,int charisma,int modCharisma)

    //{
    //    ID = id;
    //    CharacterName = characterName;
    //    Race = race;
    //    HealthPoints = healtPoints;
    //    Level = level;
    //    Alignment = alignment;
    //    EquippedArmor = (Armor)equippedArmor;
    //    EquippedWeapon = (Weapon)equippedWeapon;
    //    EquippedSecondaryWeapon = equippedSecondaryWeapon;
    //    Inventory = items;
    //    Strenght = strenght;
    //    ModStrenght = modStrenght;
    //    Dexterity = dexterity;
    //    ModDexterity = modDexterity;
    //    Constitution = constitution;
    //    ModConstitution = modConstitution; 
    //    Intelligence = intelligence;
    //    ModIntelligence = modIntelligence;
    //    Wisdom = wisdom;
    //    ModWisdom = modWisdom;
    //    Charisma = charisma;
    //    ModCharisma = charisma;
    //}
}

