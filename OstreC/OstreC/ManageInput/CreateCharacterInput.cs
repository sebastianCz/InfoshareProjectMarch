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
        ConsoleColor ccGreen = ConsoleColor.Green;
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
                    
                    if (Player.IsPlayerCreated) 
                    {     
                        bool saved = Player.SavePlayer(Player, (ProgramSession)UI);
                        if (saved)
                        {
                            UI.Page.PageInfo = "Create your own adventurer";
                            UI.Page.Error = "Character saved in characters folder under name:  " + Player.Name;
                            UI.DrawUI(UI, false);
                        }
                        else
                        {
                            UI.Page.PageInfo = "Create your own adventurer";
                            UI.Page.Error = "You can't override a character that wasn't created by you.";
                            UI.DrawUI(UI, false);
                        }
                    }
                     
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
                    while (true)
                    {
                        Console.Clear();
                        DisplaySubMenu("Character Creator");
                        Console.WriteLine(" 1. Choose name\n 2. Choose race\n 3. Choose class\n 4. Spend attribute points\n 5. Accept your character\n 6. Exit Character Creator");
                        var input = Console.ReadLine();

                        if (Helpers.IsCommand(input, UI))
                        {
                            Helpers.HandleCommand(input, UI);
                        }
                        switch (input)
                        {
                            case "1":
                                ChooseName();
                                break;
                            case "2":
                                ChooseRace();
                                break;
                            case "3":
                                ChooseClass();
                                break;
                            case "4":
                                SpendAttributePoints();
                                break;
                            case "5":
                                AcceptCharacter();
                                return;
                            case "6":
                                Exit();
                                return;
                            default:
                                break;
                        }
                    }
                    void ChooseName()
                    {
                        Console.Clear();
                        DisplaySubMenu("Choose your name");
                        //Utilities.WriteLineColorText("Tell me your name: ", firstColor: ccWhite);
                        Player.AddName();
                    }
                    void ChooseRace()
                    {
                        Console.Clear();
                        DisplaySubMenu("Choose your race");
                        //Console.WriteLine($"Race:{Player.Race}");
                        Utilities.DisplayList(Player.races);
                        //Utilities.WriteLineColorText("Choose your race: ", firstColor: ccWhite);
                        while (true)
                        {
                            string input = Utilities.InputDataAsString();
                            if (Player.races.Contains(input))
                            {
                                Player.AddRace(input);
                                //Console.WriteLine($"Race:{Player.Race}");
                                Utilities.PressAnyKey();
                                break;
                            }
                            else
                                Utilities.WriteLineColorText("You typed incorrect race", ccRed);
                        }

                    }
                    void ChooseClass()
                    {
                        Console.Clear();
                        DisplaySubMenu("Choose your class");
                        Utilities.DisplayList(Player.classes);
                        while (true)
                        {
                            string input = Utilities.InputDataAsString();
                            if (Player.classes.Contains(input))
                            {
                                Player.AddClass(input);
                                break;
                            }
                            else
                                Utilities.WriteLineColorText("You typed incorrect class", ccRed);
                        }
                    }
                    void SpendAttributePoints()
                    {
                        Console.Clear();
                        DisplaySubMenu("Spend your attribute points");
                        Player.GenerateAttributePoints();
                        DisplayListAttributes(Player.AttributePoints, true);
                        ConsoleKeyInfo cki;
                        while (true)
                        {
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.R)
                            {
                                Player.GenerateAttributePoints();
                                DisplayListAttributes(Player.AttributePoints, true);
                            }
                            if (cki.Key == ConsoleKey.S)
                            {
                                Player.SavedAttributePoints = Player.AttributePoints.ToList();
                                DisplayListAttributes(Player.AttributePoints, true);
                            }
                            if (cki.Key == ConsoleKey.L)
                            {
                                Player.AttributePoints = Player.SavedAttributePoints.ToList();
                                DisplayListAttributes(Player.AttributePoints, true);
                            }
                            if (cki.Key == ConsoleKey.Enter)
                                break;
                            if (cki.Key == ConsoleKey.Escape)
                                return;
                        }

                        AddAttribute(Player.Attributes.Strength);
                        AddAttribute(Player.Attributes.Dexterity);
                        AddAttribute(Player.Attributes.Constitution);
                        AddAttribute(Player.Attributes.Intelligence);
                        AddAttribute(Player.Attributes.Wisdom);
                        AddAttribute(Player.Attributes.Charisma);

                        Player.AddValueToProperty();
                        Utilities.PressAnyKey();
                    }
                    void AcceptCharacter()
                    {
                        string message = "Are you sure? You can't change all of these things later";
                        Utilities.WriteLineColorText(message, ConsoleColor.Yellow);
                        YesOrNoKey();
                        Player.IsPlayerCreated = true;
                        UI.Page.PageInfo = "Custom adventurer was created";
                        UI.Page.Error = "";
                        UI.DrawUI(UI, false);
                    }
                    void Exit()
                    {
                        string message = "Are you sure you want to quit?";
                        Utilities.WriteLineColorText(message, ConsoleColor.Yellow);
                        YesOrNoKey();
                        UI.Page.PageInfo = "You left the character creator";
                        UI.Page.Error = "The character was not created";
                        UI.DrawUI(UI, false);
                    }
                    void YesOrNoKey()
                    {
                        Utilities.WriteLineColorText("Press Y to Yes, N to No", ConsoleColor.DarkYellow);
                        while (true)
                        {
                            //Utilities.WriteLineColorText(message, ConsoleColor.Yellow);
                            
                            //Console.WriteLine("Press Y to Yes, N to No");
                            ConsoleKeyInfo cki;
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Y)
                                break;
                            else if (cki.Key == ConsoleKey.N)
                                CreateCustomPlayer();
                            else
                            {
                                // Capture current cursor position
                                var cursorTop = Console.CursorTop;
                                var cursorLeft = Console.CursorLeft;

                                // Clear the previous line (above the current position)
                                Console.SetCursorPosition(0, cursorTop);
                                Console.Write(new string(' ', Console.BufferWidth));

                                // Resume cusor at it's original position
                                Console.SetCursorPosition(cursorLeft, cursorTop - 1);
                                //Console.Write("You pressed the wrong button");
                                YesOrNoKey();
                            }
                        }
                    }
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
                        JsonFile.DeleteJsonFile("Characters\\" + Player.Name);
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
        void DisplaySubMenu(string text)
        {
            int underline = 38;
            Utilities.Underline('=', underline);
            Utilities.WriteLineColorText(text, firstColor: ccDarkCyan);
            Utilities.Underline('=', underline);
        }
        private void DisplayListAttributes(List<int> list, bool displayInfo = false)
        {
            Console.Clear();
            DisplaySubMenu("Spend Attribute Points");
            if (displayInfo)
            {
                //Console.Clear();
                //DisplaySubMenu("Spend Attribute Points");
                Utilities.WriteLineColorText("R - Roll again\nS - Save points\nL - Load saved points\nEnter - Accept points\nESC - Exit", ccGreen);
            }          
            string format = "+#.##;-#.##;+0";

            int sum = list.Sum(x => Convert.ToInt32(x));
            string tab = "\t";

            int i = 38;
            //Utilities.Underline('=', i);
            //Utilities.WriteLineColorText("Available Points", firstColor: ccDarkCyan);
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
