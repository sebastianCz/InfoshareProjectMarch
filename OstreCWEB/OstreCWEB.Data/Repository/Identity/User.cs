 
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.StoryModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OstreCWEB.Data.Repository.Identity
{
    public class User : IdentityUser
    {  //EF config 
        public List<PlayableCharacter> CharactersCreated { get; set; } 
        //
        
        [NotMapped]
        public PlayableCharacter ActiveCharacter { get; set; }

        public bool LoggedIn { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
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
