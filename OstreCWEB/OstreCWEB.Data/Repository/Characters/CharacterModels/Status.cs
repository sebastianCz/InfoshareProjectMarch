using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    public class Status
    {
        //EF config
        [Key]
        public int StatusId { get; set; }
        public List<CharacterAction>? CharacterActions { get; set; }
        //
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
