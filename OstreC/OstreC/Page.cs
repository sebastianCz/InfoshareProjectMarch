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
                    instructions = "Press 1 for new game\nPress 2 to create a new character \nPress 3 to load a game \nPress 4 to Paragraph \nPress 5 to Creat new story \nPress 9 for example page";
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
                    instructions = "1. Use already created adventurer\n2. Create your own adventurer\n3. Delete your adventurer\n4. Display statistics" +
                        "\n5. Save your adventurer\n6. Exit to Main Menu";
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
                    pageInfo = "Welcome to Paragraphs!!";
                    instructions = "User input is not handled yet.";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Story_Bulider:
                    currentType = PageType.Story_Bulider;
                    pageInfo = "Welcome to the Story Builder!";
                    instructions = "Press 1 to create a new story!\nPress 2 to load an existing history and edit it!\nPress 0 to go back to the main menu!";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Bestiary:
                    currentType = PageType.Bestiary;
                    pageInfo = "Welcome to the Bestiary!";
                    instructions = "User input is not handled yet.";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.ExampleEnum:
                    currentType = PageType.ExampleEnum;
                    pageInfo = "Welcome to the example page!";
                    instructions = "Press 1 to show example messages!\nPress 2 to go back to main menu!";
                    UI.DrawUI(UI, true);
                    break;

                case PageType.Login:
                    currentType = PageType.Login;
                    pageInfo = "Welcome to the login page! ";
                    instructions = "Type 1 to login \n Type 2 to register \n Type 3 if you forgot your password";
                    UI.DrawUI(UI, true);
                    break;

                default:
                    throw new Exception("SwitchPage() was ivoked at Page.Cs with an unhandled page type.Default message won't be assigned.");
                    break;
            }
        }
    }
}
