using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.Game;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.ViewModel.Identity
{
    public class UserView
    {
        public List<PlayableCharacterView> CharactersCreated { get; set; }
        public List<StoryDetailsView> StoriesCreated { get; set; }
        public List<GameInstanceView> SavedGameSessions { get; set; }
        // 
        public UserParagraph ActiveGameSession { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }
    }
}
