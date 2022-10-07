using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services.Characters
{
    public class CreatePlayer
    {
        Player player = new Player();
        List<Player> playerList = new List<Player>();
        List<int> attributePoints = new List<int>();

        bool isPlayerCreated = false;

        ConsoleColor ccWhite = ConsoleColor.White;
        ConsoleColor ccYellow = ConsoleColor.Yellow;
        ConsoleColor ccRed = ConsoleColor.Red;
        public void Create()
        {
            while (true)
            {
                Utilities.WriteLineColorText("What do you want to do?", ccWhite, consoleClear: true);
                Console.WriteLine("1. Use already created adventurer\n2. Create your own adventurer\n3. Delete your adventurer\n4. Display statistics\n0. Test functionality");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        CreateDefaultPlayer();
                        break;
                    case 2:
                        CreateCustomPlayer();
                        break;
                    case 3:
                        DeletePlayer();
                        break;
                    case 4:
                        DisplayStatistics();
                        break;
                    case 9:
                        GenerateAttributePoints();
                        break;
                    case 0:
                        GenerateAttributePoints();
                        //AddAttributePoints(Attributes.Strength);
                        DisplayListAttributes(attributePoints);
                        break;
                    default:
                        break;
                }
            }
        }
        public void CreateDefaultPlayer()
        {
            if (isPlayerCreated)
            {
                Utilities.WriteLineColorText("Player already exists. You can have only 1 adventurer", ccRed, consoleClear: true);
                Utilities.PressAnyKey();
                return;
            }
            playerList.Clear();
            playerList.Add(new Player
            {
                Name = "Jaheira",
                Race = "Human",
                CharClass = "Warrior",
                HealthPoints = 10,
                Level = 1,
                Strength = 18,
                Dexterity = 17,
                Constitution = 18,
                Intelligence = 11,
                Wisdom = 14,
                Charisma = 16
            });
            isPlayerCreated = true;
        }
        public void CreateCustomPlayer()
        {
            if (isPlayerCreated)
            {
                Utilities.WriteLineColorText("Player already exists. You can have only 1 adventurer", ccRed, consoleClear: true);
                Utilities.PressAnyKey();
                return;
            }
            playerList.Clear();
            Utilities.WriteLineColorText("Tell me your name: ", firstColor: ccWhite, consoleClear: true);
            string name = Utilities.InputDataAsString(Utilities.rgxAZ);
            Utilities.WriteLineColorText("Choose your race: ", firstColor: ccWhite);
            string race = Console.ReadLine();
            Utilities.WriteLineColorText("Choose your class: ", firstColor: ccWhite);
            string charClass = Console.ReadLine();
            playerList.Add(new Player
            {
                Name = name,
                Race = race,
                CharClass = charClass

            });
            Console.WriteLine("Spend your points on attributes");
            //
            GenerateAttributePoints();

            Utilities.PressAnyKey();
            isPlayerCreated = true;

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
                //Console.WriteLine("lowestValues: " + lowestValues);
                int index = valueRollDiceTemp.IndexOf(lowestValues);
                //Console.WriteLine("index of lowValues: " + index);
                valueRollDiceTemp.RemoveAt(index);
                int sum = 0;

                foreach (var item in valueRollDiceTemp)
                {
                    sum += item;
                    Console.Write(item + ",");
                }
                Console.WriteLine("");
                attributePoints.Add(sum);               
            }
            foreach (var item in attributePoints)
            {
                Console.WriteLine(item);
            }
            Utilities.PressAnyKey();
        }
        public void AddAttributePoints(Attributes attribute)
        {
            int minValue = attributePoints.Min();
            int maxValue = attributePoints.Max();
            switch (attribute)
            {
                case Attributes.Strength:
                    Console.WriteLine($"Attribute {attribute}: ");
                    player.Strength =  Utilities.InputDataAsInt(minValue,maxValue);
                    break;
                case Attributes.Dexterity:
                    Console.WriteLine($"Attribute {attribute}: ");
                    player.Dexterity = Utilities.InputDataAsInt(minValue, maxValue);
                    break;
                case Attributes.Constitution:
                    Console.WriteLine($"Attribute {attribute}: ");
                    player.Constitution = Utilities.InputDataAsInt(minValue, maxValue);
                    break;
                case Attributes.Intelligence:
                    Console.WriteLine($"Attribute {attribute}: ");
                    player.Intelligence = Utilities.InputDataAsInt(minValue, maxValue);
                    break;
                case Attributes.Wisdom:
                    Console.WriteLine($"Attribute {attribute}: ");
                    player.Wisdom = Utilities.InputDataAsInt(minValue, maxValue);
                    break;
                case Attributes.Charisma:
                    Console.WriteLine($"Attribute {attribute}: ");
                    player.Charisma = Utilities.InputDataAsInt(minValue, maxValue);
                    break;                    
                default:
                    break;
            }
        }
        public void DisplayListAttributes(List<int> list)
        {
            Console.Clear();
            Utilities.Underline('=', 3);
            int counter = 0;
            foreach (var item in list)
            {
                counter++;
                if (counter == 1)
                    Console.Write("| ID  |");
                Console.Write($"{counter,3} ");
                if (counter == list.Count())
                    Console.Write("|");
            }
            Console.WriteLine("");
            Utilities.Underline('=', 30);
            counter = 0;
            foreach (var item in list)
            {
                counter++;
                if (counter == 1)
                    Console.Write("| ATR |");
                Console.Write($"{item,3} ");
                if (counter == list.Count())
                    Console.Write("|");
            }
            Console.WriteLine("");
            Utilities.Underline('=', 30);
            Utilities.PressAnyKey();
        }
        public enum Attributes
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        }
        public void DeletePlayer()
        {
            if (!isPlayerCreated)
            {
                Utilities.WriteLineColorText("No adventurer to delete!", ccRed, true);
                Utilities.PressAnyKey();
            }
            playerList.Clear();
            isPlayerCreated = false;
        }
        public void SpendAttributePoints()
        {
            Console.WriteLine("Spend your points on attributes");
        }
        public void DisplayStatistics()
        {
            if (!isPlayerCreated)
            {
                Utilities.WriteLineColorText("No adventurer to delete!", ccRed, true);
                Utilities.PressAnyKey();
                return;
            }
            Console.Clear();
            foreach (var item in playerList)
            {
                //Console.WriteLine($"Name: {item.Name}\nRace: {item.Race}\nClass: {item.CharClass}\nHealthPoints: {item.HealthPoints}\nLevel: {item.Level}\n" +
                //    $"Strength: {item.Strength}\nDexterity: {item.Dexterity}\nConstitution: {item.Constitution}\nIntelligence: {item.Intelligence}\n" +
                //    $"Wisdom: {item.Wisdom}\nCharisma: {item.Charisma}\n");
                Utilities.WriteLineColorText($"Name: ", $"{item.Name}", secondColor: ccYellow, multiplierTab: 2);
                Utilities.WriteLineColorText($"Race: ", $"{item.Race}", secondColor: ccYellow, multiplierTab: 2);
                Utilities.WriteLineColorText($"Class: ", $"{item.CharClass}", secondColor: ccYellow, multiplierTab: 2);
                Utilities.WriteLineColorText($"HP: ", $"{item.HealthPoints}", secondColor: ccYellow, multiplierTab: 2);
                Utilities.WriteLineColorText($"Level: ", $"{item.Level}", secondColor: ccYellow, multiplierTab: 2);
                Utilities.WriteLineColorText($"Strength: ", $"{item.Strength}", secondColor: ccYellow, multiplierTab: 1);
                Utilities.WriteLineColorText($"Dexterity: ", $"{item.Dexterity}", secondColor: ccYellow, multiplierTab: 1);
                Utilities.WriteLineColorText($"Constitution: ", $"{item.Constitution}", secondColor: ccYellow, multiplierTab: 1);
                Utilities.WriteLineColorText($"Intelligence: ", $"{item.Intelligence}", secondColor: ccYellow, multiplierTab: 1);
                Utilities.WriteLineColorText($"Wisdom: ", $"{item.Wisdom}", secondColor: ccYellow, multiplierTab: 1);
                Utilities.WriteLineColorText($"Charisma: ", $"{item.Charisma}", secondColor: ccYellow, multiplierTab: 1);
            }
            Utilities.PressAnyKey();
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
