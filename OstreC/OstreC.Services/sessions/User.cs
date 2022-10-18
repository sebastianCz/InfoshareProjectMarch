using System.Linq;
namespace OstreC.Services
{
    
        public class User
        {

            public int Id { get; set; }

            public string UserName { get; set; }
            public string Password { get; set; }

            public string Email { get; set; }
        public bool SaveFileExists { get; set; }



     
            //public User(string username, string password,bool saveFileExists, int id = -1)
            //{
            //    Id = id;
            //    UserName = username;
            //    Password = password;
            //    this.SaveFileExists = saveFileExists;

            //}

        public string PresentUser()
        {
            return  $"Username: {this.UserName}  User email: {this.Email} User password: {this.Password}"; 
        }
        public string ShowEmail()
        {
            return $" {this.Email} ";
        }

        public string PresentUserBreakLine(bool xs)
        {
            return $"Username: {this.UserName} \n User email: {this.Email}\n User password: {this.Password}";
        }

        public bool UpdateUser(CurrentUser CurrentUser, string newData, int param)
        {

            var usersList = JsonFile.DeserializeUsersList("Users");
            bool updated = false;
            bool userExists = false;

            foreach (var user in usersList.Results)
            {
                if (user.UserName == CurrentUser.UserName)
                {
                    userExists = true;
                }
            }

            foreach (var user in usersList.Results)
            {
                if (user.Id == CurrentUser.Id)
                {
                    switch (param)
                    {
                        case 1:
                            user.UserName = newData;
                            CurrentUser.UserName = newData;
                            break;
                        case 2:
                            user.Password = newData;
                            CurrentUser.Password = newData;
                            break;
                        case 3:
                            if (newData.Contains("@") && newData.Contains("."))
                            {
                                user.Email = newData;
                                CurrentUser.Email = newData;
                                break;
                            }
                            else
                            {
                                return false;
                            }
                        case 4:
                            if(newData == "true") { user.SaveFileExists = true; }
                            if (newData == "false") { user.SaveFileExists = false; }

                            break;
                    }
                    updated = true;
                }
            }
            if (updated)
            {

                var x = JsonFile.SerializeUsersList(usersList);
                JsonFile.SerializedToJson(x, "Users");

                return true;
            }
            else
            {
                return false;
            }
        }
        

        public void DeleteUser(CurrentUser currentUser)
        {
            UsersList usersList = JsonFile.DeserializeUsersList("Users");

            bool found = false;
            //This variable is most likely avoidable. But I can't remove an objet from an array while iterating. I can't do X = I  as I will be equal to last index of usersList.
            //From here the Name of the variable is self explanatory.
            int[] IhadNoChoice = new int[1];
            for (int i = 0; i < usersList.Results.Count(); i++)
            {
                if (usersList.Results[i].Id == currentUser.Id)
                {
                    IhadNoChoice[0] = i;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                usersList.Results.Remove(usersList.Results[IhadNoChoice[0]]);
                //Sets values to empty values since log off is the next step. 
            
                var z = JsonFile.SerializeUsersList(usersList);
                JsonFile.SerializedToJson(z, "Users");
            }
            else
            {
                throw new Exception("Couldn't find ID of connected user.");
            }
        }
    }
}
 