
using Microsoft.AspNetCore.Identity;
using OstreCWEB.Data.Repository.StoryModels;
using System.ComponentModel.DataAnnotations;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
namespace OstreCWEB.Data.Repository.Identity
{
    public class User : IdentityUser
    {  
        //Ef Config
        public List<PlayableCharacter> CharactersCreated { get; set; }
       
        //
         
        public bool LoggedIn { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int ActiveStoryId { get; set; } 
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }

      
        public User() : base()
        {
          
        }
     
    }
}
