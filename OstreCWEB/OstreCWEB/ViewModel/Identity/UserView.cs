using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.ViewModel.Identity
{
    public class UserView
    {
        public List<PlayableCharacterRow> CharactersCreated { get; set; }
        public List<StoriesView> StoriesCreated { get; set; }
        public List<UserParagraphView> UserParagraphs { get; set; }
        //  
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int StoriesCompletedTotal { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }
    }
}
