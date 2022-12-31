using OstreCWEB.Data.Repository.Characters.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    public class CharacterSkills
    {
        //Ef Config
        [Key]
        public int SkillsId { get; set; }
        //If we want to add this class to character and use it: 
        //  Many to Many relationship between skills and characterClasses -> Each class can grant X skills
        //  Many to Many relationship between skills and Characters( since a  given character can be proficient in a given skill or not)
        //
        public string SkillName { get; set; }
        public Statistics StatisticForTest { get; set; }
        public bool IsProficient { get; set; }

    }
}
