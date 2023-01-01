using Microsoft.AspNetCore.Identity;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstreCWEB.Data.Repository.Identity
{
    public class User : IdentityUser
    {  //EF config 
        public List<PlayableCharacter> CharactersCreated { get; set; } 
        //
        
        [NotMapped]
        public PlayableCharacter ActiveCharacter { get; set; }

        public bool LoggedIn { get; set; } 
        public string Password { get; set; } 
        public DateTime Created { get; set; }
        public int ActiveStoryId { get; set; }
        //public List<Story> StoriesCreated { get; set; }
      
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }
      
        public User():base()
        {
            //StoriesCreated = new List<Story>();
            //CharactersCreated = new List<PlayableCharacter>();
        }
    
    }
}
