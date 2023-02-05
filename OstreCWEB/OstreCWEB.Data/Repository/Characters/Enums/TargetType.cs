using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OstreCWEB.Data.Repository.Characters.Enums
{
    public enum TargetType
    {
        [Display(Name = "Yourself")]
        Caster = 1,
        [Display(Name = "Enemy")]
        Target = 2
    }
}
