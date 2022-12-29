using OstreCWEB.Data.Repository.Characters.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    public class PlayableCharacterClass
    {
        public int PlayableCharacterClassId { get; set; }
        public string ClassName { get; set; }
        [NotMapped]
        public Dictionary<Statistics, int> BonusesForEeachStatistic { get; set; }

        public List<PlayableCharacter> PlayableCharacter { get; set; }
        public int PlayableCharacterId { get; set; }
    }
}
