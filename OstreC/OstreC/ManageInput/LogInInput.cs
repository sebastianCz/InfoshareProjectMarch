

using OstreC.Interface;
using OstreC.Services;
using OstreC;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
 

namespace OstreC.ManageInput
{
    public class LoginInput : IuiInput
    {
        public PageType Type => PageType.Login;
        public void checkUserInput(UI UI)
        {
            string username;
            string password;
            int id = -1;

            var input = Console.ReadLine();
            input = input.Replace(" ", null);
          
            switch (input)
            {
                case "1":
                    do
                    {
                        
                       

                        UI.Page.pageInfo = "Proceed as specified below to login or type BACK to go back to previous screen.";
                        UI.Page.instructions = "Provide your username";
                        UI.DrawUI(UI, false);



                        input = Console.ReadLine();
                        if (Helpers.isCommand(input, UI)) { break; }
                        username = input;

                        UI.Page.instructions = "Provide your password";
                        if (Helpers.isCommand(input, UI)) { break; }
                        UI.DrawUI(UI, true);

                        input = Console.ReadLine();
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
                        string feedback = "";

                        UI.Page.pageInfo = "Proceed as specified below to create a new User.";
                        UI.Page.instructions = "Provide a username";
                        UI.DrawUI(UI, false);

                        input = Console.ReadLine();
                        if (Helpers.isCommand(input, UI)) { break; }
                        UI.currentUser.UserName = input;


                        UI.Page.instructions = " Provide password";
                         UI.DrawUI(UI, true);


                        input = Console.ReadLine();
                        if (Helpers.isCommand(input, UI)) { break; }
                        UI.currentUser.Password = input;



                        bool createUser = UI.currentUser.createUser(UI.currentUser, out feedback);
                        if (createUser)
                        {
                            UI.Page.error = $"User created. Username: {UI.currentUser.UserName}";
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
                    
                //Forgot password

                default:

                    break;
            }
  
        }

    }
}