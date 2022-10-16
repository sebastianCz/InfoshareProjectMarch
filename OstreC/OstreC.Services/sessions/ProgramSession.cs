using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{

    //Contains session related objects. 
    public class ProgramSession
    {
        //Instancied on init so UI can call it's methods   
        //Inherited by UI in console to update data based on input. 
        public CurrentUser CurrentUser { get; set; } 

        public GameSession GameSession { get; set; } 
        //If set to true program will exit on next iteration due to console logic. 
        public bool exit { get; set; } = false;




        //Updates user values. 
        public bool Login(string userName, string password)
        {

            var x = JsonFile.DeserializeUsersList("Users");

            foreach (var user in x.Results)
            {
                if (user.UserName == userName && user.Password == password)
                {
                     
                    CurrentUser.UserName = userName;
                    CurrentUser.Password = password;
                    CurrentUser.Email = user.Email;
                    CurrentUser.Id = user.Id;
                    CurrentUser.LoggedIn = true;
                    CurrentUser.SaveFileExists = user.SaveFileExists;
                    return true;
                }
            }
            return false;
        }


    }


}
