
using Microsoft.AspNetCore.Identity;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.WebObjects;

namespace OstreCWEB.Data.Repository.Identity
{
    public class User : IdentityUser
    {  
        //Ef Config
        public List<PlayableCharacter> CharactersCreated { get; set; }
        public List<Story> StoriesCreated { get; set; }
        public List<GameInstance> SavedGameSessions { get; set; }
        // 
        public GameInstance ActiveGameSession { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } 
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }

      
        public User() : base()
        {
          CharactersCreated = new List<PlayableCharacter>();
          StoriesCreated = new List<Story>();
        }
     
    }
}
