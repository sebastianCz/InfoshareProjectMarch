using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;
using System.ComponentModel.DataAnnotations.Schema; 
namespace OstreCWEB.ViewModel.Characters
{
    public class PlayableClassView
    {
        public int PlayableCharacterClassId { get; set; }
        public string ClassName { get; set; } 
        public Dictionary<Statistics, int> BonusesForEeachStatistic { get; set; } 
        public List<PlayableCharacter> PlayableCharacter { get; set; }
        public int PlayableCharacterId { get; set; }
    }
}
