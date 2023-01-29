using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System.ComponentModel;

namespace OstreCWEB.ViewModel.Characters
{
    public class StatusView
    { 
        public int StatusId { get; set; }
        [DisplayName("Status name")]
        public string Name { get; set; }
        [DisplayName("Status description")]
        public string Description { get; set; }
    }
}
