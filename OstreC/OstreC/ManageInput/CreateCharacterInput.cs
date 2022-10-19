using OstreC.Services;
using System.Numerics;

namespace OstreC.ManageInput
{ //Creates an isntance of " PLAYER" object. Will be sending this to a save file. 
    public class CreateCharacterInput : IuiInput
    {
        public PageType Type => PageType.Create_Character;
        //UI ui = new UI(); // stackoverflow
        Player Player = new Player();

        ConsoleColor ccWhite = ConsoleColor.White;
        ConsoleColor ccRed = ConsoleColor.Red;
        ConsoleColor ccYellow = ConsoleColor.Yellow;
        ConsoleColor ccDarkCyan = ConsoleColor.DarkCyan;
        public void CheckUserInput(UI UI)
        {
            //CreateCharacterHelper createCharacterHelper = new CreateCharacterHelper();
            //createCharacterHelper.CreateMenu();
            var input = Console.ReadLine();

            if (Helpers.IsCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);                
            }
            switch (input)
            {
                case "1":                
                    CreateDefaultPlayer();
                    break;
                case "2":
                    CreateCustomPlayer();
                    break;
                case "3":
                    DeletePlayer();
                    break;
                case "4":
                    DisplayStatistics();
                    break;
                case "5":
                    SavePlayerToList();
                    //This will serialize the character to a new file or override existing ones.
                    Player.SavePlayer(Player, (ProgramSession)UI);
                    break;
                case "6":
                    ExitToMainMenu();
                    break;
                case "7":
                    //Console.WriteLine(Player.Strength);
                    //Console.WriteLine(Player.ModStrength);
                    //Utilities.PressAnyKey();
                    break;
                case "8":
                    //Player.UpdatePropertyValue(Player);
                    break;
                case "9":
                    //createPlayer.GenerateAttributePoints();
                    //AddAttributePoints(Attributes.Strength);
                    //DisplayListAttributes();
                    break;
                default:
                    UI.Page.PageInfo = "Character creation page";
                    UI.Page.Error = "You didn't provide a correct number";
                    UI.DrawUI(UI, false);
                    break;
            }
            #region Switch 01
            void CreateDefaultPlayer()
            {
                if (Player.IsPlayerCreated)
                {
                    UI.Page.PageInfo = "Use already created adventurer";
                    UI.Page.Error = "Player already exists. You can have only 1 adventurer";
                    UI.DrawUI(UI, false);
                    //Utilities.PressAnyKey();
                    return;
                }
                if (!Player.IsPlayerCreated)
                {
                    UI.Page.PageInfo = "Default Player was created";
                    UI.Page.Error = "";
                    UI.DrawUI(UI, false);
                    //Utilities.PressAnyKey();
                }
                Player.CreateDefaultPlayer();
            }
            #endregion
            #region Switch 02
            void CreateCustomPlayer()
            {
                if (Player.IsPlayerCreated)
                {
                    UI.Page.PageInfo = "Create your own adventurer";
                    UI.Page.Error = "Player already exists. You can have only 1 active adventurer";
                    UI.DrawUI(UI, false);
                    //Utilities.PressAnyKey();
                    return;
                }
                if (!Player.IsPlayerCreated)
                {
                    Utilities.WriteLineColorText("Tell me your name: ", firstColor: ccWhite);
                    Player.AddName();
                    Utilities.WriteLineColorText("Choose your race: ", firstColor: ccWhite);
                    Player.AddRace();
                    Utilities.WriteLineColorText("Choose your class: ", firstColor: ccWhite);
                    Player.AddClass();

                    Player.GenerateAttributePoints();
                    DisplayListAttributes(Player.AttributePoints);

                    AddAttribute(Player.Attributes.Strength);
                    AddAttribute(Player.Attributes.Dexterity);
                    AddAttribute(Player.Attributes.Constitution);
                    AddAttribute(Player.Attributes.Intelligence);
                    AddAttribute(Player.Attributes.Wisdom);
                    AddAttribute(Player.Attributes.Charisma);

                    //Player.ModStrength = Player.CalculateModifier(Player.Strength);

                    Player.AddValueToProperty();
                    
                    UI.Page.PageInfo = "Custom adventurer was created";
                    UI.Page.Error = "";
                    Utilities.PressAnyKey();
                    UI.DrawUI(UI, false);
                }
            }
            #endregion
            #region Switch 03
            void DeletePlayer()
            {
                if (!Player.IsPlayerCreated)
                {
                    UI.Page.PageInfo = "Delete your adventurer";
                    UI.Page.Error = "No adventurer to delete!";
                    UI.DrawUI(UI, false);
                    //Utilities.PressAnyKey();
                    return;
                }
                if (Player.IsPlayerCreated)
                {
                    UI.Page.PageInfo = "Delete your adventurer";
                    UI.Page.Error = "Do you really want to delete your adventurer?\nPress Y - yes; Press N - no";
                    UI.DrawUI(UI, false);
                    //Console.WriteLine("Do you really want to delete your adventurer?\nPress Y - yes; Press N - no");
                    string input = Utilities.InputDataAsString(Utilities.rgxYN).ToLower();
                    if (input == "y")
                    {
                        UI.Page.PageInfo = "Adventurer was deleted";
                        UI.Page.Error = "";
                        UI.DrawUI(UI, false);
                        //Utilities.PressAnyKey();
                        Player.IsPlayerCreated = false;
                        Player.DeletePlayer();
                    }
                    else
                    {
                        UI.Page.PageInfo = "Oh, you have changed your mind";
                        UI.Page.Error = "";
                        UI.DrawUI(UI, false);
                        //Utilities.PressAnyKey();
                    }
                }
            }
            #endregion
            #region Switch 04
            void DisplayStatistics()
            {
                Console.Clear();
                UI.Page.switchPage(PageType.Create_Character, UI);
                if (!Player.IsPlayerCreated)
                {
                    UI.Page.PageInfo = "Display statistics";
                    UI.Page.Error = "No data to display";
                    UI.DrawUI(UI, false);
                    //Utilities.PressAnyKey();
                    return;
                }
                DisplayStatisticsNew();
                Utilities.PressAnyKey();
                UI.DrawUI(UI, false);
            }
            #endregion
            #region Switch 05
            void SavePlayerToList()
            {
                if (!Player.IsPlayerCreated)
                {
                    UI.Page.PageInfo = "Save your adventurer";
                    UI.Page.Error = "First you have to create an adventurer";
                    UI.DrawUI(UI, false);
                    //Utilities.PressAnyKey();
                    return;
                }
                UI.Page.PageInfo = "Adventurer was created sucessfully";
                UI.DrawUI(UI, false);
                Player.AddPropertiesToList();
               
                //Utilities.PressAnyKey();
            }
            #endregion
            #region Switch 06
            void ExitToMainMenu()
            {
                UI.Page.switchPage(PageType.Main_Menu, UI);
            }
            #endregion
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
            //if (!(attr == Player.Attributes.Charisma))
            //{
            //    DisplayListAttributes(Player.AttributePoints);
            //}
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

            Utilities.WriteLineColorText($"{Player.Attributes.Strength}:", $"{tab}{Player.Strength}{tab}{Player.ModStrength.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Dexterity}:", $"{tab}{Player.Dexterity}{tab}{Player.ModDexterity.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Constitution}:", $"{tab}{Player.Constitution}{tab}{Player.ModConstitution.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Intelligence}:", $"{tab}{Player.Intelligence}{tab}{Player.ModIntelligence.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Wisdom}:", $"{tab}\t{Player.Wisdom}{tab}{Player.ModWisdom.ToString(format)}", ccWhite, ccYellow);
            Utilities.WriteLineColorText($"{Player.Attributes.Charisma}:", $"{tab}{Player.Charisma}{tab}{Player.ModCharisma.ToString(format)}", ccWhite, ccYellow);
            Utilities.Underline('=', i);
        }
        private void DisplayStatisticsNew()
        {
            Console.Clear(); // comment if u don't want to remove main schema menu for create Player
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
    }
}
