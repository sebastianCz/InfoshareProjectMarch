using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    //Playable races will need to have all the "skills" listed for the moment of creation. 
    //TODO: Replace this by "Race builder" once Entity Framework is added. 
    public class PlayableRace
    {
        //Ef Config// 
        [Key]
        public int PlayableRaceId { get; set; }
        public List<PlayableCharacter> PlayableCharacter { get; set; } 
        //
   
        [NotMapped]
        public List<CharacterSkills> DefaultSkillsForClass { get; set; }
        public string RaceName { get; set; }
     
        public int AmountOfSkillsToChoose { get; set; }

        public int IntelligenceBonus { get; set; }
        public int StrengthBonus { get; set; }
        public int WisdomBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int ConstitutionBonus { get; set; }
        public int CharismaBonus { get; set; }

    }
}
