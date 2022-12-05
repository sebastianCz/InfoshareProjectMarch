using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository
{
    internal class PlayableCharacter : Character
    {
        //Id used to "link" the character to a user in db later on. 
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Class { get; set; }
        
    }
}
