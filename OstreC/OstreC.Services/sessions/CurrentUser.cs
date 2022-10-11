using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace OstreC.Services
{
  
    public class CurrentUser : User
    {
        [JsonIgnore]
        public bool LoggedIn { get; set; }

        //Stores stories ID
        internal List<Story> LinkedStoriesId { get; set; }

        public CurrentUser(int id, string username, string password, bool loggedIn)
       : base(username, password, id)
        {
            LoggedIn = loggedIn;
        }

        //Changes values to empty values since console 
        public void logOff()
        {
            this.UserName = "";
            this.Password = "";
            this.Email = "";
            this.Id = 0;
            this.LoggedIn = false;

        }

        public string showLinkedStoriesName()
        {
            string x = "";

            for (int i=0; i < LinkedStoriesId.Count(); i++)
            {
                //Open Stories Json file, read everything.

            } 

            return x;

        }


    }
}
