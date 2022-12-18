using OstreCWEB.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Characters
{
    public class PlayableCharacter : Character
    {
        public int ActionCounter { get; set; }
        //public PlayableCharacter(int id, string characterName, string race, int healtPoints, int level, string alignment, Item equippedArmor, Item equippedWeapon, Item equippedSecondaryWeapon, Item[] items, int strenght, int modStrenght, int dexterity, int modDexterity, int constitution, int modConstitution, int intelligence, int modIntelligence, int wisdom, int modWisdom, int charisma, int modCharisma) : base(id, characterName, race, healtPoints, level, alignment, equippedArmor, equippedWeapon, equippedSecondaryWeapon, items, strenght, modStrenght, dexterity, modDexterity, constitution, modConstitution, intelligence, modIntelligence, wisdom, modWisdom, charisma, modCharisma)
        //{
        //}

        public List<CharacterAction> Actions { get; set; }
        public List<CharacterAction> ActionsOnHero { get; set; }

        public PlayableCharacter()
        {

        }
        public PlayableRace Race { get; set; }
        //Id used to "link" the character to a user in db later on. 
        [Required]
        public int UserId { get; set; }
        [Required]
        public PlayableCharacterClass CharacterClass { get; set; }

        
    }
}
