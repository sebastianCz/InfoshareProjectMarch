using OstreC.Interface;
using OstreC.Services;
using static System.Net.Mime.MediaTypeNames;

namespace OstreC.ManageInput
{
    public class ParagraphInput : IuiInput
    {
        public PageType Type => PageType.Paragraph;
      
        //private int UI.GameSession.SaveFile.ActiveParagraph { get; set; } //= GameSession.SaveFile.ActiveParagraph;
        //private ParagraphType UI.GameSession.SaveFile.ActiveParagraphType { get; set; } //= GameSession.SaveFile.ActiveParagraphType;
        private int AmountOfOptions { get; set; } = 0;
        private int i { get; set; } = 0;
        private Paragraph Paragraph { get; set; }
        public void checkUserInput(UI UI)
        {
        //public string NameOfStory { get; set; }
            if (i != 0)
            {
                UI.Page.pageInfo = ReaderStories.ThrowParagraphText(UI.GameSession.SaveFile.ActiveParagraphType, UI.GameSession.SaveFile.CurrentStory, UI.GameSession.SaveFile.ActiveParagraph);
                UI.Page.instructions = ReaderStories.ThrowOptionsText(UI.GameSession.SaveFile.ActiveParagraphType, UI.GameSession.SaveFile.CurrentStory, UI.GameSession.SaveFile.ActiveParagraph);
                Paragraph = ReaderStories.ThrowObjParagraph(UI.GameSession.SaveFile.ActiveParagraphType, UI.GameSession.SaveFile.CurrentStory, UI.GameSession.SaveFile.ActiveParagraph);
                AmountOfOptions = Paragraph.AmountOfOptions;
                UI.DrawUI(UI, false);
                UI.Page.error = "";
                //UI.GameSession.SaveFile.ActiveParagraph = UI.GameSession.SaveFile.ActiveParagraph;
                //UI.GameSession.SaveFile.ActiveParagraphType = ParagraphType;
            }
            i++;

            string input = Console.ReadLine();
            input = input.ToUpper().Replace(" ", null);

            if (Helpers.isCommand(input, UI)) ;
            else if (String.Equals(input.ToUpper().Replace(" ", null), "SAVE") && AmountOfOptions > 0) // Save
            {
                string serializedSaveFile = JsonFile.SerializeSaveFile(UI.GameSession.SaveFile);
                JsonFile.serializedToJson(serializedSaveFile, $"UsersFile\\" + UI.currentUser.UserName);
                UI.currentUser.SaveFileExists = true;
                UI.Page.error = "History progress saved!";
                UI.currentUser.updateUser(UI.currentUser, "true", 4);
            } // Save
            else if (String.Equals(input, "0") && AmountOfOptions > 0)
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
            else if (String.Equals(input, "1") && AmountOfOptions > 1)
            {
                UI.GameSession.SaveFile.ActiveParagraph = Paragraph.NextParagraphs[1].IdParagraph;
                UI.GameSession.SaveFile.ActiveParagraphType = Paragraph.NextParagraphs[1].ParagraphType;
            }
            else if (String.Equals(input, "2") && AmountOfOptions > 2)
            {
                UI.GameSession.SaveFile.ActiveParagraph = Paragraph.NextParagraphs[2].IdParagraph;
                UI.GameSession.SaveFile.ActiveParagraphType = Paragraph.NextParagraphs[2].ParagraphType;
            }
            else if (String.Equals(input, "3") && AmountOfOptions > 3)
            {
                UI.GameSession.SaveFile.ActiveParagraph = Paragraph.NextParagraphs[3].IdParagraph;
                UI.GameSession.SaveFile.ActiveParagraphType = Paragraph.NextParagraphs[3].ParagraphType;
            }
            else if (AmountOfOptions > 0)
            {
                UI.Page.error = "You didn't type the correct option";
            }
        }
    }
}
