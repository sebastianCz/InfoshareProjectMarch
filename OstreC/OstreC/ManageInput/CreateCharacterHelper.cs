using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OstreC.Interface;
using OstreC.Services.Characters;

namespace OstreC.ManageInput
{
    public class CreateCharacterHelper
    {
        UI UI = new UI();
        Player player = new Player();

        ConsoleColor ccWhite = ConsoleColor.White;
        ConsoleColor ccRed = ConsoleColor.Red;
        ConsoleColor ccYellow = ConsoleColor.Yellow;
        ConsoleColor ccDarkCyan = ConsoleColor.DarkCyan;
        public void CreateMenu()
        {            
            while (true)
            {
                Console.Clear();
                UI.Page.switchPage(PageType.Create_Character, UI);
                
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
                    case 7:
                        Console.WriteLine(player.Strength);
                        Console.WriteLine(player.ModStrength);
                        Utilities.PressAnyKey();
                        break;
                    case 8:
                        //player.UpdatePropertyValue(player);
                        break;
                    case 9:
                        //createPlayer.GenerateAttributePoints();
                        //AddAttributePoints(Attributes.Strength);
                        DisplayListAttributes();
                        break;
                    default:
                        break;
                }
            }
            Utilities.PressAnyKey();
        }
        #region
        private void CreateDefaultPlayer()
        {
            if (player.isPlayerCreated)
            {
                UI.Page.error = "Player already exists. You can have only 1 adventurer";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            if (!player.isPlayerCreated)
            {
                UI.Page.pageInfo = "Default player was created";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();                
            }
            player.CreateDefaultPlayer();
        }
        private void CreateCustomPlayer()
        {
            if (player.isPlayerCreated)
            {
                UI.Page.error = "Player already exists. You can have only 1 adventurer";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            if (!player.isPlayerCreated)
            {
                Utilities.WriteLineColorText("Tell me your name: ", firstColor: ccWhite);
                player.AddName();
                Utilities.WriteLineColorText("Choose your race: ", firstColor: ccWhite);
                player.AddRace();
                Utilities.WriteLineColorText("Choose your class: ", firstColor: ccWhite);
                player.AddClass();

                player.GenerateAttributePoints();
                DisplayListAttributes(player.attributePoints);

                AddAttribute(Player.Attributes.Strength);
                AddAttribute(Player.Attributes.Dexterity);
                AddAttribute(Player.Attributes.Constitution);
                AddAttribute(Player.Attributes.Intelligence);
                AddAttribute(Player.Attributes.Wisdom);
                AddAttribute(Player.Attributes.Charisma);

                //player.ModStrength = player.CalculateModifier(player.Strength);

                player.AddValueToProperty();
                UI.Page.pageInfo = "Custom adventurer was created";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
            }
        }
        private void AddAttribute(Player.Attributes attr)
        {
            Utilities.WriteLineColorText($"What's your {attr}: ", firstColor: ccWhite);
            player.AddAttributePoints(attr);
            switch (attr)
            {
                case Character.Attributes.Strength:
                    player.ModStrength = player.CalculateModifier(player.Strength);
                    break;
                case Character.Attributes.Dexterity:
                    player.ModDexterity = player.CalculateModifier(player.Dexterity);
                    break;
                case Character.Attributes.Constitution:
                    player.ModConstitution = player.CalculateModifier(player.Constitution);
                    break;
                case Character.Attributes.Intelligence:
                    player.ModIntelligence = player.CalculateModifier(player.Intelligence);
                    break;
                case Character.Attributes.Wisdom:
                    player.ModWisdom = player.CalculateModifier(player.Wisdom);
                    break;
                case Character.Attributes.Charisma:
                    player.ModCharisma = player.CalculateModifier(player.Charisma);
                    break;
                default:
                    break;
            }

            if (!(attr == Player.Attributes.Charisma))
            {
                DisplayListAttributes(player.attributePoints);
            }
        }
        private void DeletePlayer()
        {
            if (!player.isPlayerCreated)
            {                
                UI.Page.error = "No adventurer to delete!";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            if (player.isPlayerCreated)
            {
                Console.WriteLine("Do you really want to delete your adventurer?\nPress Y - yes; Press N - no");
                string input = Utilities.InputDataAsString(Utilities.rgxYN).ToLower();
                if (input == "y")
                {
                    UI.Page.pageInfo = "Adventurer was deleted";
                    UI.DrawUI(UI, false);
                    Utilities.PressAnyKey();
                    player.isPlayerCreated = false;
                }
                else
                {
                    UI.Page.pageInfo = "Oh, you have changed your mind";
                    UI.DrawUI(UI, false);
                    Utilities.PressAnyKey();
                }
            }
            player.DeletePlayer();
        }
        private void DisplayStatistics()
        {
            Console.Clear();
            UI.Page.switchPage(PageType.Create_Character, UI);
            if (!player.isPlayerCreated)
            {
                UI.Page.error = "No data to display";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            //player.DisplayStatistics();
            DisplayStatisticsNew();
            Utilities.PressAnyKey();
        }
        private void DisplayListAttributes()
        {
            DisplayListAttributes(player.attributePoints);
            Utilities.PressAnyKey();
        }
        public void DisplayStatisticsNew()
        {
            Console.Clear();
            string format = "+#.##;-#.##;+0";
            string tab = "\t\t";
            int underline = 40;
            
            Utilities.Underline(value: underline);
            Utilities.WriteLineColorText("Statistics", firstColor: ccDarkCyan);
            Utilities.Underline(value: underline);
            Utilities.WriteLineColorText("Attribute     | Value     | Modificator|", firstColor: ccWhite);
            Utilities.Underline(value: underline);
            Utilities.WriteLineColorText($"Name: ", $"{player.Name}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"Race: ", $"{player.Race}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"Class: ", $"{player.CharClass}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"HP: ", $"{player.HealthPoints}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"Level: ", $"{player.Level}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"Strength: ", $"{player.Strength}{tab}{player.ModStrength.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Dexterity: ", $"{player.Dexterity}{tab}{player.ModDexterity.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Constitution: ", $"{player.Constitution}{tab}{player.ModConstitution.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Intelligence: ", $"{player.Intelligence}{tab}{player.ModIntelligence.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Wisdom: ", $"{player.Wisdom}{tab}{player.ModWisdom.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Charisma: ", $"{player.Charisma}{tab}{player.ModCharisma.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.Underline(value: underline);
            Utilities.WriteLineColorText("Description", firstColor: ccDarkCyan);
            Utilities.Underline(value: underline);
        }
        public void DisplayListAttributes(List<int> list)
        {
            Console.Clear();
            string format = "+#.##;-#.##;+0";

            int sum = list.Sum(x => Convert.ToInt32(x));
            string tab = "\t";

            int i = 38;
            Utilities.Underline('=', i);
            Utilities.WriteLineColorText("Available Points", firstColor: ccDarkCyan);
            Utilities.Underline('=', i);
            int counter = 0;
            foreach (var item in list)
            {
                counter++;
                if (counter == 1)
                    Console.Write("| ID  |");
                Console.Write($"{counter,3} ");
                if (counter == list.Count())
                    Console.Write("| Sum |");
            }
            Console.WriteLine("");
            Utilities.Underline('=', i);
            counter = 0;
            foreach (var item in list)
            {
                counter++;
                if (counter == 1)
                    Console.Write("| ATR |");
                if (item == 0)
                    Utilities.WriteColorText($"  - ", firstColor: ConsoleColor.Yellow);
                else
                    Utilities.WriteColorText($"{item,3} ", firstColor: ConsoleColor.Yellow);
                if (counter == list.Count())
                    Console.Write($"|  {sum} |");
            }
            Console.WriteLine("");
            Utilities.Underline('=', i);
            Utilities.WriteLineColorText("Attributes", firstColor: ccDarkCyan);
            Utilities.Underline('=', i);

            Utilities.WriteLineColorText($"{Player.Attributes.Strength}:",$"{tab}{player.Strength}{tab}{player.ModStrength.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Dexterity}:",$"{tab}{player.Dexterity}{tab}{player.ModDexterity.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Constitution}:",$"{tab}{player.Constitution}{tab}{player.ModConstitution.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Intelligence}:",$"{tab}{player.Intelligence}{tab}{player.ModIntelligence.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Wisdom}:",$"{tab}\t{player.Wisdom}{tab}{player.ModWisdom.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Charisma}:",$"{tab}{player.Charisma}{tab}{player.ModCharisma.ToString(format)}", ccWhite, ccYellow);
            Utilities.Underline('=', i);
        }
        #endregion
    }
}
