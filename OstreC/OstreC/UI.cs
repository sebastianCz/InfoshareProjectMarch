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
        public static readonly string[] _menuCommands = { "EXIT", "BACK" };

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
            PageTypes.Add(new DictionaryInput());
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
                if (UI.CurrentUser.LoggedIn) status = "Online";

                Console.ForegroundColor = ConsoleColor.Green;
                header = $"Active Page: {Page.CurrentType} || Ostre C Game || Current status: {status} || Current user:{CurrentUser.UserName} {Page.BreakLine}  " +
               $"Type any of the existing commands at any time: \n {_menuCommandsString} {Page.BreakLine}";
            }
            else if (UI.Page.CurrentType == PageType.Login)
            {
                header = $"Active Page: {Page.CurrentType} || Ostre C Game || Current status: {status} {Page.BreakLine} ";
            }
            else if (UI.Page.CurrentType == PageType.Paragraph)
            {
                header = $" Active Page: {Page.CurrentType} || Ostre C Game || Current status: {status}||Story Name:{UI.GameSession.SaveFile.NameOfStory}{Page.BreakLine}"+
                         $" Character Name:{UI.GameSession.CurrentPlayer.Name} Character HP:{UI.GameSession.CurrentPlayer.HealthPoints}"+
                         $"\n Type any of the existing commands at any time: {_menuCommandsString} {Page.BreakLine}";
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{header}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Invoked in Draw UI.
        private void DrawGenericPage(string pageInfo, string error, string instruction)
        {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{pageInfo} \n ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{error} \n ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{instruction} \n ");
        }
        //Draws UI  everytime it's invoked. Clear + UI.Page.Instructions + UI.Page.PageInfo +UI.Page.Error
        public static void DrawUI(UI UI, bool clearError)
        {
            if (clearError) UI.Page.Error = "";
            Console.Clear();

            //Default header for all pages
            UI.DrawHeader(UI);
            UI.DrawGenericPage(UI.Page.PageInfo, UI.Page.Error, UI.Page.Instructions);
        }
    }
}
 



