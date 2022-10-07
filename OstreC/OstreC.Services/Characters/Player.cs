using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services.Characters
{
    internal class Player
    {
        public string Name { get; set; } = "Khalid";
        public string Race { get; set; } = "Human";
        public string CharClass { get; set; } = "Warrior";
        public int HealthPoints { get; set; } = 100;
        public int Level { get; set; } = 1;

        public int Strength { get; set; } = 18;
        public int Dexterity { get; set; } = 16;
        public int Constitution { get; set; } = 18;
        public int Intelligence { get; set; } = 11;
        public int Wisdom { get; set; } = 14;
        public int Charisma { get; set; } = 16;
    }
}
