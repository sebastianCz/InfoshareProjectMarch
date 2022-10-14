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
                UI.Page.pageInfo = " You want to start a new game.";
               UI.Page.instructions= " Press enter to proceed";
                UI.DrawUI(UI,true);
                Console.ReadLine();
                

            }else if(String.Equals(input.ToLower().Replace(" ", null), "3"))
            {//Checks if current user has the save file exists bool set to true ( It saves in USERS.json files). It's set to true when a user creates his first save file. 
                UI.Page.pageInfo = $" You want to load a game. \n Your current username : {UI.currentUser.UserName} \n Do you have a save file: {UI.currentUser.SaveFileExists} \n ";
                if (UI.currentUser.SaveFileExists) { UI.Page.error = $"Your save file will be loaded now with the following story \n: {GameSession.SaveFile.NameOfStory}"; }
                if (!UI.currentUser.SaveFileExists) { UI.Page.error = " You do not have an existing save file to load. You will be redirected to Main Menu.\n Press enter to proceed"; } 

                UI.DrawUI(UI, false);
                Console.ReadLine();
                
                if (UI.currentUser.SaveFileExists)
                {
                    UI.GameSession.init(UI.currentUser.UserName);
                }
                
                
            }
            
            

        }

    }
}
