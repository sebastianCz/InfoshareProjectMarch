using OstreC.Services;
using OstreC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static OstreC.UI;


namespace OstreC
{ 
    
       
public static class InputValidation
{

        

        

       public static bool isNumber(string userInput)
        {
            bool isNr = int.TryParse(userInput, out int n);
            if (isNr) { return true; }
            return false;
          

        }


        public static bool isCommand (string userInput) {
        
            foreach( string command in _menuCommands)
            {
                if(command == userInput) {

                   HandleCommand(userInput);

                    return true; 
                
                }
 
            }

            return false;
        }

        public static void HandleCommand(string command)
        {
            
          //Do stuff based on commands. 

        }








    }



}