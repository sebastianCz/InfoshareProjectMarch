using System.Runtime.CompilerServices;
using OstreCWEB.Data.Repository.Characters.Enums;

namespace OstreCWEB.Data.Repository.Characters.CoreClasses
{
    //Playable races will need to have all the "skills" listed for the moment of creation. 
    //TODO: Replace this by "Race builder" once Entity Framework is added. 
    public class PlayableRace
    {
        public int ID { get; set; }
        public string RaceName { get; set; }
        public List<Skill> DefaultSkillsForClass { get; set; }
        public int AmountOfSkillsToChoose { get; set; }


    }
}
