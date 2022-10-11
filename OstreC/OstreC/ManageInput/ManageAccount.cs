using OstreC.Services;
using OstreC;
using OstreC.Interface;
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using OstreC.Services.Characters;

namespace OstreC.ManageInput
{
    public class ManageAccount : IuiInput
    {
        //Has to define it's type.Type has to be one of the existing types defined in IuiInput
        public PageType Type => PageType.ManageAccount;


        //Main function. It's name can't change.
        public void checkUserInput(UI UI)
        {
            var input = Console.ReadLine();
            if (Helpers.isCommand(input, UI)){ return; }

            if ( !Helpers.isNumber(input) || input.Length == 0)
            {
                UI.Page.error = "Invalit input";
                UI.DrawUI(UI,false);
                return;
            }
            
            switch (input)
            {
                case "1":
                    
                    UI.Page.instructions = "Press 1 to change your username.\n Press 2 to change your password \n Press 3 to change your email.";
                    UI.DrawUI(UI,true);

                    input = Console.ReadLine();
                    if (Helpers.isCommand(input, UI)) { return; }



                    switch (input)
                    {
                        case "1":

                            UI.Page.instructions = "Type your new username.It can't be only a number. It has to contain at least 1 character.";
                            UI.DrawUI(UI, false);

                            input = Console.ReadLine().Trim();
                            if (Helpers.isCommand(input, UI)) { return; }
                            
                            if( !Helpers.isNumber(input) & input.Length != 0)
                            {
                                UI.Page.instructions  = "Please wait. We are changing your username.";
                                UI.DrawUI(UI, true);

                                if (UI.currentUser.updateUser(UI.currentUser, input))
                                {
                                    UI.Page.error = "Username Updated";
                                    UI.Page.switchPage(PageType.ManageAccount, UI);


                                }
                                else
                                {
                                    throw new Exception("Currentuser username wasn't found in Users.json at updatedUser().");
                                };
                              
                                return;

                            }
                            else
                            {
                                UI.Page.error = "Invalid input.";
                                UI.DrawUI(UI, false);
                            }



                            break;

                        case "2":

                            break;

                        case "3":

                            break;
                        default:
                            break;
                    }


                    
                    break;
                case "2":

                    //Delete account

                case "3":

                    //Log off

                    break;

                default:
                    UI.Page.error=("You provided the wrong number");
                    UI.DrawUI(UI,false);
                    break;


            }

            

        }



    }
}
