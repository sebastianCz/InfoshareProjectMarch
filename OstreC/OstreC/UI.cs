using OstreC.Interface;
using OstreC.ManageInput;
using OstreC.Services;

namespace OstreC
{
    public class UI


    {

        //If set to true program exits on next loop completion.
        public bool exit { get; set; } = false;

        //Page object containing current page info.
        public Page Page = new Page(PageType.Main_Menu);

        public currentUser User = new currentUser(-1, "", "", false);

        //Link to player methods from services or reference to an existing one can be created through the constructor.
        //Player player = new Player();
        //Paragraph Paragraph = new Paragraph(player) ;

        //LIST +string containing  existing menu commands. 
        public static readonly string[] _menuCommands = { "MAIN_MENU", "EXIT","BACK" };
        private static string _menuCommandsString { get; set; }


        //Holds all different methods allowing to draw the UI thanks to constructor below.
        public List<IuiInput> pageTypes { get; } = new List<IuiInput>();




        public UI()
        {
            for (int i = 0; i < _menuCommands.Count(); i++)
            {
                _menuCommandsString += " || " + _menuCommands[i];

            }

            //paragraphHeader = $"{genericHeader} Active  paragraph ID: {Paragraph.ID} \n Your items: {Player.InvetoryItemsString}"

            pageTypes.Add(new MainMenuInput());
            pageTypes.Add(new CreateNewGameInput());
            pageTypes.Add(new CreateCharacterInput());
            pageTypes.Add(new LoadGameInput());
            pageTypes.Add(new ParagraphInput());
            pageTypes.Add(new BestiaryInput());
            pageTypes.Add(new ExampleInput());
            pageTypes.Add(new StoryBuliderInput());
            pageTypes.Add(new LoginInput());
        }



        public void checkInput(UI UI)
        {
            //pageTypes defined above
            foreach (var test in pageTypes)
            {

                //Compares activepage.currentType values  (Paragraph_Dialogue for instance) with " type" param of all classes implementing IuiInterface. 

                if (test.Type == UI.Page.currentType)
                {
                    test.checkUserInput(UI);
                    break;
                }
                else
                {
                    //Console.WriteLine("Didn't find the page" +test.Type +"  uivalue: " +UI.Page.currentType);
                }

            }
        }

        public void DrawHeader(UI UI)
        {
            string genericHeader = "";

            if (UI.Page.currentType != PageType.Paragraph_Combat)
            {
                string status = "Offline";
                if (UI.User.LoggedIn) { status = "Online"; }
                Console.ForegroundColor = ConsoleColor.Green;
                genericHeader = $"Active Page: {Page.currentType} || Ostre C Game || Current status: {status} {Page.breakLine} Type any of the existing commands at any time: \n {_menuCommandsString} {Page.breakLine}";
                Console.WriteLine($"{genericHeader}");
            }
        }

        public void DrawGenericPage(UI UI)
        {
            if (UI.Page.currentType != PageType.Paragraph_Combat)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{UI.Page.pageInfo} \n ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{UI.Page.error} \n ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{UI.Page.instructions} \n ");
            }
        }

        public void clearData(UI UI)
        {
            UI.Page.pageInfo = "";
            UI.Page.error = "";
        }

        public static void DrawUI(UI UI, bool clear)
        {
            if (clear) { UI.clearData(UI); }
            Console.Clear();
            UI.DrawHeader(UI);
            UI.DrawGenericPage(UI);
        }
    }
}
 



