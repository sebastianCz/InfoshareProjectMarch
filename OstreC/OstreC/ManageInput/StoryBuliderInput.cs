using OstreC.Services;
using OstreC;
using OstreC.Interface;
using System;
using static System.Net.Mime.MediaTypeNames;
using OstreC.Services.Stories;
using Microsoft.Win32;

namespace OstreC.ManageInput
{
    public class StoryBuliderInput : IuiInput
    {
        public PageType Type => PageType.Story_Bulider;
        public int IdPage { get; private set; } = 0;
        private static int IdCreator { get; set; }
        public static Story CurrentStory { get; private set; } = new Story();
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
                            UI.DrawUI(UI, true);
                            return 1;
                        } // make a new story
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "2")) // load an existing history for editing
                        {
                            UI.Page.pageInfo = "You have chosen to load an existing history for editing!";
                            UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\n\nEnter a story name to edit: ";
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
                            CreatNewStory(UI, inputText, CurrentStory, IdCreator);
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
                            CurrentStory = JsonFile.DeserializeStory(inputText);
                            CurrentStory.AddAllParagraph();

                            Console.Clear();
                            foreach(var x in CurrentStory.Paragraphs)
                            {
                                if (x.ParagraphType == ParagraphType.Fight)
                                {
                                    FightParagraph fight = (FightParagraph)x;
                                    Console.WriteLine(fight.EnemyName);
                                }
                            }    
                            

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

        private static void CreatNewStory(UI UI, string inputText, Story newStory, int idCreator)
        {
            switch (idCreator)
            {
                case 0: // Name for Story
                    {
                        Console.WriteLine($"The name of your story is: {inputText}");

                        Console.WriteLine("Are you sure? \nPress 'Y' - yes or 'N' - no");
                        ConsoleKey key;
                        do
                        {
                            key = Console.ReadKey().Key;
                            switch (key)
                            {
                                case ConsoleKey.Y:
                                    UI.Page.pageInfo = $"You create a {inputText} story!";
                                    UI.Page.instructions = "Type 1 to go Story Builder home page!\nType 0 to go back to the main menu!\nType 'Save' to save changes!\nType 'New' to create a new paragraph\nEnter 'Link' to create a new paragraph link";
                                    newStory.ChangeNameOfStory(inputText);
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
                                CreatNewParagraph();
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

        private static void CreatNewParagraph()
        {
            List<Option> options = new List<Option>
            {
                new Option("DescOfStage", () => CreatNewDescOfStageParagraph()),
                new Option("Fight", () =>  CreatNewFightParagraph()),
                new Option("Dialog", () =>  CreatNewDialogParagraph()),
                new Option("Test", () => CreatNewTestParagraph()),
            };

            int index = 0;
            WriteOptionsSelect(options, options[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteOptionsSelect(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteOptionsSelect(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    break;
                }
            } while (true);
        }

        static void WriteOptionsSelect(List<Option> options, Option selectedOption)
        {
            Console.Clear();
            Console.Write("Type te current paragraph type: \n");

            foreach (Option option in options)
            {
                if (option == selectedOption) Console.Write("> ");
                else Console.Write(" ");
                
                Console.WriteLine(option.Name);
            }
        }


        private static void CreatNewDescOfStageParagraph()
        {
            CurrentStory.AddNewDescOfStageParagraph(new DescOfStage(CurrentStory.AmountOfParagrafh, $"Desc: test{CurrentStory.AmountOfParagrafh}"));
        }

        private static void CreatNewFightParagraph()
        {
            CurrentStory.AddNewFightParagraph(new FightParagraph(CurrentStory.AmountOfParagrafh, $"Fight: test{CurrentStory.AmountOfParagrafh}", 2, "goblin"));
        }

        private static void CreatNewDialogParagraph()
        {
            CurrentStory.AddNewDialogParagraph(new DialogParagraph(CurrentStory.AmountOfParagrafh, $"Dialog: test{CurrentStory.AmountOfParagrafh}"));
        }

        private static void CreatNewTestParagraph()
        {
            CurrentStory.AddNewTestParagraph(new TestParagraph(CurrentStory.AmountOfParagrafh, $"Test: test{CurrentStory.AmountOfParagrafh}"));
        }


        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}

