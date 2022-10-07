

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

            //string input = Console.ReadLine();


            //if (String.Equals(input.Replace(" ", null), "1"))
            //{
            //    //login 

            //}else if(String.Equals(input.Replace(" ", null), "2"))
            //{

            //    //create new user 

            //}else if(String.Equals(input.Replace(" ", null), "3"))
            //{
            //    //forgot password

            //}
            //else
            //{

            //    UI.Page.error = "You didn't choose a valid option";
            //}





            //Deserialization should be done in services but I can't parse deserialization result in method return easily. 
           

            bool userFound = false;
            bool correctPassword = false;
            bool logIn = false;
            string username;
            string password;
            int id = -1;

            UI.Page.pageInfo = "Proceed as specified below to login or type BACK to go back to previous screen.";

            UI.Page.instructions = "Provide your username";
            UI.DrawUI(UI, false);
             string input = Console.ReadLine();

            username = input;

            UI.Page.instructions = "Provide your password";
            UI.DrawUI(UI, false);
            input = Console.ReadLine();
            password = input;

           

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


            //foreach (var user in UsersList.results)
            //{
            //    if (user.UserName == username)
            //    {
            //        userFound = true;

            //        if (user.Password == password)
            //        {

            //            correctPassword = true;
            //            logIn = true;
            //            id = user.Id;
            //            break;



            //        }

            //    }

            //}
            //Your code goes here

        }

    }
}