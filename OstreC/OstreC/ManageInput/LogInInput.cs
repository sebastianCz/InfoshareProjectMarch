

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

           
            var input = Console.ReadLine();
            input = input.Replace(" ", null);
            bool next = false;
            switch (input)
            {
                case "1":
                    do
                    {
                        next = false;
                        string username;
                        string password;
                        int id = -1;

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

                        bool login = UI.User.Login(username, password);

                        if (login)
                        {
                            UI.Page.switchPage(PageType.Main_Menu, UI);
                            UI.User.UserName = username;
                            UI.User.Password = password;
                            UI.User.Id = id;
                            UI.User.LoggedIn = true;

                            break;
                        }

                        UI.Page.error = "Your password or login were not correct";

                        
                    } while (next != true);
                    break;
                case "2":
                    //create new user
                    break;

                case "3":

                //Forgot password

                default:

                    break;
            }
  
        }

    }
}