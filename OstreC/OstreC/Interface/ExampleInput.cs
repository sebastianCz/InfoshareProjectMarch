using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Interface
{
    public class ExampleInput : IuiInput
    {
        //Has to define it's type.Type has to be one of the existing types defined in IuiInput
        public PageType Type => PageType.ExampleEnum;


        //Main function. It's name can't change.
        public void checkUserInput(UI UI)
        {

            /*
             * Variables to change based on user input: 
            Strings :
                UI.Page.pageInfo;
                UI.Page.error;
                UI.Page.error;


             * */

            //pageInfo + instructions have to defined here in case you want to stay on the same page and only change the error msg.
            //This message also has to be defined in MainMenuInput so it's updated when you switch to this page for the 1st time. 
            UI.Page.pageInfo = "Welcome to Example page!";
            UI.Page.instructions = "Press 1 to create New Character \n Pres 2 to go back to main menu.  ";

            //Prompts user for input
            var input = Console.ReadLine();

            //Checks if input is a command and executes it. Must always be here
            if (Helpers.isCommand(input, UI))
            {

                Helpers.HandleCommand(input, UI);

            }

            //WRITE YOUR CODE BELOW. THIS PART IS 100% CUSTOM AND DEPENDS ON THE FUNCTION.

            //isNumber returns true if it's a number. Basicaly it's a premade bolean from try parse. 
            if (Helpers.isNumber(input))
            {

                if (input == "1")
                {
                    //FOR EXAMPLE: 
                    //Invoke new character constructor from "character " object. 
                    //Push chracter to existing character
                    //Update page info : UI.Page.pageInfo =  $"You created a new character! \n Number of existing characters to choose from: {characters.count()}."
                    UI.Page.pageInfo = "You created a new character.";
                    
                }
                else if (input == "2")
                {
                    UI.Page.currentType = PageType.Main_Menu;
                    Helpers.isCommand("MAIN_MENU", UI);
                }
                else
                {
                    UI.Page.error = "Number is either too high or too low!";

                }
              

            }
            else
            {
                UI.Page.error = "You didn't provide a correct number";

            }


            

        }



    }
}
