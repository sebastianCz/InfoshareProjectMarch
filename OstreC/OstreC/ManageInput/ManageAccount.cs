﻿using OstreC.Services;
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
                            do
                            {
                                UI.Page.instructions = "Type your new username.It can't be only a number. It has to contain at least 1 character.";
                                UI.DrawUI(UI, false);

                                input = Console.ReadLine().Trim();
                                if (Helpers.isCommand(input, UI)) { return; }

                                if (!Helpers.isNumber(input) & input.Length != 0)
                                {
                                    UI.Page.instructions = "Please wait. We are changing your username.";
                                    UI.DrawUI(UI, true);

                                    if (UI.currentUser.updateUser(UI.currentUser, input,1))
                                    {
                                        UI.Page.error = "Username Updated";
                                        UI.Page.switchPage(PageType.ManageAccount, UI);

                                        return;
                                    }
                                    else
                                    {
                                        throw new Exception("Currentuser ID wasn't found in Users.json at updatedUser(). It shouldn't be possible. Only logged in users can change the name. ");
                                    }

                                   

                                }
                                else
                                {
                                    UI.Page.error = "Invalid input.";
                                  

                                }

                            } while (true);

                            break;

                        case "2":
                            do
                            {
                                UI.Page.instructions = "Type your new password.It can't be only a number. It has to contain at least 1 character.";
                                UI.DrawUI(UI, false);

                                input = Console.ReadLine().Trim();
                                if (Helpers.isCommand(input, UI)) { return; }

                                if (!Helpers.isNumber(input) & input.Length != 0)
                                {
                                    UI.Page.instructions = "Please wait. We are changing your password.";
                                    UI.DrawUI(UI, true);

                                    if (UI.currentUser.updateUser(UI.currentUser, input,2))
                                    {
                                        UI.Page.error = "Username Updated";
                                        UI.Page.switchPage(PageType.ManageAccount, UI);

                                        return;
                                    }
                                    else
                                    {
                                        throw new Exception("Currentuser ID wasn't found in Users.json at updatedUser(). It shouldn't be possible. Only logged in users can change the name. ");
                                    }



                                }
                                else
                                {
                                    UI.Page.error = "Invalid input.";


                                }

                            } while (true);


                            break;

                        case "3":

                            do
                            {
                                UI.Page.instructions = "Type your new email.It can't be only a number. It has to contain both key characters: '@' and '.'. Make sure it's valid or you won't receive our emails!";
                                UI.DrawUI(UI, false);

                                input = Console.ReadLine().Trim();
                                if (Helpers.isCommand(input, UI)) { return; }

                                if (!Helpers.isNumber(input) & input.Length != 0)
                                {
                                    UI.Page.instructions = "Please wait. We are changing your email.";
                                    UI.DrawUI(UI, true);
                                    if (UI.currentUser.updateUser(UI.currentUser, input, 3))
                                    {
                                        UI.Page.error = "Email Updated";
                                        UI.Page.switchPage(PageType.ManageAccount, UI);

                                        return;
                                    }
                                    else
                                    {
                                        UI.Page.error = "Invalid data provided";
                                    }
                                }
                                else
                                {
                                    UI.Page.error = "Invalid input.";
                                }
                            } while (true);

                            break;
                        default:
                            break;
                    }


                    
                    break;
                case "2":

                    UI.Page.instructions = "Are you sure you want to delete your account? If you do so you will loose access to all your saves. Type DELETE(case sensitive) or BACK to leave this menu.";
                    UI.DrawUI(UI,true);
                    if (Helpers.isCommand(input, UI)) { return; }

                    if (input == "DELETE")
                    {
                        UI.currentUser.deleteUser(UI.currentUser);
                        UI.Page.switchPage(PageType.Login, UI);
                        


                    }
                    else if (input == "BACK")
                    {

                    }
                    else
                    {
                        UI.Page.error = " Invalid input. Your account still exists. Press enter and you will be back on account management page.";
                        UI.Page.switchPage(PageType.ManageAccount,UI);
                    }


                    break;
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
