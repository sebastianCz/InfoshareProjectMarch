using OstreCWEB.Data.Interfaces;
using OstreCWEB.Data.Repository.Items;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository
{
    public abstract class Character : ITargetable
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Race { get; set; }
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

        public Item[] Items { get; set; }
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

        public List<CharacterAction> Actions { get; set; } 
        public List<CharacterAction> ActionsOnHero { get; set; }
    }

    public enum CharacterAction
    {
        ATTACK=1,
        HEAL,
        SUPERATTACK,
        SPELL,
        ITEM_USE
    }
}
