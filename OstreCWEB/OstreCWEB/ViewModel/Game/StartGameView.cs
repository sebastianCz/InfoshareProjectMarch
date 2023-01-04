using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.StoryBuilder;
using OstreCWEB.ViewModel.Identity;

namespace OstreCWEB.ViewModel.Game
{ 
    public class StartGameView
    {
        //This class will be merged with story reader next week. 
       public UserView User { get; set; } 
       public List<PlayableCharacterView> OtherUsersCharacters { get; set; }
       public List<StoryDetailsView> OtherUsersStories { get; set; }
    }
}
