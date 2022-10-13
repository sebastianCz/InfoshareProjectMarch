using OstreC.Interface;
using OstreC.Services;
using static System.Net.Mime.MediaTypeNames;

namespace OstreC.ManageInput
{
    public class ParagraphInput : IuiInput
    {
        public PageType Type => PageType.Paragraph;
      
        private int IdParagraph { get; set; } = GameSession.SaveFile.ActiveParagraph;
        private ParagraphType ParagraphType { get; set; } = GameSession.SaveFile.ActiveParagraphType;
        private int AmountOfOptions { get; set; } = 0;
        private int i { get; set; } = 0;
        private Paragraph Paragraph { get; set; }
        public void checkUserInput(UI UI)
        {
            if (i != 0)
            {
                UI.Page.pageInfo = ReaderStories.ThrowParagraphText(ParagraphType, GameSession.SaveFile.CurrentStory, IdParagraph);
                UI.Page.instructions = ReaderStories.ThrowOptionsText(ParagraphType, GameSession.SaveFile.CurrentStory, IdParagraph);
                Paragraph = ReaderStories.ThrowObjParagraph(ParagraphType, GameSession.SaveFile.CurrentStory, IdParagraph);
                AmountOfOptions = Paragraph.AmountOfOptions;
                UI.DrawUI(UI, false);
                UI.Page.error = "";
                GameSession.SaveFile.ActiveParagraph = IdParagraph;
                GameSession.SaveFile.ActiveParagraphType = ParagraphType;
            }
            i++;

            string input = Console.ReadLine();
            input = input.ToUpper().Replace(" ", null);



            switch (AmountOfOptions)
            {
                case 0:
                    Helpers.isCommand(input, UI);
                    break;
                case 1:
                    {
                        if (Helpers.isCommand(input, UI)) ;
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "SAVE")) // Save
                        {
                            string serializedSaveFile = JsonFile.SerializeSaveFile(GameSession.SaveFile);
                            JsonFile.serializedToJson(serializedSaveFile, $"UsersFile\\" + UI.currentUser.UserName);
                            UI.Page.error = "History progress saved!";
                        } // Save
                        else if (String.Equals(input, "0"))
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
                                        break;
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
                        }
                        break;
                    }
                case 2:
                    {
                        if (Helpers.isCommand(input, UI)) ;
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "SAVE")) // Save
                        {
                            string serializedSaveFile = JsonFile.SerializeSaveFile(GameSession.SaveFile);
                            JsonFile.serializedToJson(serializedSaveFile, $"UsersFile\\" + UI.currentUser.UserName);
                            UI.Page.error = "History progress saved!";
                        } // Save
                        else if (String.Equals(input, "0"))
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
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        } // Main menu
                        else if (String.Equals(input, "1"))
                        {
                            IdParagraph = Paragraph.NextParagraphs[1].IdParagraph;
                            ParagraphType = Paragraph.NextParagraphs[1].ParagraphType;
                        }
                        else
                        {
                            UI.Page.error = "You didn't type the correct option";
                        }
                        break;
                    }
                case  3:
                    {
                        if (Helpers.isCommand(input, UI)) ;
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "SAVE")) // Save
                        {
                            string serializedSaveFile = JsonFile.SerializeSaveFile(GameSession.SaveFile);
                            JsonFile.serializedToJson(serializedSaveFile, $"UsersFile\\" + UI.currentUser.UserName);
                            UI.Page.error = "History progress saved!";
                        } // Save
                        else if (String.Equals(input, "0"))
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
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        } // Main menu
                        else if (String.Equals(input, "1"))
                        {
                            IdParagraph = Paragraph.NextParagraphs[1].IdParagraph;
                            ParagraphType = Paragraph.NextParagraphs[1].ParagraphType;
                        }
                        else if (String.Equals(input, "2"))
                        {
                            IdParagraph = Paragraph.NextParagraphs[2].IdParagraph;
                            ParagraphType = Paragraph.NextParagraphs[2].ParagraphType;
                        }
                        else
                        {
                            UI.Page.error = "You didn't type the correct option";
                        }
                        break;
                    }
                case 4:
                    {
                        if (Helpers.isCommand(input, UI)) ;
                        else if (String.Equals(input.ToUpper().Replace(" ", null), "SAVE")) // Save
                        {
                            string serializedSaveFile = JsonFile.SerializeSaveFile(GameSession.SaveFile);
                            JsonFile.serializedToJson(serializedSaveFile, $"UsersFile\\" + UI.currentUser.UserName);
                            UI.Page.error = "History progress saved!";
                        } // Save
                        else if (String.Equals(input, "0"))
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
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You didn't press the correct key. Try again.");
                                        Console.ResetColor();
                                        break;
                                }
                            } while (key != ConsoleKey.N && key != ConsoleKey.Y);
                        } // Main menu
                        else if (String.Equals(input, "1"))
                        {
                            IdParagraph = Paragraph.NextParagraphs[1].IdParagraph;
                            ParagraphType = Paragraph.NextParagraphs[1].ParagraphType;
                        }
                        else if (String.Equals(input, "2"))
                        {
                            IdParagraph = Paragraph.NextParagraphs[2].IdParagraph;
                            ParagraphType = Paragraph.NextParagraphs[2].ParagraphType;
                        }
                        else if (String.Equals(input, "3"))
                        {
                            IdParagraph = Paragraph.NextParagraphs[3].IdParagraph;
                            ParagraphType = Paragraph.NextParagraphs[3].ParagraphType;
                        }
                        else
                        {
                            UI.Page.error = "You didn't type the correct option";
                        }
                        break;
                    }
            }

         
        }
    }
}
