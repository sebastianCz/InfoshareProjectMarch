using OstreC.Services;
using OstreC;
using OstreC.Interface;
using System;
using static System.Net.Mime.MediaTypeNames;
using OstreC.Services;
using Microsoft.Win32;

namespace OstreC.ManageInput
{
    public class StoryBuliderInput : IuiInput
    {
        public PageType Type => PageType.Story_Bulider;
        public int IdPage { get; private set; } = 0;
        private static int IdCreator { get; set; }
        public static Story CurrentStory { get; private set; }
        public void checkUserInput(UI UI)
        {

            string input = Console.ReadLine();
            string inputText = input;
            IdPage = CheckInput(input, UI, IdPage, inputText);
        }

        private static int CheckInput(string input, UI UI, int idPage, string inputText)
        {

            switch (idPage)
            {
                case 0: // Story Builder home page
                    {
                        IdCreator = 0;
                        input = input.ToUpper().Replace(" ", null);
                        if (Helpers.isCommand(input, UI)) return 0;
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "1")) // make a new story
                        {
                            UI.Page.pageInfo = "You've chosen to make a new story!";
                            UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\n\nLet's start with something easy, enter the name of the story:";
                            IdCreator = 0;
                            UI.DrawUI(UI, true);
                            return 1;
                        } // make a new story
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "2")) // load an existing history for editing
                        {
                            UI.Page.pageInfo = "You have chosen to load an existing history for editing!";
                            UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\n\nEnter a story name to edit: ";
                            IdCreator = -1;
                            UI.DrawUI(UI, true);
                            return 2;
                        } // load an existing history for editing
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "0")) // Main menu
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Are you sure? You go back to menu.\nPress 'Y' - yes or 'N' - no");
                            Console.ResetColor();
                            ConsoleKey key;
                            do
                            {
                                key = Console.ReadKey().Key;
                                switch (key)
                                {
                                    case ConsoleKey.Y:
                                        UI.Page.switchPage(PageType.Main_Menu, UI);
                                        return 0;
                                    case ConsoleKey.N:
                                        UI.DrawUI(UI, true);
                                        return idPage;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        } // Main menu
                        else
                        {
                            UI.Page.error = "You didn't type the correct option";
                            UI.DrawUI(UI, false);
                            return idPage;
                        }
                        return idPage;
                    }
                case 1: // create a new story
                    {
                        input = input.ToUpper().Replace(" ", null);
                        if (Helpers.isCommand(input, UI)) return 0;
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "1")) // Story Builder home page
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Are you sure? You go back to Story Builder home page.\nPress 'Y' - yes or 'N' - no");
                            Console.ResetColor();
                            ConsoleKey key;
                            do
                            {
                                key = Console.ReadKey().Key;
                                switch (key)
                                {
                                    case ConsoleKey.Y:
                                        UI.Page.switchPage(PageType.Story_Bulider, UI);
                                        return 0;
                                    case ConsoleKey.N:
                                        UI.DrawUI(UI, true);
                                        return idPage;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        } // Story Builder home page
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "0"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Are you sure? You go back to menu.\nPress 'Y' - yes or 'N' - no");
                            Console.ResetColor();
                            ConsoleKey key;
                            do
                            {
                                key = Console.ReadKey().Key;
                                switch (key)
                                {
                                    case ConsoleKey.Y:
                                        UI.Page.switchPage(PageType.Main_Menu, UI);
                                        return 0;
                                    case ConsoleKey.N:
                                        UI.DrawUI(UI, true);
                                        return idPage;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        } // Main menu
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "SAVE")) // Save
                        {
                            string serializedStory = JsonFile.SerializeStory(CurrentStory);
                            JsonFile.serializedToJson(serializedStory, CurrentStory.NameOfStory);
                            Console.WriteLine("Wykonano zapis, naciśnij cokolwiek aby kontynuować.");
                            UI.Page.error = "History saved!";
                            UI.DrawUI(UI, false);
                            UI.Page.error = "";
                            return idPage;
                        }
                        else
                        {
                            StoryCreator(UI, inputText);
                            UI.DrawUI(UI, false);
                            UI.Page.error = "";
                            return idPage;
                        }
                        return idPage;
                    }
                case 2: // load an existing story
                    {
                        input = input.ToUpper().Replace(" ", null);
                        if (Helpers.isCommand(input, UI)) return 0;
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "1")) // Story Builder home page
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Are you sure? You go back to Story Builder home page.\nPress 'Y' - yes or 'N' - no");
                            Console.ResetColor();
                            ConsoleKey key;
                            do
                            {
                                key = Console.ReadKey().Key;
                                switch (key)
                                {
                                    case ConsoleKey.Y:
                                        UI.Page.switchPage(PageType.Story_Bulider, UI);
                                        return 0;
                                    case ConsoleKey.N:
                                        UI.DrawUI(UI, true);
                                        return idPage;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        } // Story Builder home page
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "0"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Are you sure? You go back to menu.\nPress 'Y' - yes or 'N' - no");
                            Console.ResetColor();
                            ConsoleKey key;
                            do
                            {
                                key = Console.ReadKey().Key;
                                switch (key)
                                {
                                    case ConsoleKey.Y:
                                        UI.Page.switchPage(PageType.Main_Menu, UI);
                                        return 0;
                                    case ConsoleKey.N:
                                        UI.DrawUI(UI, true);
                                        return idPage;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        } // Main menu
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "SAVE")) // Save
                        {
                            string serializedStory = JsonFile.SerializeStory(CurrentStory);
                            JsonFile.serializedToJson(serializedStory, CurrentStory.NameOfStory);
                            Console.WriteLine("Wykonano zapis, naciśnij cokolwiek aby kontynuować.");
                            UI.Page.error = "History saved!";
                            UI.DrawUI(UI, false);
                            UI.Page.error = "";
                            return idPage;
                        }
                        else
                        {
                            StoryCreator(UI, inputText);
                            UI.DrawUI(UI, false);
                            UI.Page.error = "";
                            return idPage;
                        }
                        return idPage;
                    }
                default:
                    return idPage;
            }
        }

        private static void StoryCreator(UI UI, string inputText)
        {
            switch (IdCreator)
            {
                case -1: // Load exist Story
                    {
                        Console.WriteLine($"The name of your story is: {inputText}");

                        Console.WriteLine("\nAre you sure? \nPress 'Y' - yes or 'N' - no");
                        ConsoleKey key;
                        do
                        {
                            key = Console.ReadKey().Key;
                            switch (key)
                            {
                                case ConsoleKey.Y:
                                    CurrentStory = JsonFile.DeserializeStory(inputText);
                                    UI.Page.pageInfo = $"You create a {CurrentStory.NameOfStory} story!";
                                    UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\nType 'Save' to save changes!\nType 'New' to create a new paragraph\nEnter 'Link' to create a new paragraph link";
                                    IdCreator = 1;
                                    break;
                                case ConsoleKey.N:
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You didn't press the correct key. Try again.");
                                    Console.ResetColor();
                                    break;
                            }
                        } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        break;
                    }
                case 0: // Name for Story - creat new story
                    {
                        Console.WriteLine($"The name of your story is: {inputText}");

                        Console.WriteLine("\nAre you sure? \nPress 'Y' - yes or 'N' - no");
                        ConsoleKey key;
                        do
                        {
                            key = Console.ReadKey().Key;
                            switch (key)
                            {
                                case ConsoleKey.Y:
                                    UI.Page.pageInfo = $"You create a {inputText} story!";
                                    UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\nType 'Save' to save changes!\nType 'New' to create a new paragraph\nEnter 'Link' to create a new paragraph link";
                                    CurrentStory = new Story(inputText);
                                    CurrentStory.DeafaultParagraph();
                                    IdCreator = 1;
                                    break;
                                case ConsoleKey.N:
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You didn't press the correct key. Try again.");
                                    Console.ResetColor();
                                    break;
                            }
                        } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        break;
                    }
                case 1: // New or Link
                    {
                        switch (inputText.ToUpper().Replace(" ", null))
                        {
                            case "NEW":
                                CreatNewParagraph(UI);
                                break;
                            case "LINK":

                                break;
                            default:
                                UI.Page.error = "You didn't type the correct option";
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private static void CreatNewParagraph(UI UI)
        {
            List<Option> options = new List<Option>
            {
                new Option("DescOfStage", () => CreatNewDescOfStageParagraph(UI)),
                new Option("Fight", () =>  CreatNewFightParagraph(UI)),
                new Option("Dialog", () =>  CreatNewDialogParagraph(UI)),
                new Option("Test", () => CreatNewTestParagraph(UI)),
            };

            int index = 0;
            WriteOptionsSelect(options, options[index], UI);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();              
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteOptionsSelect(options, options[index], UI);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteOptionsSelect(options, options[index], UI);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    break;
                }
            } while (true);
        }

        static void WriteOptionsSelect(List<Option> options, Option selectedOption, UI UI)
        {
            UI.Page.instructions = "Use keyboard arrows";
            UI.DrawUI(UI, true);
            Console.Write("Type te current paragraph type: \n");

            foreach (Option option in options)
            {
                if (option == selectedOption) Console.Write("> ");
                else Console.Write(" ");
                
                Console.WriteLine(option.Name);
            }
        }


        private static void CreatNewDescOfStageParagraph(UI UI)
        {
            string textParagraph = AddTextParagraph(UI);
            CurrentStory.AddNewDescOfStageParagraph(new DescOfStage(CurrentStory.AmountOfParagrafh, textParagraph));
            UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\nType 'Save' to save changes!\nType 'New' to create a new paragraph\nEnter 'Link' to create a new paragraph link";
        }

        private static void CreatNewFightParagraph(UI UI)
        {
            string textParagraph = AddTextParagraph(UI);
            string enemyName = AddEnemy(UI);
            int amountOfEnemy = AddEnemy(UI, enemyName);

            CurrentStory.AddNewFightParagraph(new FightParagraph(CurrentStory.AmountOfParagrafh, textParagraph, amountOfEnemy, enemyName));
            UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\nType 'Save' to save changes!\nType 'New' to create a new paragraph\nEnter 'Link' to create a new paragraph link";
        }

        private static void CreatNewDialogParagraph(UI UI)
        {
            string textParagraph = AddTextParagraph(UI);
            CurrentStory.AddNewDialogParagraph(new DialogParagraph(CurrentStory.AmountOfParagrafh, textParagraph));
            UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\nType 'Save' to save changes!\nType 'New' to create a new paragraph\nEnter 'Link' to create a new paragraph link";
        }

        private static void CreatNewTestParagraph(UI UI)
        {
            string textParagraph = AddTextParagraph(UI);
            CurrentStory.AddNewTestParagraph(new TestParagraph(CurrentStory.AmountOfParagrafh, textParagraph));
            UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\nType 'Save' to save changes!\nType 'New' to create a new paragraph\nEnter 'Link' to create a new paragraph link";
        }

        private static string AddTextParagraph(UI UI)
        {
            do
            {
                UI.Page.instructions = "Enter text for the paragraph describing the stage.";
                UI.DrawUI(UI, true);

                Console.Write("Entry new text here: ");
                string inputText = Console.ReadLine();

                Console.WriteLine($"You entered the text of the paragraph: \n{inputText}");

                Console.WriteLine("\nDo you accept the text? \nPress 'Y' - yes or 'N' - no,");
                ConsoleKey key;
                do
                {
                    key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.Y:
                            return inputText;
                        case ConsoleKey.N:
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You didn't press the correct key. Try again.");
                            Console.ResetColor();
                            break;
                    }
                } while (true);
            } while (true);
        }

        private static string AddEnemy(UI UI)
        {
            do
            {
                UI.Page.instructions = "Enter enemy name.";
                UI.DrawUI(UI, true);

                Console.Write("Entry new enemy here: ");
                string inputText = Console.ReadLine();

                Console.WriteLine($"You entered enemy name: \n{inputText}");

                Console.WriteLine("\nDo you accept? \nPress 'Y' - yes or 'N' - no,");
                ConsoleKey key;
                do
                {
                    key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.Y:
                            return inputText;
                        case ConsoleKey.N:
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You didn't press the correct key. Try again.");
                            Console.ResetColor();
                            break;
                    }
                } while (true);
            } while (true);
        }

        private static int AddEnemy(UI UI, string enemyName)
        {
            do
            {
                int amountOfEnemy;
                UI.Page.instructions = $"Enter amount of {enemyName}.";
                UI.DrawUI(UI, true);

                do
                {
                    Console.Write("Entry amount here: ");
                    string inputText = Console.ReadLine();

                    if(int.TryParse(inputText, out amountOfEnemy))
                    {
                        if(amountOfEnemy > 0 && amountOfEnemy < 10) break;
                        else Console.WriteLine("Entered a value outside the range 1-10.");
                    }
                    else Console.WriteLine("Entered a value is not a number.");
                } while (true);

                Console.WriteLine($"You entered: \n{amountOfEnemy} {enemyName}");

                Console.WriteLine("\nDo you accept? \nPress 'Y' - yes or 'N' - no,");
                ConsoleKey key;
                bool oneMore = true;
                do
                {
                    key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.Y:
                            return amountOfEnemy;
                        case ConsoleKey.N:
                            oneMore = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You didn't press the correct key. Try again.");
                            Console.ResetColor();
                            break;
                    }
                } while (oneMore);
            } while (true);
        }

        //public static void ClearCurrentConsoleLine(UI UI)
        //{
        //    int currentLineCursor = Console.CursorTop;
        //    Console.SetCursorPosition(0, Console.CursorTop);
        //    Console.Write(new string(' ', Console.WindowWidth));
        //    Console.SetCursorPosition(0, currentLineCursor);
        //}
    }
}

