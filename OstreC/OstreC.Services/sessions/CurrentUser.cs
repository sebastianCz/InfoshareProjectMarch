﻿ using Newtonsoft.Json;

namespace OstreC.Services
{
  //Contains variables useful only for currently Logged in User.
    public class CurrentUser : User
    {
        [JsonIgnore]
        public bool LoggedIn { get; set; }

        //Stores stories ID
        internal List<Story> LinkedStoriesId { get; set; }

        public CurrentUser(string username, string password, bool SaveFileExists, bool loggedIn,int id)
       : base(username, password,SaveFileExists,id)
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
