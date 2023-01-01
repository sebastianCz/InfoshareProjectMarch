using OstreCWEB.ViewModel.Characters;

namespace OstreCWEB.ViewModel.Identity
{
    public class UserView
    {
        public string Id { get; set; }
        public List<CharacterView> CharactersCreated { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; } 
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }
    }
}
