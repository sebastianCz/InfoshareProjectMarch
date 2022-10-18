using OstreC.Services;
namespace OstreC.ManageInput
{
    public class MainMenuInput : IuiInput
    {
        public PageType Type => PageType.Main_Menu;

        public void CheckUserInput(UI UI)
        {
            var input = Console.ReadLine().ToUpper().Replace(" ", null);

            if (Helpers.IsCommand(input, UI)) ;
            else if (Helpers.IsNumber(input))
            {
                if (String.Equals(input,"1"))
                {
                    UI.Page.PageInfo = " You are creating a new game. This will overwrite your existing save file if you save once in the game! Do you want to proceed anyway? ";
                    UI.Page.Error = "Press Y  to proceed or any key to cancel the operation";
                    UI.DrawUI(UI, false);

                    //Exits this if statement if user doesn't want to continue. CheckUserInput() will start from the top again.
                    if (!Helpers.YesOrNoKey(false)) { UI.Page.switchPage(PageType.Main_Menu, UI); return; }

                    //Starts a new game with current character and current /default story. 
                    UI.GameSession = UI.GameSession.NewGame("DefaultStory");
                    UI.Page.switchPage(PageType.Paragraph, UI);
                }
                else if (String.Equals(input, "2"))
                {
                    if (UI.CurrentUser.SaveFileExists)
                    {
                        UI.GameSession = UI.GameSession.LoadSave(UI.CurrentUser.UserName);
                        if (UI.GameSession.FileLoaded) { UI.Page.switchPage(PageType.Paragraph, UI); }
                    }
                    else
                    {
                        UI.Page.Error = "You didn't create a save file yet.";
                        UI.DrawUI(UI, false);
                    }
                }
                else if (String.Equals(input, "3"))
                {
                    UI.Page.switchPage(PageType.Create_Character, UI);
                }
                else if (String.Equals(input, "4"))
                {
                    UI.Page.switchPage(PageType.Story_Bulider, UI);
                }
                else if (String.Equals(input, "5"))
                {
                    UI.Page.switchPage(PageType.Bestiary, UI);
                }
                else if (String.Equals(input, "6"))
                {
                    UI.CurrentUser.logOff(UI.CurrentUser);
                    UI.Page.switchPage(PageType.Login, UI);
                }
                else if (String.Equals(input, "7"))
                {
                    UI.Exit = true;
                }
                else if (String.Equals(input, "8"))
                {
                    UI.Page.switchPage(PageType.ManageAccount, UI);
                }
                else
                {
                    UI.Page.Error = "You didn't provide a correct number";
                    UI.DrawUI(UI, false);
                }
            }
            else
            {
                UI.Page.Error = "You didn't provide a number";
                UI.DrawUI(UI, false);
            }
        }
    }
}

