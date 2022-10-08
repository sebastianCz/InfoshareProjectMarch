using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OstreC.Services.Characters.Player;

namespace OstreC.Services.Characters
{
    public class Character
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string CharClass { get; set; }
        public int HealthPoints { get; set; }
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

        public enum Attributes
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        }
        public void UpdatePropertyValue(Attributes attribute, int value = 1)
        {
            switch (attribute)
            {
                case Attributes.Strength:
                    Strength += value;
                    ModStrength = CalculateModifier(Strength);
                    break;
                case Attributes.Dexterity:
                    Dexterity += value;
                    ModDexterity = CalculateModifier(Dexterity);
                    break;
                case Attributes.Constitution:
                    Strength += value;
                    ModConstitution = CalculateModifier(Constitution);
                    break;
                case Attributes.Intelligence:
                    Strength += value;
                    ModIntelligence = CalculateModifier(Intelligence);
                    break;
                case Attributes.Wisdom:
                    Strength += value;
                    ModWisdom = CalculateModifier(Wisdom);
                    break;
                case Attributes.Charisma:
                    Strength += value;
                    ModCharisma = CalculateModifier(Charisma);
                    break;
                default:
                    break;
            }
        }
        public int CalculateModifier(int value)
        {
            List<int> numbers = new List<int>() {
                   -5,-4,-4,-3,-3,-2,-2,-1,-1, 0,
                    0, 1, 1, 2, 2, 3, 3, 4, 4, 5,
                    5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };

            return numbers.First(x => x == numbers[value - 1]);
        }
        public int CalculateHealthPoints()
        {
            return Constitution * 1;
        }

    }
}
