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
        
        //Ef config
        [Required]
        public int UserId { get; set; }//Id of character owner
        public User User { get; set; }
        //

        [Required]

        public PlayableRace Race { get; set; }
        public int RaceId { get; set; }
        public PlayableClass CharacterClass { get; set; }
        public int PlayableClassId { get; set; }


    }
}
