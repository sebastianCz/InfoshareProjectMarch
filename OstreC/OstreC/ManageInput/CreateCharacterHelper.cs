using System;
using OstreC.Services;


namespace OstreC.ManageInput
{//Helper methods for create character class.
    internal class CreateCharacterHelper
    {
        UI UI = new UI();
        Player Player = new Player();
        
        ConsoleColor ccWhite = ConsoleColor.White;
        ConsoleColor ccRed = ConsoleColor.Red;
        ConsoleColor ccYellow = ConsoleColor.Yellow;
        ConsoleColor ccDarkCyan = ConsoleColor.DarkCyan;
        public void CreateMenu()
        {
            bool MenuState = true;
            while (MenuState)
            {
                Console.Clear();
                UI.Page.switchPage(PageType.Create_Character, UI);
                int.TryParse(Console.ReadLine(), out int input);
                //int input = Utilities.InputDataAsInt(1, 10);
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
                        DisplayStatisticsMenu();
                        break;
                    case 5:
                        SavePlayerToList();
                        break;
                    case 6:
                        MenuState = false;
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    default:
                        break;
                }
            }
        }

 
        private void SavePlayerToList()
        {
            if (!Player.IsPlayerCreated)
            {
                UI.Page.PageInfo = "Save your adventurer";
                UI.Page.Error = "First you have to create an adventurer";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            UI.Page.PageInfo = "Adventurer was created sucessfully";
            UI.DrawUI(UI, false);
            Player.AddPropertiesToList();
            Utilities.PressAnyKey();
        }
        #region
        private void CreateDefaultPlayer()
        {
            if (Player.IsPlayerCreated)
            {
                UI.Page.PageInfo = "Use already created adventurer";
                UI.Page.Error = "Player already exists. You can have only 1 adventurer";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            if (!Player.IsPlayerCreated)
            {
                UI.Page.PageInfo = "Default Player was created";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();                
            }
            Player.CreateDefaultPlayer();
        }
        private void CreateCustomPlayer()
        {
            if (Player.IsPlayerCreated)
            {
                UI.Page.PageInfo = "Create your own adventurer";
                UI.Page.Error = "Player already exists. You can have only 1 adventurer";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            if (!Player.IsPlayerCreated)
            {
                Utilities.WriteLineColorText("Tell me your name: ", firstColor: ccWhite);
                Player.AddName();
                Utilities.WriteLineColorText("Choose your race: ", firstColor: ccWhite);
                //Player.AddRace();
                Utilities.WriteLineColorText("Choose your class: ", firstColor: ccWhite);
                //Player.AddClass();

                Player.GenerateAttributePoints();
                DisplayListAttributes(Player.AttributePoints);

                AddAttribute(Player.Attributes.Strength);
                AddAttribute(Player.Attributes.Dexterity);
                AddAttribute(Player.Attributes.Constitution);
                AddAttribute(Player.Attributes.Intelligence);
                AddAttribute(Player.Attributes.Wisdom);
                AddAttribute(Player.Attributes.Charisma);

                Player.AddValueToProperty();
                UI.Page.PageInfo = "Custom adventurer was created";
                Utilities.PressAnyKey();
                UI.DrawUI(UI, false);                
            }
        }
        private void AddAttribute(Player.Attributes attr)
        {
            Utilities.WriteLineColorText($"What's your {attr}: ", firstColor: ccWhite);
            Player.AddAttributePoints(attr);
            switch (attr)
            {
                case Character.Attributes.Strength:
                    Player.ModStrength = Player.CalculateModifier(Player.Strength);
                    break;
                case Character.Attributes.Dexterity:
                    Player.ModDexterity = Player.CalculateModifier(Player.Dexterity);
                    break;
                case Character.Attributes.Constitution:
                    Player.ModConstitution = Player.CalculateModifier(Player.Constitution);
                    break;
                case Character.Attributes.Intelligence:
                    Player.ModIntelligence = Player.CalculateModifier(Player.Intelligence);
                    break;
                case Character.Attributes.Wisdom:
                    Player.ModWisdom = Player.CalculateModifier(Player.Wisdom);
                    break;
                case Character.Attributes.Charisma:
                    Player.ModCharisma = Player.CalculateModifier(Player.Charisma);
                    break;
                default:
                    break;
            }
            DisplayListAttributes(Player.AttributePoints);
        }
        private void DeletePlayer()
        {
            if (!Player.IsPlayerCreated)
            {
                UI.Page.PageInfo = "Delete your adventurer";
                UI.Page.Error = "No adventurer to delete!";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }
            if (Player.IsPlayerCreated)
            {
                UI.Page.PageInfo = "Delete your adventurer";
                UI.Page.Error = "Do you really want to delete your adventurer?\nPress Y - yes; Press N - no";
                UI.DrawUI(UI, false);

                string input = Utilities.InputDataAsString(Utilities.rgxYN).ToLower();
                if (input == "y")
                {
                    UI.Page.PageInfo = "Adventurer was deleted";
                    UI.Page.Error = "";
                    UI.DrawUI(UI, false);
                    Utilities.PressAnyKey();
                    Player.IsPlayerCreated = false;
                    JsonFile.DeleteJsonFile("Characters\\" + Player.Name);
                    Player.DeletePlayer();
                }
                else
                {
                    UI.Page.PageInfo = "Oh, you have changed your mind";
                    UI.Page.Error = "";
                    UI.DrawUI(UI, false);
                    Utilities.PressAnyKey();
                }
            }            
        }
        private void DisplayStatisticsMenu()
        {
            Console.Clear();
            UI.Page.switchPage(PageType.Create_Character, UI);
            if (!Player.IsPlayerCreated)
            {
                UI.Page.PageInfo = "Display statistics";
                UI.Page.Error = "No data to display";
                UI.DrawUI(UI, false);
                Utilities.PressAnyKey();
                return;
            }

            DisplayStatistics();
            Utilities.PressAnyKey();
        }
        private void DisplayListAttributes()
        {
            DisplayListAttributes(Player.AttributePoints);
            Utilities.PressAnyKey();
        }
        public void DisplayStatistics()
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
            Utilities.WriteLineColorText($"Name: ", $"{Player.Name}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"Race: ", $"{Player.Race}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"Class: ", $"{Player.CharClass}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"HP: ", $"{Player.HealthPoints}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"Level: ", $"{Player.Level}", secondColor: ccYellow, multiplierTab: 2);
            Utilities.WriteLineColorText($"Strength: ", $"{Player.Strength}{tab}{Player.ModStrength.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Dexterity: ", $"{Player.Dexterity}{tab}{Player.ModDexterity.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Constitution: ", $"{Player.Constitution}{tab}{Player.ModConstitution.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Intelligence: ", $"{Player.Intelligence}{tab}{Player.ModIntelligence.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Wisdom: ", $"{Player.Wisdom}{tab}{Player.ModWisdom.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.WriteLineColorText($"Charisma: ", $"{Player.Charisma}{tab}{Player.ModCharisma.ToString(format)}", secondColor: ccYellow, multiplierTab: 1);
            Utilities.Underline(value: underline);
            Utilities.WriteLineColorText("Description", firstColor: ccDarkCyan);
            Utilities.Underline(value: underline);
        }
        private void DisplayListAttributes(List<int> list)
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

            //Utilities.WriteLineColorText($"Name: ", $"{Player.Name}", ccWhite, ccYellow, multiplierTab: 1);
            //Utilities.WriteLineColorText($"Race: ", $"{Player.Race}", ccWhite, ccYellow, multiplierTab: 1);
            //Utilities.WriteLineColorText($"Class: ", $"{Player.CharClass}", ccWhite, ccYellow, multiplierTab: 1);

            Utilities.WriteLineColorText($"{Player.Attributes.Strength}:",$"{tab}{Player.Strength}{tab}{Player.ModStrength.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Dexterity}:",$"{tab}{Player.Dexterity}{tab}{Player.ModDexterity.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Constitution}:",$"{tab}{Player.Constitution}{tab}{Player.ModConstitution.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Intelligence}:",$"{tab}{Player.Intelligence}{tab}{Player.ModIntelligence.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Wisdom}:",$"{tab}\t{Player.Wisdom}{tab}{Player.ModWisdom.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Charisma}:",$"{tab}{Player.Charisma}{tab}{Player.ModCharisma.ToString(format)}", ccWhite, ccYellow);
            Utilities.Underline('=', i);
        }
        #endregion
    }
}
