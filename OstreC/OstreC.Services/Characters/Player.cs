using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services.Characters
{
    public class Player
    {
        public string Name { get; set; } = "Khalid";
        public string Race { get; set; } = "Human";
        public string CharClass { get; set; } = "Warrior";
        public int HealthPoints { get; set; } = 100;
        public int Level { get; set; } = 1;

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int ModStrength { get; set; }
        public int ModDexterity { get; set; }
        public int ModConstitution { get; set; }
        public int ModIntelligence { get; set; }
        public int ModWisdom { get; set; }
        public int ModCharisma { get; set; }
    }
}
