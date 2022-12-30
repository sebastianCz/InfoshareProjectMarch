using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using OstreCWEB.Data.Repository.Characters.Enums;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    //Playable races will need to have all the "skills" listed for the moment of creation. 
    //TODO: Replace this by "Race builder" once Entity Framework is added. 
    public class PlayableRace
    {
        [Key]
        public int PlayableRaceId { get; set; }

        public string RaceName { get; set; }
        [NotMapped]
        public List<Skill> DefaultSkillsForClass { get; set; }
        public int AmountOfSkillsToChoose { get; set; }

        public int IntelligenceBonus { get; set; }
        public int StrengthBonus { get; set; }
        public int WisdomBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int ConstitutionBonus { get; set; }
        public int CharismaBonus { get; set; }


        //EF relation
        public List<PlayableCharacter> PlayableCharacter { get; set; }   
    }
}
