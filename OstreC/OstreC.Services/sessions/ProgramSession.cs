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
        public CurrentUser currentUser = new CurrentUser(1, "Admin", "AdminPass", false);

       

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
                     
                    currentUser.UserName = userName;
                    currentUser.Password = password;
                    currentUser.Email = user.Email;
                    currentUser.Id = user.Id;
                    currentUser.LoggedIn = true;
                    return true;
                }
            }
            return false;
        }


    }


}
