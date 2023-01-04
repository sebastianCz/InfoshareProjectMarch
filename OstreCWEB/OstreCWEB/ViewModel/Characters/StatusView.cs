using OstreCWEB.Data.Repository.Characters.CharacterModels;

namespace OstreCWEB.ViewModel.Characters
{
    public class StatusView
    { 
        public int StatusId { get; set; }
        public List<CharacterAction>? CharacterActions { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
