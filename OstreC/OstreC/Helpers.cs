using OstreC.Services;
using OstreC;
using static OstreC.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace OstreC
{ 
    
       
public static class Helpers
    {

        

        

       public static bool isNumber(string userInput)
        {
            bool isNr = int.TryParse(userInput, out int n);
            if (isNr) { return true; }
            return false;
          

        }


        public static bool isCommand (string userInput,UI UI) {
        
            foreach( string command in _menuCommands)
            {
                if(command == userInput) {

                   HandleCommand(userInput,UI);

                    return true; 
                
                }
 
            }

            return false;
        }

        public static class EnumUtil
        {
            public static IEnumerable<T> GetValues<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>();
            }
        }

        public static void HandleCommand(string command,UI UI)
        {

            switch (command)
            {

                case "EXIT":
                    UI.exit = true;
                    break;
                case "MAIN_MENU":

                    UI.Page.currentType = Interface.PageType.Main_Menu;
                    UI.Page.pageInfo = "Welcome to main menu";
                    UI.Page.instructions = "Press 1 to create New Game \n Press 2 to Create new Character \n Press 3 to Load game \n Press 4 to view Bestiary \n Press 9 for example page";


                    break;
                default:
                    //Method shouldn't be inkoked if input != command. 
                    throw new Exception();
                    


            }
 
        }
  

    }


  
}