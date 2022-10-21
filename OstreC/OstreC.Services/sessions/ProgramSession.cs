using OstreC.Database;
using OstreC.Services.Collections;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OstreC.Services
{


    //Instancied on init so UI can call it's methods   
    public class ProgramSession
    {
        //A list of action for each story. Displays in Main Menu.
      

        
        //Inherited by UI in console to update data based on input. 
        public CurrentUser CurrentUser { get; set; } 

        public GameSession GameSession { get; set; }

   
        public Dictionary<int, string> StoriesNames  { get { return Utilities.LoadDictionaryFromJson("Stories");}}
        public Dictionary<int, string> CharacterNames { get { return Utilities.LoadDictionaryFromJson("Characters"); } }

        //public Dictionary<int, string> CharactersNames{get {return Utilities.LoadDictionaryFromJson(CharactersNames, "Stories"); } set {CharactersNames = value; }}

        //If set to true program will Exit on next iteration due to console logic. 
        public bool Exit { get; set; } = false;

        //Updates user values. 
        public bool Login(string userName, string password)
        {
            var userList = JsonFile.DeserializeUsersList("Users");
            var user = userList.Results.FirstOrDefault(o => (o.UserName == userName) &&(o.Password == password ));

            if (user == null) return false;
            // CurrentUser has a Parameter LoggedIn. // That parameter is set to true when invoked. //   
            CurrentUser = CreateCurrentUser((User)user,true);
           return true;
        }
        public CurrentUser CreateCurrentUser(User user,bool loggedIn)
        {
           return new CurrentUser(user.UserName, user.Password, user.SaveFileExists, true, user.Id);
        }
        
        private GameSession CreateGameSession()
        {
            return new GameSession();
        }

        /// <summary>
        /// Retuns a list of all existing stories
        /// </summary>
        /// <param name="relationalPath"></param>
        /// <returns></returns>
        public string[] ShowAllStories(string relationalPath)
        {
            string[] allStories = ReaderJson.FindAllFileNames(relationalPath);
            return allStories; 
        }

        public bool CreateUser(string userName, string password, string email, out string feedback)
        {
            var allUsersList = JsonFile.DeserializeUsersList("Users");
            var userExists = allUsersList.Results.FirstOrDefault(user => user.UserName == userName);

            if (userExists != null)
            {
                feedback = "User with provided userName already exists";
                return false;
            }
            else if (userName.Length != 0)
            {
                var newUser = new CurrentUser(userName, password, false, false, allUsersList.Results.Count() + 1);
                allUsersList.Results.Add((User)newUser);

                string allUsersListToString = JsonFile.SerializeUsersList(allUsersList);
                JsonFile.SerializedToJson(allUsersListToString, "Users");
                feedback = "User created";
                return true;
            }
            else
            {
                feedback = "User Name provided is not valid. You can't provide an empty string for a username.";
                return false;
            }
        }
        public GameSession NewGame(string storyName, string characterName)
        {
            var session = new GameSession();
            session.FileLoaded = true;
            session.SaveFile = new SaveFile(0, 2, storyName);//Default Starting
            session.CurrentPlayer = JsonFile.DeserializeFile<Player>("Characters\\" + characterName);


            return session;
        }

        public GameSession LoadSave(string userName)
        {
            var session = new GameSession();
            session.FileLoaded = true;
            session.SaveFile = JsonFile.DeserializeSaveFile($"UsersFile\\" + userName);
            return session;
        }

    }
}
