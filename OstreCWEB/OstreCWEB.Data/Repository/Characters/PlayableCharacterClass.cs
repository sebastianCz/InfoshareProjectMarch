﻿using OstreCWEB.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters
{
    public class PlayableCharacterClass
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public Dictionary<Statistics, int> BonusesForEeachStatistic { get; set; }
    }
}
