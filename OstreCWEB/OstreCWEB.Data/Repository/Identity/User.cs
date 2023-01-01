
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using OstreCWEB.Data.Repository.Characters.CoreClasses;
using OstreCWEB.Data.Repository.StoryModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstreCWEB.Data.Repository.Identity
{
    public class User : IdentityUser
    {  //EF config
        [Key]
        public int Id { get; set; } 
        //public List<PlayableCharacter> CharactersCreated { get; set; }
        ////
        //[NotMapped]
        //public PlayableCharacter ActiveCharacter { get; set; }

        public bool LoggedIn { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public int ActiveStoryId { get; set; }
        //public List<Story> StoriesCreated { get; set; }
      
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }
      
        public User()
        {
            //StoriesCreated = new List<Story>();
            //CharactersCreated = new List<PlayableCharacter>();
        }
        public User(int id, bool loggedIn, string userName, string password, string email, List<Story> storiesCreated, List<PlayableCharacter> charactersCreated, int storiesCompleted, int damageDealt, int damageReceived)
        {
            Id = id;
            LoggedIn = loggedIn;
            UserName = userName;
            Password = password;
            Email = email;
            //StoriesCreated = storiesCreated;
            //CharactersCreated = charactersCreated;
            StoriesCompletedTotal = storiesCompleted;
            DamageDealt = damageDealt;
            DamageReceived = damageReceived;
        }
    }
}
