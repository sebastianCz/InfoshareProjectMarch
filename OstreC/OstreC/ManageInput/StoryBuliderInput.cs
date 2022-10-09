using OstreC.Services;
using OstreC;
using OstreC.Interface;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace OstreC.ManageInput
{
    public class StoryBuliderInput : IuiInput
    {
        public PageType Type => PageType.Story_Bulider;
        public int IdPage { get; private set; } = 0;
        public void checkUserInput(UI UI)
        {

            string input = Console.ReadLine();
            string inputText = input;
            IdPage = CheckInput(input, UI, IdPage, inputText);
        }

        public static int CheckInput(string input, UI UI, int idPage, string inputText)
        {

            switch (idPage)
            {
                case 0: // Story Builder home page
                    {
                        input = input.ToUpper().Replace(" ", null);
                        if (Helpers.isCommand(input, UI)) return 0;
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "1")) // make a new story
                        {
                            UI.Page.pageInfo = "You've chosen to make a new story!";
                            UI.Page.instructions = "Press 1 to go Story Builder home page!\nPress 0 to go back to the main menu!\n\nLet's start with something easy, enter the name of the story:";
                            UI.DrawUI(UI, true);
                            return 1;
                        } // make a new story
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "2")) // load an existing history for editing
                        {
                            UI.Page.pageInfo = "You have chosen to load an existing history for editing!";
                            UI.Page.instructions = "Press 1 to go Story Builder home page!\nPress 0 to go back to the main menu!\n\nEnter a story name to edit: ";
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
                                        break;
                                    case ConsoleKey.N:
                                        UI.DrawUI(UI, true);
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                            return 0;
                        } // Main menu
                        else
                        {
                            UI.Page.error = "You didn't provide a correct number";
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
                        else
                        {
                            UI.Page.error = "You didn't provide a correct number";
                            UI.DrawUI(UI, false);
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
                        else
                        {
                            UI.Page.error = "You didn't provide a correct number";
                            UI.DrawUI(UI, false);
                            return idPage;
                        }
                        return idPage;
                    }
                default:
                    return idPage;
            }
        }
    }
}
