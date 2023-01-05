using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;
namespace OstreCWEB.ViewModel.Characters
{
    public class PlayableClassView
    {
        public int PlayableClassId { get; set; }
        public string ClassName { get; set; }
        public int IntelligenceBonus { get; set; }
        public int StrengthBonus { get; set; }
        public int WisdomBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int ConstitutionBonus { get; set; }
        public int CharismaBonus { get; set; }
    }
}
