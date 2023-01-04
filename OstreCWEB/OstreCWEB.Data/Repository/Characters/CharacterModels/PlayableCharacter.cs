using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Identity;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    public class PlayableCharacter : Character
    { 
        //Ef config
        [Required]
        public string UserId { get; set; }//Id of character owner
        public User User { get; set; }
        //

        [Required] 
        public PlayableRace Race { get; set; }
        public int RaceId { get; set; }
        public PlayableClass CharacterClass { get; set; } 
        public int PlayableClassId { get; set; } 
        public PlayableCharacter()
        {
        }
    }
}
