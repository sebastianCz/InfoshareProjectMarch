using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;




namespace OstreC.Services
{
    
        public class User
        {

            public int Id { get; set; }

            public string UserName { get; set; }
            public string Password { get; set; }

            public string Email { get; set; }


            //Init with -1 until defined.
            public User(string username, string password, int id = -1)
            {
                Id = id;
                UserName = username;
                Password = password;

            }

           

        }
        
}
 