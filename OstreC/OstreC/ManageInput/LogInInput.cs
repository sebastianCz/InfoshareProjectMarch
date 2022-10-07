

using OstreC.Interface;
using OstreC.Services;
using OstreC;
using static OstreC.Services.JsonFile;
using Newtonsoft.Json;

namespace OstreC.ManageInput
{
    public class LoginInput : IuiInput
    {
        public PageType Type => PageType.Login;
        public void checkUserInput(UI UI)
        {

            string input = Console.ReadLine();


                 

             



            var x = deserializeJsonFile("Users");
            UsersList UsersList = JsonConvert.DeserializeObject<UsersList>(x);

            bool userFound = false;
            bool correctPassword = false;
            bool logIn = false;
            string username;
            string password;
            int id = -1;

            

            UI.Page.instructions = "Provide your username";
            UI.DrawUI(UI, false);
             input = Console.ReadLine();

            username = input;

            UI.Page.instructions = "Provide your password";
            UI.DrawUI(UI, false);
            input = Console.ReadLine();
            password = input;

            foreach (var user in UsersList.results)
            {
                if (user.UserName == username)
                {
                    userFound = true;

                    if (user.Password == password)
                    {

                        correctPassword = true;
                        logIn = true;
                        id = user.Id;
                        break;



                    }

                }

            }

            if (logIn)
            {


                UI.User.UserName = username;
                UI.User.Password = password;
                UI.User.Id = id;
                UI.User.LoggedIn = true;
                UI.Page.switchPage(PageType.Main_Menu, UI);


            }
            else if (userFound != true)
            {
                userFound = false;
                correctPassword = false;
                UI.Page.error = "Provided user name doesn't exist.";


            }
            else if (correctPassword != true && userFound == true)
            {

                UI.Page.error = "Provided password was incorrect";

            }

            //Your code goes here

        }

    }
}