using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.StoryBuilder;
using OstreCWEB.ViewModel.User;

namespace OstreCWEB.ViewModel.StoryReader
{ 
    public class StartGameView
    {
        //This class will be merged with story reader next week. 
       public UserView User { get; set; }
       public GameInstanceView GameSession { get; set; } 
       public List<PlayableCharacterDetailsView> Characters { get; set; }
       public List<StoryDetailsView> Stories { get; set; }
    }
}
