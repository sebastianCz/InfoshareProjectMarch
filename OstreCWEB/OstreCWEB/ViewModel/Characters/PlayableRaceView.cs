using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstreCWEB.ViewModel.Characters
{
    public class PlayableRaceView
    { 
        public int PlayableRaceId { get; set; }  
        public string RaceName { get; set; }  

        public int IntelligenceBonus { get; set; }
        public int StrengthBonus { get; set; }
        public int WisdomBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int ConstitutionBonus { get; set; }
        public int CharismaBonus { get; set; }
    }
}
