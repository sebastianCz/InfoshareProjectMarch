using OstreC.ManageInput;
using OstreC.Services;

namespace OstreC
{
    /// <summary>
    /// Inherits from ProgramSession. 
    /// </summary>
    public class UI : ProgramSession //ProgramSession is in OstreC.Services. Hereditated to provide instances of objects.
    {
        //Page object containing current page info.
        internal Page Page = new Page(PageType.Main_Menu);

        //LIST containing existing menu commands for user. He can use them almost any time.
        public static readonly string[] _menuCommands = { "MAIN_MENU", "EXIT", "BACK" };

        //LIST containing existing menu commands for user. He can use them almost any time.
        private static string _menuCommandsString { get; set; }

        //Holds all different methods allowing to draw the UI thanks to constructor below.
        public List<IuiInput> PageTypes { get; } = new List<IuiInput>();

        public UI()
        {
            for (int i = 0; i < _menuCommands.Count(); i++)
            {
                _menuCommandsString += " || " + _menuCommands[i];
            }

            PageTypes.Add(new MainMenuInput());
            PageTypes.Add(new CreateCharacterInput());
            PageTypes.Add(new ParagraphInput());
            PageTypes.Add(new BestiaryInput());
            PageTypes.Add(new StoryBuilderInput());
            PageTypes.Add(new LoginInput());
            PageTypes.Add(new ManageAccount());
        }
        //Main method.Launched indefinitely by the program to identify how he's supposed to process user input. 
        public void ChooseInputMethod(UI UI)
        {
            //PageTypes defined above
            foreach (var test in PageTypes)
            {
                //Compares activepage.CurrentType values  (Paragraph_Dialogue for instance) with " type" param of all classes implementing IuiInterface. 
                if (test.Type == UI.Page.CurrentType)
                {
                    test.CheckUserInput(UI);
                    break;
                }
            }
        }    
        //Invoked in Draw UI.
        private void DrawHeader(UI UI)
        {
            string header = "";
            string status = "Offline";

            if (UI.Page.CurrentType != PageType.Login && UI.Page.CurrentType != PageType.Paragraph)
            {
                if (UI.CurrentUser.LoggedIn)  status = "Online"; 

                Console.ForegroundColor = ConsoleColor.Green;
                header = $"Active Page: {Page.CurrentType} || Ostre C Game || Current status: {status} || Current user:{CurrentUser.UserName} {Page.BreakLine}  " +
               $"Type any of the existing commands at any time: \n {_menuCommandsString} {Page.BreakLine}";
            }
            else if (UI.Page.CurrentType == PageType.Login)
            {
                header = $"Active Page: {Page.CurrentType} || Ostre C Game || Current status: {status} {Page.BreakLine} ";
            }else if(UI.Page.CurrentType == PageType.Paragraph)
            {
                header = $" Active Page: {Page.CurrentType} || Ostre C Game || Current status: {status}||Story Name:{UI.GameSession.SaveFile.NameOfStory}{Page.BreakLine}"+
                         $" Character Name:{UI.GameSession.CurrentPlayer.Name} Character HP:{UI.GameSession.CurrentPlayer.HealthPoints}"+
                         $"\n Type any of the existing commands at any time: {_menuCommandsString} {Page.BreakLine}";
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{header}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void DrawCombatHeader(UI UI)
        {
            string genericHeader = "";
            string status = "Offline";

            Console.ForegroundColor = ConsoleColor.Green;
            genericHeader = $"Active Page: {Page.CurrentType} || Ostre C Game || Current status: {status} || Current user:{CurrentUser.UserName} || {Page.BreakLine}   " +
                "Commands are disabled during combat.";

            Console.WriteLine($"{genericHeader}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Invoked in Draw UI.
        private void DrawGenericPage(UI UI)
        {
            if (UI.Page.CurrentType != PageType.Paragraph_Combat)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{UI.Page.PageInfo} \n ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{UI.Page.Error} \n ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{UI.Page.Instructions} \n ");
            }
        }
        //Invoked in Draw UI depending on bool in parameter. If user input is valid Error gets cleared.
        private void ClearData(UI UI)
        {
            //Comentted out since Page info would get cleared out together with the Error despite having to stay. 
            //UI.Page.PageInfo = "";
            UI.Page.Error = "";
        }

        //Draws UI  everytime it's invoked. Clear + UI.Page.Instructions + UI.Page.PageInfo +UI.Page.Error
        public static void DrawUI(UI UI, bool clear)
        {
            if (clear) { UI.ClearData(UI); }
            Console.Clear();

            switch (UI.Page.CurrentType)
            {
                case PageType.Login:
                    UI.DrawHeader(UI);
                    UI.DrawGenericPage(UI);

                    break;

                default:
                    //Default header for all pages
                    UI.DrawHeader(UI);
                    UI.DrawGenericPage(UI);
                    break;
            }
        }

        //Overload if we want to Draw UI without clearing older content. Good for debugging. 
        public static void DrawUI(UI UI, bool clear, bool consoleclear)
        {
            if (clear) { UI.ClearData(UI); }
            if (consoleclear) { Console.Clear(); }
            UI.DrawHeader(UI);
        }
    }
}
 



