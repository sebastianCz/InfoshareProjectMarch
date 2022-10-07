using System;
using System.Collections.Generic;
using System.Linq;
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
        }



    

}
 