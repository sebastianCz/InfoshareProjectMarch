using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// CHECK DRAW METHOD TO SEE WHICH PAGE IS SUPPOSED TO DO WHAT.


namespace OstreC
{
    internal class Game
    {

        //ID of active page
        public int activePageNr { get; set; }
        //Name of active Page
        public string activePageDescription { get; set; }
        //Contains info for user on how to use commands
        public string header { get; set; }


        //LIST containing  existing menu commands. Init on program start[exit game, exit to main menu]
        public List<string> menuCommands { get; set; }



        public int maxPagesNr { get; }

        //Info to write below the header - depends on page - to provide when calling redraw. 
        public string pageInfo { get; set; }

        //To update based on user input.;
        public string error { get; set; }
        
        //Player saved in game object for easier redraw
        public object player { get; set; }

        public bool exit { get; set; }

        //Holds current paragraph
        public int paragraphID { get; set; }


        public Game (int pageNr, string descriptionTxT )
        {
            //ID of active page
            activePageNr = pageNr;
         
            //Max pages available in the app for easier checks later  
            maxPagesNr = 5;
            
            
          

        }

        public  void init()
        {
            paragraphID = 0;
            exit = false;
            error = "";
            activePageNr = 0;

            List<string> commands = new List<string>();
            commands.Add("MAIN MENU");
            commands.Add("EXIT");
            menuCommands = commands;

            header = $" All commands must be an exact match. You can type them at any time. \n-Type {commands[0]} to return to main menu.\n-Type {commands[1]} to exit the game";
            redraw(0, "Example error message");
        }
        
        //Checks if X  is a command.
        public bool isCommand(string x)
        {
            if (menuCommands.Contains(x)) { return true; }
            return false;
        }

        public void executeCommand(string x)
        {

            if (x == menuCommands[0]) { redraw(0, "MAIN MENU command was either entered or your input caused it's execution."); }
            if (x == menuCommands[1]) { exit = true; }
        }
        //Check if X is a number
    


        //redraws UI based on page nr saved in game.activePageNr
        public void redraw(int x,string txt)
        {
              
            Console.Clear();
             Draw(x,txt);

        }
        public void redraw(int x,string txt,bool y)
        {
            if (y) { Console.Clear(); }

            Draw(x,txt);



        }
        public void Draw(int x,string txt)
        {
            error = txt;
            switch (x) { 

            case 0:
                    activePageDescription = "MAIN MENU";
                    activePageNr = 0;
                    pageInfo = "See options below: \n Type 1 to create a character.\n Type 2 to load an existing game \n Type 3 to start a new game \n Type 4 to view all spells and classes";
                    break;

                case 1:

                    activePageDescription = "Character creation";
                    activePageNr = 1;
                    pageInfo = "Provide description specific for main menu character creation";
                    break;

                case 2:
                    activePageDescription = "Load game";
                    activePageNr = 2;
                    pageInfo = "Provide description specific for loading";
                    break;
                case 3:

                    activePageDescription = "New game";
                    activePageNr = 3;
                    pageInfo = "Provide description specific for creating new game";
                    break;
                case 4:
                    activePageDescription = "Game Data ";
                    activePageNr = 4;
                    pageInfo = "Screen showing all game data: Existing monsters/spells/ etc";
                    break;

                default:
                    activePageDescription = "Main Menu";
                    activePageNr = 0;
                    pageInfo = "See options below: \n Type 1 to create a character.\n Type 2 to load an existing game \n Type 3 to start a new game \n Type 4 to view all spells and classes";
                    error = "Invalid page was provided at GameUi.cs draw overloadx2. Default switch option. Program returned to main menu";

                    break;
                
                
                

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Current page: {activePageDescription} || page {activePageNr + 1} on {maxPagesNr} \n================================\n {header} \n============================ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(pageInfo);
            Console.ForegroundColor = ConsoleColor.White;


        }




        //gamenu ui closure
    }
    //namespace closure
}
