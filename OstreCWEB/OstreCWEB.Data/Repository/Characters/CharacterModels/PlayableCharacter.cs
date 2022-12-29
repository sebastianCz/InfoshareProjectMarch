using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.Identity;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    public class PlayableCharacter : Character
    {  
        public PlayableCharacter()
        {

        }
        //Id used to "link" the character to a user in db later on. 
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]

        public PlayableRace Race { get; set; }
        public int RaceId { get; set; }
        public PlayableCharacterClass CharacterClass { get; set; }
        public int PlayableClassId { get; set; }


    }
}
