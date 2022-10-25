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
            var userList = JsonFile.DeserializeFile<UsersList>("Users");
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

        public bool CreateUser(string userName, string password, string email, out string feedback)
        {
            var allUsersList = JsonFile.DeserializeFile<UsersList>("Users");
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

                JsonFile.SerializedToJson(allUsersList, "Users");
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
            session.SaveFile = JsonFile.DeserializeFile<SaveFile>($"UsersFile\\" + userName);
            session.FileLoaded = true;
            session.CurrentPlayer = JsonFile.DeserializeFile<Player>($"Characters\\" + session.SaveFile.CharacterName);
            session.CurrentPlayer.HealthPoints = session.SaveFile.HealthPoints;    
            return session;
        }
    }
}
