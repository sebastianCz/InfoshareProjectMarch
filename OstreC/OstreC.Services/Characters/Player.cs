using OstreC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OstreC.Services;





namespace OstreC.Services
{
    public class Player:Character
    {

        List<Character> playerList = new List<Character>();
        public List<int> attributePoints = new List<int>();

        public bool isPlayerCreated = false;
        int userIdKey = 3; //Allows to link player instance to user. When character is created this INT should be assigned based on Program.currentUser.Id
        string name;
        string race;
        string charClass;
        public void CreateDefaultPlayer()
        {
            Name = "Jaheira";
            Race = "Human";
            CharClass = "Warrior";            
            Level = 1;

            Strength = 18;
            Dexterity = 17;
            Constitution = 18;
            Intelligence = 10;
            Wisdom = 14;
            Charisma = 16;

            HealthPoints = CalculateHealthPoints();

            ModStrength = 4;
            ModDexterity = 3;
            ModConstitution = 4;
            ModIntelligence = 0;
            ModWisdom = 2;
            ModCharisma = 3;

            isPlayerCreated = true;
        }
        public void AddName()
        {
            name = Utilities.InputDataAsString(Utilities.rgxAZ);
        }
        public void AddRace()
        {
            race = Console.ReadLine();
        }
        public void AddClass()
        {
            charClass = Console.ReadLine();
        }
        public void AddValueToProperty()
        {
            Name = name;
            Race = race;
            CharClass = charClass;
            Level = 1;

            Strength = Strength;
            Dexterity = Dexterity;
            Constitution = Constitution;
            Intelligence = Intelligence;
            Wisdom = Wisdom;
            Charisma = Charisma;

            HealthPoints = CalculateHealthPoints();

            ModStrength = CalculateModifier(Strength);
            ModDexterity = CalculateModifier(Dexterity);
            ModConstitution = CalculateModifier(Constitution);
            ModIntelligence = CalculateModifier(Intelligence);
            ModWisdom = CalculateModifier(Wisdom);
            ModCharisma = CalculateModifier(Charisma);

            isPlayerCreated = true;
        }
        public void AddPropertiesToList()
        {
            playerList.Add(new Character
            {
                Name = name,
                Race = race,
                CharClass = charClass,
                Strength = Strength,
                Dexterity = Dexterity,
                Constitution = Constitution,
                Intelligence = Intelligence,
                Wisdom = Wisdom,
                Charisma = Charisma,
                ModStrength = CalculateModifier(Strength),
                ModDexterity = CalculateModifier(Dexterity),
                ModConstitution = CalculateModifier(Constitution),
                ModIntelligence = CalculateModifier(Intelligence),
                ModWisdom = CalculateModifier(Wisdom),
                ModCharisma = CalculateModifier(Charisma)
            });
            isPlayerCreated = true;
        }

        // do skończenia, trzeba obsłużyć wpisywanie wartości różnych od wartości na liście.
        public int AddAttributePoints(Attributes attribute)
        {
            //DisplayStatistics();
            int minValue = attributePoints.Min();
            //if (minValue == -1)
            //{
            //    classCounter++;
            //    minValue = attributePoints[classCounter];
            //}
            int maxValue = attributePoints.Max();
            //int minValue = 1;
            //int maxValue = 6;
            int input = Utilities.InputDataAsInt(minValue, maxValue);
            switch (attribute)
            {
                case Attributes.Strength:
                    ChangeValueFromList(attributePoints, input);
                    return Strength = input;
                case Attributes.Dexterity:
                    ChangeValueFromList(attributePoints, input);
                    return Dexterity = input;
                case Attributes.Constitution:
                    ChangeValueFromList(attributePoints, input);
                    return Constitution = input;
                case Attributes.Intelligence:
                    ChangeValueFromList(attributePoints, input);
                    return Intelligence = input;
                case Attributes.Wisdom:
                    ChangeValueFromList(attributePoints, input);
                    return Wisdom = input;
                case Attributes.Charisma:
                    ChangeValueFromList(attributePoints, input);
                    return Charisma = input;
                default:
                    return -1;
            }
        }
        public void RemoveValueFromList(List<int> list, int input)
        {
            list.Remove(input);
        }
        public void ChangeValueFromList(List<int> list, int input, bool isID = false)
        {
            if (isID)
            {
                if (list.Contains(input))
                {
                    list.RemoveAt(input - 1);
                    list.Insert(input - 1, 0);
                }
            }
            else
            {
                if (list.Contains(input))
                {
                    list.Insert(list.IndexOf(input), 0);
                    list.Remove(input);
                }                
            }
        }
        public void DeletePlayer()
        {
            playerList.Clear();
            isPlayerCreated = false;

            Strength = 0;
            Dexterity = 0;
            Constitution = 0;
            Intelligence = 0;
            Wisdom = 0;
            Charisma = 0;

            ModStrength = 0;
            ModDexterity = 0;
            ModConstitution = 0;
            ModIntelligence = 0;
            ModWisdom = 0;
            ModCharisma = 0;
        }
        public void GenerateAttributePoints()
        {
            if (!(attributePoints.Count() == 0))
            {
                attributePoints.Clear();
            }

            for (int i = 0; i < 6; i++)
            {
                List<int> valueRollDiceTemp = new List<int>();
                valueRollDiceTemp.Add(Utilities.DiceRoll(7));
                valueRollDiceTemp.Add(Utilities.DiceRoll(7));
                valueRollDiceTemp.Add(Utilities.DiceRoll(7));
                valueRollDiceTemp.Add(Utilities.DiceRoll(7));

                int lowestValues = valueRollDiceTemp.Min();
                int index = valueRollDiceTemp.IndexOf(lowestValues);
                valueRollDiceTemp.RemoveAt(index);
                int sum = 0;

                foreach (var item in valueRollDiceTemp)
                {
                    sum += item;
                }
                attributePoints.Add(sum);
            }
        }
        public void DisplayStatistics(params string[] List)
        {
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
        }
        //public void DisplayStatistics()
        //{
        //    PropertyInfo[] myAttributesInfo;
        //    // Get the properties of 'Type' class object.
        //    myAttributesInfo = player.GetType().GetProperties();
        //    Console.WriteLine("Properties of System.Type are:");
        //    for (int i = 0; i < myAttributesInfo.Length; i++)
        //    {
        //        Console.WriteLine(myAttributesInfo[i].Name.ToString());
        //        attrList.Add(myAttributesInfo[i].Name.ToString());
        //    }
        //}
        ///Nie tykać, wybuchnie!!!
        //private void LoadDefaultData()
        //{
        //    try
        //    {
        //        foreach (var tuple in playerList.Zip(playerList, (x, y) => (x, y)))
        //        {
        //            tuple.x = tuple.y;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
    }
}
