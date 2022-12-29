using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
