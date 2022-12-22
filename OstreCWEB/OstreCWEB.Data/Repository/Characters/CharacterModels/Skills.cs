using OstreCWEB.Data.Repository.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.CoreClasses
{
    internal class Skills
    {
        public int ID { get; set; }
        public string SkillName { get; set; }
        public Statistics StatisticForTest { get; set; }
    }
}
