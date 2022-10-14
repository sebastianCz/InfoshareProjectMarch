using OstreC.Interface;
using OstreC.Services;

namespace OstreC.ManageInput
{
    public class StartGameInput: IuiInput
    {
        public PageType Type => PageType.StartGame;
        public void checkUserInput(UI UI)
        {

            var input = Console.ReadLine();
            if (Helpers.isCommand(input, UI)){ return;}

            if (!Helpers.isNumber(input)){ return; } 
 

            if(String.Equals(input.ToLower().Replace(" ", null), "1")){
                UI.Page.switchPage(PageType.Main_Menu,UI);

            }else if(String.Equals(input.ToLower().Replace(" ", null), "2"))
            {
                UI.Page.pageInfo = " You are creating a new game. This will overwrite your existing save file! ";
               UI.Page.instructions= " Press enter to proceed";
                UI.DrawUI(UI,true);
                Console.ReadLine();

              UI.GameSession = UI.GameSession.NewGame("DefaultStory");
                UI.Page.switchPage(PageType.Paragraph,UI);
                
            }else if(String.Equals(input.ToLower().Replace(" ", null), "3"))
            {//Checks if current user has the save file exists bool set to true ( It saves in USERS.json files). It's set to true when a user creates his first save file. 
                UI.Page.pageInfo = $" You want to load a game. \n Your current username : {UI.currentUser.UserName} \n Your save file exists: {UI.currentUser.SaveFileExists} \n ";
                if (UI.currentUser.SaveFileExists) {

                    UI.Page.instructions = "Press enter.";
                    UI.GameSession = UI.GameSession.loadSave(UI.currentUser.UserName);
                    UI.Page.error = $"Your save file will be loaded now with the following story \n: {UI.GameSession.SaveFile.NameOfStory}"; 
                
                
                }
                if (!UI.currentUser.SaveFileExists) { UI.Page.instructions = "Press enter."; UI.Page.error = " You do not have an existing save file to load. You will be redirected to Main Menu."; } 

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
