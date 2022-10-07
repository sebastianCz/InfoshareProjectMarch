using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
    
        public class User
        {

            public int Id { get; set; }

            public string UserName { get; set; }
            public string Password { get; set; }


            //Init with -1 until defined.
            public User(string username, string password, int id = -1)
            {
                Id = id;
                UserName = username;
                Password = password;

            }



        }
        public class currentUser : User
        {
            
            public bool LoggedIn { get; set; }

            public currentUser(int id, string username, string password, bool loggedIn)
           : base(username, password, id)
            {
                LoggedIn = loggedIn;
            }

            public bool Login(string userName,string password)
        {
            
             var x = JsonFile.Deserialize("Users");

            foreach(var user in x.Results)
            {
                if(user.UserName == userName && user.Password == password ) {
                    LoggedIn = true;

                    return true;
                }

                
            }
            return false;
        }

        public bool createUser(currentUser currentUser,out string comment)
        {
            var usersList = JsonFile.Deserialize("Users");
            var usersArray = usersList.Results.ToArray();
            bool userExists = false;

            foreach (var user in usersArray)
            {
                if(user.UserName == currentUser.UserName)
                {
                    userExists = true;
                    break;
                }


            }
           

            if (userExists)
            {
                comment = "User with provided userName already exists";
                return false;
            }
            if (currentUser.UserName.Length != 0)
            {
                currentUser.Id = usersList.Results.Count() + 1;
                usersList.Results.Add(currentUser);

                var x = JsonFile.Serialize(usersList);
                JsonFile.serializedToJson(x, "Users");
               
                comment = "User created";

                return true;
            }
            else
            {
                comment = "User name provided is not valid. You can't provide an empty string for a username.";
                return false;


            }



        }


        }



    

}
 