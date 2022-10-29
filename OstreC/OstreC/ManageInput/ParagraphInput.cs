using OstreC.Services;

namespace OstreC.ManageInput
{
    //Shows possible inputs to user depending on currently active paragraph.  Analyzes strings. Launches correct methods depending on user input. 
    public class ParagraphInput : IuiInput
    {
        public PageType Type => PageType.Paragraph;
        private int AmountOfOptions { get; set; } = 0;
        private Paragraph Paragraph { get; set; }
        public void CheckUserInput(UI UI)
        {
            var saveFile = UI.GameSession.SaveFile;
            ThrowCurrentParagraph(UI);
            UI.DrawUI(UI, false);
            UI.Page.Error = "";

            string input = "";
            if (saveFile.ActiveParagraphType != ParagraphType.Fight && saveFile.ActiveParagraphType != ParagraphType.Test)
                input = Console.ReadLine()?.ToUpper().Replace(" ", null);

            if (saveFile.ActiveParagraphType == ParagraphType.Fight) // Result form method ParagraphTest
            {

                var currentFightPatagraph = (FightParagraph)Paragraph;
                var currentEnemies = ReaderStories.InitialEnemies(currentFightPatagraph.ParagraphEnemies); // Creat object enemies
                input = FightInput.SolveFight(currentEnemies, UI.GameSession.CurrentPlayer);
                if (input == "0")
                {
                    UI.Page.switchPage(PageType.Main_Menu, UI);
                    return;
                } 
            }

            if (saveFile.ActiveParagraphType == ParagraphType.Test) // Result form method ParagraphTest
            {
                var currentTestPatagraph = (TestParagraph)Paragraph;
                int throwDice = Helpers.ThrowDice(UI);

                switch (currentTestPatagraph.Property.ToLower().Trim())
                {
                    case "strength":
                        throwDice += UI.GameSession.CurrentPlayer.ModStrength;
                        break;
                    case "dexterity":
                        throwDice += UI.GameSession.CurrentPlayer.ModDexterity;
                        break;
                    case "constitution":
                        throwDice += UI.GameSession.CurrentPlayer.ModConstitution;
                        break;
                    case "intelligence":
                        throwDice += UI.GameSession.CurrentPlayer.ModIntelligence;
                        break;
                    case "wisdom":
                        throwDice += UI.GameSession.CurrentPlayer.ModWisdom;
                        break;
                    case "charisma":
                        throwDice += UI.GameSession.CurrentPlayer.ModCharisma;
                        break;
                    default:
                        throw new Exception("Unkonown Property");
                }
                if (throwDice >= currentTestPatagraph.PropertyValue) input = "2";
                else input = "1";
            }

            if (Helpers.IsCommand(input, UI)) ;
            else if (AmountOfOptions > 0 && String.Equals(input, "SAVE")) // Save
            {
                ReaderStories.SaveProgress(UI.CurrentUser, UI.GameSession);
                UI.Page.Error = "History progress saved!";
            } // Save
            else if (AmountOfOptions > 0 && String.Equals(input, "0"))
            {
                Helpers.WriteLineColorText("Are you sure? You go back to menu.\nPress 'Y' - yes or 'N' - no", ConsoleColor.Red);
                if (Helpers.YesOrNoKey(true)) UI.Page.switchPage(PageType.Main_Menu, UI);
            } // Main menu
            else if (AmountOfOptions > 1 && String.Equals(input, "1"))
            {
                NextParagraph(UI, 1);
            }
            else if (AmountOfOptions > 2 && String.Equals(input, "2"))
            {
                NextParagraph(UI, 2);
            }
            else if (AmountOfOptions > 3 && String.Equals(input, "3"))
            {
                NextParagraph(UI, 3);
            }
            else
            {
                UI.Page.Error = "You didn't type the correct option";
            }
        }
        private void NextParagraph(UI UI, int input)
        {
            var saveFile = UI.GameSession.SaveFile;
            saveFile.ActiveParagraph = Paragraph.NextParagraphs[input].IdParagraph;
            saveFile.ActiveParagraphType = Paragraph.NextParagraphs[input].ParagraphType;
        }
        private void ThrowCurrentParagraph(UI UI)
        {
            try
            {
                var saveFile = UI.GameSession.SaveFile;
                UI.Page.PageInfo = ReaderStories.ThrowParagraphText(saveFile.ActiveParagraphType, saveFile.CurrentStory, saveFile.ActiveParagraph);
                UI.Page.Instructions = ReaderStories.ThrowOptionsText(saveFile.ActiveParagraphType, saveFile.CurrentStory, saveFile.ActiveParagraph);
                Paragraph = ReaderStories.ThrowObjParagraph(saveFile.ActiveParagraphType, saveFile.CurrentStory, saveFile.ActiveParagraph);
                AmountOfOptions = Paragraph.AmountOfOptions;
                if (saveFile.ActiveParagraphType == ParagraphType.Fight || saveFile.ActiveParagraphType == ParagraphType.Test) UI.Page.Instructions = ""; //Clear intruction for Fight and Test paragraph, result from other page
            }
            catch (Exception)
            {
                UI.Page.PageInfo = "Next Paragraph doesn't exist! - End Game";
                UI.Page.Instructions = "Press 0 go back to menu!";
                AmountOfOptions = 1;
            }
        }
    }
}
