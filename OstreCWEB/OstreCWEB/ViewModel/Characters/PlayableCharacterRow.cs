using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.MetaTags;

namespace OstreCWEB.ViewModel.Characters
{
    public class PlayableCharacterRow
    { 
        public int CharacterId { get; set; } 
        public string CharacterName { get; set; } 
        public PlayableRaceView Race { get; set; } 
        public PlayableClassView CharacterClass { get; set; } 
    }
}