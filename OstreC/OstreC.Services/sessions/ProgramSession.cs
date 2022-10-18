using System; 
using System.Linq;

namespace OstreC.Services
{

    //Contains session related objects. 
    public class ProgramSession
    {
        //Instancied on init so UI can call it's methods   
        //Inherited by UI in console to update data based on input. 
        public CurrentUser CurrentUser { get; set; } 

        public GameSession GameSession { get; set; } 

        //If set to true program will Exit on next iteration due to console logic. 
        public bool Exit { get; set; } = false;

        //Updates user values. 
        public bool Login(string userName, string password)
        {
            var userList = JsonFile.DeserializeUsersList("Users");
            var user = userList.Results.FirstOrDefault(o => (o.UserName == userName) &&(o.Password == password ));

            if (user == null) return false;
            // CurrentUser has a Parameter LoggedIn. // That parameter is set to true when invoked. //   
            CurrentUser = CurrentUserInit((User)user);
           return true;
        }
        public CurrentUser CurrentUserInit(User user)
        {
           return new CurrentUser(user.UserName, user.Password, user.SaveFileExists, true, user.Id);
        }
        public bool CreateGameSession()
        {
            return false;
        }
    }
}
