using OstreC.Interface;
using OstreC.Services;

namespace OstreC
{
    public class Page
    {
        public PageType currentType { get; set; }
        public string breakLine { get; } = "\n=======================================================================================================\n";
        public string pageInfo { get; internal set; } = "";
        public string error { get; set; } = "";
        public string instructions { get; set; } = "";

        
        public Page(PageType x)
        {
            //Default value
            currentType = x;
        }

        //Main_Menu,
        //Create_NewGame,
        //Create_Character,
        //Load_Game,
        //Paragraph,
        //Paragraph_Combat,
        //Bestiary,
        //ExampleEnum

        //Text to show when transitioning to this page from a different one.
        public void switchPage(PageType x, UI UI)
        {
            switch (x)
            {
                case PageType.Main_Menu:
                    currentType = PageType.Main_Menu;
                    pageInfo = "Welcome to the main menu!";
                    instructions = " Press 1 to Start a game! \n Press 2 to create a new character \n Press 3 to Debug paragraph \n Press 4 to Create new story \n " +
                        "Press 5 to Manage your account \n Press 9 for Example page";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Create_NewGame:
                    currentType = PageType.Create_NewGame;
                    pageInfo = "Welcome to game creation screen!";
                    instructions = " Press 1 to create new game\n pres 2 to go back to main menu";
 
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Create_Character:
                    currentType = PageType.Create_Character;
                    pageInfo = "Welcome to character creation page!";                    
                    instructions = " 1. Create Default Player \n 2. Create customer Player \n 3.DeletePlayer \n 4.DisplayStatistics \n 5.Save Player \n 6.Exit to Main Menu";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Load_Game:
                    currentType = PageType.Load_Game;
                    pageInfo = "Welcome to game loading screen!";
                    instructions = "User input is not handled yet.";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Paragraph:
                    currentType = PageType.Paragraph;
                    pageInfo = "Welcome to Paragraphs!";
                    instructions = " Press ENTER to start the story!";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Story_Bulider:
                    currentType = PageType.Story_Bulider;
                    pageInfo = "Welcome to the Story Builder!";
                    instructions = " Type 1 to create a new story!\n Type 2 to load an existing story and edit it!\n Type 0 to go back to the main menu!";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Bestiary:
                    currentType = PageType.Bestiary;
                    pageInfo = "Welcome to the Bestiary!";
                    instructions = " User input is not handled yet.";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.ExampleEnum:
                    currentType = PageType.ExampleEnum;
                    pageInfo = "Welcome to the example page!";
                    instructions = " Press 1 to show example messages!\nPress 2 to go back to main menu!";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Login:
                    currentType = PageType.Login;
                    pageInfo = "Welcome to the login page! ";
                    instructions = " Type 1 to login \n Type 2 to register \n Type 3 if you forgot your password";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.ManageAccount:
                    currentType = PageType.ManageAccount;
                    pageInfo = $"Welcome to account management page dear : {UI.currentUser.UserName} \n Your account data is visible below: \n {UI.currentUser.presentUserBreakLine(true)} ";
                       
                    instructions = " Type 1 edit your data \n Type 2 to delete your account";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.StartGame:
                    currentType = PageType.StartGame;
                    pageInfo = $"You're about to start a game. Choose one of the options below. ";
                    instructions = "Type 1 to go back to Main Menu. \n Type 2 to Start a new Game \n Press 3 to Load a game";
                    UI.DrawUI(UI, true);
  
                    break;

                default:
                    throw new Exception("SwitchPage() was ivoked at Page.Cs with an unhandled page type.Default message won't be assigned.");
                    break;
            }
        }
    }
}
