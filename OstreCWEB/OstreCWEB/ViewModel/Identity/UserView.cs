using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.WebObjects;
using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.StoryBuilder;
using OstreCWEB.ViewModel.Game;

namespace OstreCWEB.ViewModel.Identity
{
    public class UserView
    {
        public List<PlayableCharacterView> CharactersCreated { get; set; }
        public List<StoryDetailsView> StoriesCreated { get; set; }
        public List<GameInstanceView> SavedGameSessions { get; set; }
        // 
        public GameInstance ActiveGameSession { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }
    }
}
