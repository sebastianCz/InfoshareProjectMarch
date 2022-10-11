

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
            string email = "";
            int id = -1;
            string feedback = "";
            

            

            var input = Console.ReadLine();
            input = input.Replace(" ", null);
           

            switch (input)
            {
                //Login menu
                case "1":
                    do
                    {
                        
                       

                        UI.Page.pageInfo = "Proceed as specified below to login or type BACK to go back to previous screen.";

                        UI.Page.instructions = "Provide your username";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine().Trim();

                      
                        username = input;


                        UI.Page.instructions = "Provide your password";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                        if (Helpers.isCommand(input, UI)) { return; }
                        password = input;


                       

                        bool login = UI.currentUser.Login(username, password,UI.currentUser);

                        if (login)
                        {
                            UI.Page.switchPage(PageType.Main_Menu, UI);
 
                            break;
                        }

                        UI.Page.error = "Your password or login were not correct.Press enter to proceed.";
                        UI.DrawUI(UI, false);
                        Console.ReadLine();
                        UI.Page.switchPage(PageType.Login,UI);

                        break;

                        
                    } while (true);
                    break;

                    //Create new user
                case "2":
                    do
                    {
                        bool createUser = false;

                        UI.Page.pageInfo = "Proceed as specified below to create a new User.";
                        UI.Page.instructions = "Provide a username.Must be at least 1 character and can't be only a number.";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine().Trim();

                     
                       username = input;


                        UI.Page.instructions = " Provide a password.Must be at least 1 character and can't be only a number.";
                         UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                       
                        password = input;

                        UI.Page.instructions = " Provide your email.Make sure it's correct.It must contain '@' and '.'.\n There's no email validation to see if the email exists. \n If you provide a wrong one you won't receive emails from us!  ";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                      
                        email= input;
                        
                       //Checks user input. If it's correct creates user and serialises the new Users.Json file. If not returns to main login page. Returns bool to know if operation succeeded.
                        if(email.Contains("@") && email.Contains(".") && username.Length != 0 && password.Length != 0 && !Helpers.isNumber(password) && !Helpers.isNumber(username))
                        {
                           createUser = UI.currentUser.createUser(username, password, email, UI.currentUser, out feedback);
                        }
                        else
                        {
                            UI.Page.error= (" You provided wrong data. Make sure your username and password is not only a number and contains at least 1 character.\n Make sure your email contains the following 2 characters" +
                                "'@' and '.' \n Press enter to attempt again.");
                            UI.Page.instructions = "";
                            UI.DrawUI(UI, false);
                            Console.ReadLine();
                            UI.Page.switchPage(PageType.Login,UI);

                            return;
                        }
                      

                        //If  user created confirms this to user. Otherwise 
                        if (createUser)
                        {
                       
                            UI.Page.error = $"User created. Username: {UI.currentUser.UserName} User email: {UI.currentUser.Email} User password: {UI.currentUser.Password}";
                            UI.Page.instructions = "Press enter to go back to main login page. ";

                            

                            UI.DrawUI(UI, false);
                            Console.ReadLine();
                            UI.Page.switchPage(UI.Page.currentType, UI);
                            break;
                        }

                        UI.Page.error = feedback;
                        UI.DrawUI(UI, false);

                    } while (true);
                    break;

                    //Passowrd recovery
                case "3":

                    UI.Page.instructions = " You forgot your password. Please provide your username. ";
                    UI.DrawUI(UI,true);

                    input = Console.ReadLine().Trim();
                  

                    username = input;

                    UI.Page.instructions = "Attempting to send password recovery email for provided username. Retrieving user data. Please wait. This process should take a couple seconds";
                    UI.DrawUI(UI, true);


                    // int = email template, username provided just above, UI.currentUser = obj holding all data, feedback == error validation attempt on Services side of the app. 
                    bool test = UI.currentUser.CanSendEmail(1, username,UI.currentUser, out  feedback);

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
                        UI.Page.instructions = " You provided wrong username. email can't be sent.  Press enter to proceed.";
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