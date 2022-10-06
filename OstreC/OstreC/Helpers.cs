using OstreC.Services;
using OstreC;
using OstreC.Interface;
using OstreC.ManageInput;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;


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
        
            foreach( string command in UI._menuCommands)
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
                    UI.Page.switchPage(PageType.Main_Menu, UI);
                   

                    break;
                default:
                    //Method shouldn't be inkoked if input != command. 
                    throw new Exception();
                    


            }
 
        }
  

       


    }

    
  
}