using OstreC.Services;

namespace OstreC.ManageInput
{
    //Activates right command depending on user input. Analyzes strings.
    public class StartGameInput: IuiInput
    {
        public PageType Type => PageType.StartGame;
        public void CheckUserInput(UI UI)
        {

            var input = Console.ReadLine();
            if (Helpers.IsCommand(input, UI)){ return;}

            if (!Helpers.IsNumber(input)){ return; } 
 

            if(String.Equals(input.ToLower().Replace(" ", null), "1")){
                UI.Page.switchPage(PageType.Main_Menu,UI);

            }else if(String.Equals(input.ToLower().Replace(" ", null), "2"))
            {
                UI.Page.PageInfo = " You are creating a new game. This will overwrite your existing save file! ";
               UI.Page.Instructions= " Press enter to proceed";
                UI.DrawUI(UI,true);
                Console.ReadLine();

              UI.GameSession = UI.GameSession.NewGame("DefaultStory");
                UI.Page.switchPage(PageType.Paragraph,UI);
                
            }else if(String.Equals(input.ToLower().Replace(" ", null), "3"))
            {//Checks if current user has the save file exists bool set to true ( It saves in USERS.json files). It's set to true when a user creates his first save file. 
                UI.Page.PageInfo = $" You want to load a game. \n Your current username : {UI.CurrentUser.UserName} \n Your save file exists: {UI.CurrentUser.SaveFileExists} \n ";
                if (UI.CurrentUser.SaveFileExists) {

                    UI.Page.Instructions = "Press enter.";
                    UI.GameSession = UI.GameSession.LoadSave(UI.CurrentUser.UserName);
                    UI.Page.Error = $"Your save file will be loaded now with the following story \n: {UI.GameSession.SaveFile.NameOfStory}"; 
                
                
                }
                if (!UI.CurrentUser.SaveFileExists) { UI.Page.Instructions = "Press enter."; UI.Page.Error = " You do not have an existing save file to load. You will be redirected to Main Menu."; } 

                UI.DrawUI(UI, false);
                Console.ReadLine();

                if (UI.GameSession.FileLoaded)
                {
                    UI.Page.switchPage(PageType.Paragraph, UI);
                }
                else
                {
                    UI.Page.switchPage(PageType.StartGame, UI);
                }
                
                
                
            }
            
            

        }

    }
}
