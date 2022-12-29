using OstreCWEB.ViewModel.Characters;

namespace OstreCWEB.ViewModel.SuperAdmin
{
    public class SuperAdminView
    { 
        public List<CharacterView> Characters { get; set; }
        public List<ItemView> Items { get; set; }
        public List<CharacterActionView> CharacterActions { get; set; }
        public List<StatusView> Statuses { get; set; }
        public List<SkillsView> Skills { get; set; }
        public List<PlayableClassView> Classes { get; set; }
        public List<PlayableRaceView> Races { get; set; }
    }
}
