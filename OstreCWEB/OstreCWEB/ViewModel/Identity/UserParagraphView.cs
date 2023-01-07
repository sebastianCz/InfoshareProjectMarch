using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.ViewModel.Characters;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.ViewModel.Identity
{
    public class UserParagraphView
    {
        public int Id { get; }
        public UserView User { get; set; }
        public StoryView Story { get; set; }
        public ParagraphView Paragraph { get; set; }
        public PlayableCharacterView ActiveCharacter { get; set; }
    }
}
