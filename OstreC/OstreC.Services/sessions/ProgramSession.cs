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
        public CurrentUser currentUser { get; set; } //= new CurrentUser("Default", "Default", false, false, -1);// Default values. 

        public GameSession GameSession { get; set; } //
        //Not sure if we need an instance of this at all times. We most likely don't. 
        //internal AllEnemyList enemyList = JsonFile.DeserializeEnemyList("Enemy");
       

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
                    currentUser.SaveFileExists = user.SaveFileExists;
                    return true;
                }
            }
            return false;
        }


    }


}
