namespace OstreC.ManageInput
{
    public class MainMenuInput : IuiInput
    {
        public PageType Type => PageType.Main_Menu;

        public void CheckUserInput(UI UI)
        {
            var input = Console.ReadLine().ToUpper().Replace(" ", null);

            if (Helpers.IsCommand(input, UI)) return; 
            else if (Helpers.IsNumber(input))
            {
                if (String.Equals(input, "1"))
                {
                    UI.Page.PageInfo = " You are creating a new game. This will overwrite your existing save file if you save once in the game! Do you want to proceed anyway? ";
                    UI.Page.Error = "Press Y  to proceed or any key to cancel the operation";
                    UI.DrawUI(UI, false);

                    // CheckUserInput() will start from the top again if user doesn't want to continue.
                    if (!Helpers.YesOrNoKey(false)) 
                    { 
                        UI.Page.switchPage(PageType.Main_Menu, UI); 
                        return; 
                    }
                     
                    UI.Page.PageInfo = "Choose a story you want to play!\n";
                    UI.Page.Instructions = Utilities.ShowChoice(UI.StoriesNames);
                    UI.DrawUI(UI, true);

                    string storyToLoad = "";
                    var characterToLoad = "";

                    while (true)
                    {
                        UI.DrawUI(UI, false);
                        input = Console.ReadLine().ToUpper().Replace(" ", null);
                        if (Helpers.IsCommand(input, UI)) return;
                        if (Helpers.IsNumber(input))
                        {
                            int chosenOption = Convert.ToInt32(input);

                            if (chosenOption >= 0 && chosenOption <= UI.StoriesNames.Count())
                            {
                                var storyToLaunch = UI.StoriesNames.FirstOrDefault(o => o.Key == chosenOption);
                                
                                storyToLoad = storyToLaunch.Value;
                                break;
                            }
                        }
                        else
                        {
                            UI.Page.Error = "You didn't provide a number!";
                            UI.DrawUI(UI, false);
                        }
                    }
     
                    UI.Page.PageInfo = "Choose a character you want to play. You can choose also characters created by other users!\n Type BACK to go back to main menu and create a new one.  ";
                    UI.Page.Instructions = Utilities.ShowChoice(UI.CharacterNames);

                    while (true)
                    {
                        UI.DrawUI(UI, false);
                        input = Console.ReadLine().ToUpper().Replace(" ", null);
                        if (Helpers.IsCommand(input, UI)) return;
                        if (Helpers.IsNumber(input))
                        {
                            int chosenOption = Convert.ToInt32(input);

                            if (chosenOption >= 0 && chosenOption <= UI.CharacterNames.Count())
                            {
                                var characterToLaunch = UI.CharacterNames.FirstOrDefault(o => o.Key == chosenOption);
                                
                                characterToLoad = characterToLaunch.Value;
                                break;
                            }
                        }
                        else
                        {
                            UI.Page.Error = "You didn't provide a number!";
                            UI.DrawUI(UI, false);
                        }
                    }
                    UI.GameSession = UI.NewGame(storyToLoad,characterToLoad);
                    UI.Page.switchPage(PageType.Paragraph, UI);
                    return;
                }
                else if (String.Equals(input, "2"))
                {
                    if (UI.CurrentUser.SaveFileExists)
                    {
                        UI.GameSession = UI.LoadSave(UI.CurrentUser.UserName);
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

