using OstreC.Services;

namespace OstreC.ManageInput
{//Example page used to describe how to implement a new " input" class. 
    public class ExampleInput : IuiInput
    {
        //Has to define it's type.Type has to be one of the existing types defined in IuiInput
        public PageType Type => PageType.ExampleEnum;


        //Main function. It's name can't change.
        public void CheckUserInput(UI UI)
        {


            /*
             * Variables to change based on user input and desired outcome: 
            Strings :
                UI.Page.PageInfo; -> Prints above Error. Inteded use : Description of page/ Additional info for user.
                UI.Page.Error; -> Prints in red to show input Error message for user.
                UI.Page.Instruction; -> Prints below Error. Instructions on which button to press. 

            Methods you can use :

            UI.Page.switchPage(PageType.Name_Of_Enum_In_IuiInput.cs); -> Switches PageType in current page to the one provided by you. List of page types is under IuiInput. 
             UI.DrawUI(UI UI,true)   -> Clears the console and draws all variables. Also sets the 3 strings above to empty strings.Use this if user input is valid. 
            UI.Draw(UI UI, false) -> Same as above but leaves the current value for the 3 strings as they were. Use this if user input is invalid. 
             


      */

            var input = Console.ReadLine();

            //Checks if input is a command and executes it. Must always be here.
            if (Helpers.IsCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //WRITE YOUR CODE BELOW. THIS PART IS 100% CUSTOM AND DEPENDS ON THE FUNCTION.

            //IsNumber returns true if it's a number. Basicaly it's a premade bolean from try parse. 
            if (Helpers.IsNumber(input))
            {

                if (input == "1")
                {
                    //FOR EXAMPLE: 
                 
                    UI.Page.Instructions = "You pressed 1! Good job! Press 1 to do something else. \n Press 2 to do something else.   ";
                    UI.Page.PageInfo = "It doesn't matter what you type you will end up back in the main menu. It's just an example page.";
                    UI.Page.Error = "Example Error";
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
                    UI.Page.Error = "Number is either too high or too low!";
                    UI.DrawUI(UI,false);

                }
              

            }
            else
            {
                UI.Page.Error = "You didn't provide a correct number";
                UI.DrawUI(UI,false);

            }


            

        }



    }
}
