using Newtonsoft.Json;

namespace OstreC.Services
{
    //Contains variables useful only for currently Logged in User.
    public class CurrentUser : User
    {
        [JsonIgnore]
        public bool LoggedIn { get; set; }

        public CurrentUser() { }
        public CurrentUser(string username, string password, bool saveFileExists, bool loggedIn,int id,string email)
        {
            UserName = username;
            Password = password;
            SaveFileExists = saveFileExists;
            LoggedIn = loggedIn;
            Email = email;
            Id = id;
        }

        //Changes values to empty values since console 
        public void logOff(CurrentUser user)
        {
            user = null;
        }     
    }
}
