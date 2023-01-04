using OstreCWEB.Data.Repository.Characters.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OstreCWEB.ViewModel.Characters
{
    public class PlayableRaceView
    { 
        public int PlayableRaceId { get; set; } 
        public string RaceName { get; set; } 
        public int AmountOfSkillsToChoose { get; set; }
    }
}
