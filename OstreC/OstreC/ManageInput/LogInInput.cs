

using OstreC.Interface;
using OstreC.Services;
using OstreC;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
 
/*
 
 finish validating input for each options. in some places redraw isn't up. 
 
 */


namespace OstreC.ManageInput
{
    public class LoginInput : IuiInput
    {
        public PageType Type => PageType.Login;
        public void checkUserInput(UI UI)
        {
            string username;
            string password;
            string email;
            int id = -1;
            string feedback = "";

            

            var input = Console.ReadLine();
            input = input.Replace(" ", null);
            if (Helpers.isCommand(input, UI)) { return; }

            switch (input)
            {
                case "1":
                    do
                    {
                        
                       

                        UI.Page.pageInfo = "Proceed as specified below to login or type BACK to go back to previous screen.";

                        UI.Page.instructions = "Provide your username";
                        UI.DrawUI(UI, false);
                        input = Console.ReadLine();

                        if (Helpers.isCommand(input, UI)) { return; }
                        username = input;


                        UI.Page.instructions = "Provide your password";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                        if (Helpers.isCommand(input, UI)) { return; }
                        password = input;


                       

                        bool login = UI.currentUser.Login(username, password);

                        if (login)
                        {
                            UI.Page.switchPage(PageType.Main_Menu, UI);
                            UI.currentUser.UserName = username;
                            UI.currentUser.Password = password;
                            UI.currentUser.Id = id;
                            UI.currentUser.LoggedIn = true;

                            break;
                        }

                        UI.Page.error = "Your password or login were not correct";

                        
                    } while (true);
                    break;

                case "2":
                    do
                    {
                        

                        UI.Page.pageInfo = "Proceed as specified below to create a new User.";


                        UI.Page.instructions = "Provide a username";
                        UI.DrawUI(UI, false);
                        input = Console.ReadLine();

                        if (Helpers.isCommand(input, UI)) { return; }
                        UI.currentUser.UserName = input;


                        UI.Page.instructions = " Provide a password";
                         UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                        if (Helpers.isCommand(input, UI)) { return; }
                        UI.currentUser.Password = input;

                        UI.Page.instructions = "Provide your email.Make sure it's correct. There's no email validation to see if the email exists.  ";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                        if (Helpers.isCommand(input, UI)) { return; }
                        UI.currentUser.Email= input;

                        bool createUser = UI.currentUser.createUser(UI.currentUser, out feedback);
                        if (createUser)
                        {
                            UI.Page.error = $"User created. Username: {UI.currentUser.UserName} User email: {UI.currentUser.Email}";
                            UI.Page.instructions = "Press enter to go back to login page. ";


                            UI.DrawUI(UI, false);
                            Console.ReadLine();
                            UI.Page.switchPage(UI.Page.currentType, UI);
                            break;
                        }

                        UI.Page.error = feedback;

                    } while (true);
                    break;

                case "3":

                    UI.Page.instructions = " You forgot your password. Please provide your username. ";
                    UI.DrawUI(UI,true);

                    input = Console.ReadLine();
                    if (Helpers.isCommand(input, UI)) { return; }

                    UI.currentUser.UserName = input;
                    bool test = UI.currentUser.sendEmail(1, UI.currentUser, out  feedback);

                    if (test)
                    {
                        UI.Page.instructions = " We sent you an email with the password recovery. Press enter to proceed to main screen. ";
                        UI.DrawUI(UI, true);

                        Console.ReadLine();
                        UI.Page.switchPage(PageType.Login, UI);
                        return;
                    }
                    else
                    {
                        UI.Page.instructions = " You provided wrong username. email can't be sent.  ";
                        UI.DrawUI(UI, true);

                        Console.ReadLine();
                        UI.Page.switchPage(PageType.Login, UI);
                        return;
                    }

            

                    

                  
 

                default:

                    UI.DrawUI(UI, false);
                    UI.Page.error = " You provded the wrong number. Please try again";
                    UI.DrawUI(UI, false);

                    break;
            }
  
        }

    }
}