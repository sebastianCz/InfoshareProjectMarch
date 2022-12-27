using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.CoreClasses
{
    public class Status
    {
        //EF config
        [Key]
        public int StatusId { get; set; }
        public CharacterAction CharacterActions { get; set; }
        public int CharacterActionId { get; set; }
        //
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
