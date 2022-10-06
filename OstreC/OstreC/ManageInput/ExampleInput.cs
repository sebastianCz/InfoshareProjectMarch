using OstreC.Services;
using OstreC;
using OstreC.Interface;
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace OstreC.ManageInput
{
    public class ExampleInput : IuiInput
    {
        //Has to define it's type.Type has to be one of the existing types defined in IuiInput
        public PageType Type => PageType.ExampleEnum;


        //Main function. It's name can't change.
        public void checkUserInput(UI UI)
        {


            /*
             * Variables to change based on user input and desired outcome: 
            Strings :
                UI.Page.pageInfo; -> Prints above error. Inteded use : Description of page/ Additional info for user.
                UI.Page.error; -> Prints in red to show input error message for user.
                UI.Page.Instruction; -> Prints below error. Instructions on which button to press. 

            Methods you can use :

            UI.Page.switchPage(PageType.Name_Of_Enum_In_IuiInput.cs); -> Switches PageType in current page to the one provided by you. List of page types is under IuiInput. 
             UI.DrawUI(UI UI,true)   -> Clears the console and draws all variables. Also sets the 3 strings above to empty strings.Use this if user input is valid. 
            UI.Draw(UI UI, false) -> Same as above but leaves the current value for the 3 strings as they were. Use this if user input is invalid. 
             


      */

            var input = Console.ReadLine();

            //Checks if input is a command and executes it. Must always be here.
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
                 
                    UI.Page.instructions = "You pressed 1! Good job! Press 1 to do something else. \n Press 2 to do something else.   ";
                    UI.Page.pageInfo = "It doesn't matter what you type you will end up back in the main menu. It's just an example page.";
                    UI.Page.error = "Example error";
                    UI.DrawUI(UI,true);

                    input = Console.ReadLine();
                    //Normally you might want to either handle the 2nd input here OR create a new class with a new page if your function size is getting out of hand. 
                    //In our example we will return to main page regardless of the input. 
                    UI.Page.switchPage(PageType.Main_Menu, UI);


                }
                else if (input == "2")
                {
                    UI.Page.switchPage(PageType.Main_Menu, UI);
                }
                else
                {
                    UI.Page.error = "Number is either too high or too low!";
                    UI.DrawUI(UI,false);

                }
              

            }
            else
            {
                UI.Page.error = "You didn't provide a correct number";
                UI.DrawUI(UI,false);

            }


            

        }



    }
}
