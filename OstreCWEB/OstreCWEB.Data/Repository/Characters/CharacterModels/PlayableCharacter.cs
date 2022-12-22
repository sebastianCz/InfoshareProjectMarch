using OstreCWEB.Data.Repository.Characters.Enums;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Characters.CoreClasses
{
    public class PlayableCharacter : Character
    {
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
