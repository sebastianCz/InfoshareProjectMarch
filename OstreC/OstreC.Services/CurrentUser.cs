using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OstreC.Services
{
  
    public class CurrentUser : User
    {
        [JsonIgnore]
        public bool LoggedIn { get; set; }

        public CurrentUser(int id, string username, string password, bool loggedIn)
       : base(username, password, id)
        {
            LoggedIn = loggedIn;
        }

        public void logOff()
        {
            this.UserName = "";
            this.Password = "";
            this.Email = "";
            this.Id = 0;
            this.LoggedIn = false;

        }

        public bool Login(string userName, string password,CurrentUser CurrentUser)
        {

            var x = JsonFile.DeserializeUsersList("Users");

            foreach (var user in x.Results)
            {
                if (user.UserName == userName && user.Password == password)
                {
                    LoggedIn = true;
                    CurrentUser.UserName = userName;
                    CurrentUser.Password = password;
                    CurrentUser.Email = user.Email;
                    CurrentUser.Id = user.Id;
                    CurrentUser.LoggedIn = true;
                    return true;
                }
            }
            return false;
        }

        public void deleteUser(CurrentUser currentUser)
        {
            UsersList usersList = JsonFile.DeserializeUsersList("Users");
            
            bool found = false;
            //This variable is most likely avoidable. But I can't remove an objet from an array while iterating. I can't do X = I  as I will be equal to last index of usersList.
            //From here the name of the variable is self explanatory.
            int[] IhadNoChoice = new int[1];
                for(int i = 0; i < usersList.Results.Count(); i++)
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
                logOff();

                var z = JsonFile.SerializeUsersList(usersList);
                JsonFile.serializedToJson(z, "Users");


            }
            else
            {
                throw new Exception("Couldn't find ID of connected user.");

            }
             
            
          
           


        }

        public bool updateUser(CurrentUser CurrentUser,string newData,int param)
        {
            
            var usersList = JsonFile.DeserializeUsersList("Users");
            bool updated = false;
            bool userExists = false;

            foreach(var user in usersList.Results)
            {
                if(user.UserName == CurrentUser.UserName)
                {
                    userExists = true;
                }
            }

            foreach ( var user in usersList.Results )
            {
                if( user.Id == CurrentUser.Id)
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
                            if(newData.Contains("@") && newData.Contains(".")) {
                                user.Email = newData;
                                CurrentUser.Email = newData;
                                break;
                            }
                            else
                            {
                                return false;
                            }
                    }
                    updated = true;
                }
            }
            if (updated) {

                var x = JsonFile.SerializeUsersList(usersList);
                JsonFile.serializedToJson(x, "Users");

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool createUser(string userName,string password,string email,CurrentUser currentUser, out string feedback)
        {

            var usersList = JsonFile.DeserializeUsersList("Users");
            bool userExists = false;

            foreach (var user in usersList.Results)
            {
                if (user.UserName == userName)
                {


                    userExists = true;
                    break;
                }
            }

            if (userExists)
            {
                feedback = "User with provided userName already exists";
                return false;

            }else if (userName.Length != 0)
            {
                currentUser.Id = usersList.Results.Count() + 1;
                currentUser.Email = email;
                currentUser.UserName = userName;
                currentUser.Password = password;
                usersList.Results.Add((User)currentUser);

                var x = JsonFile.SerializeUsersList(usersList);
                JsonFile.serializedToJson(x, "Users");

                feedback = "User created";

                return true;
            }
            else
            {
                feedback = "User name provided is not valid. You can't provide an empty string for a username.";
                return false;
            }
        }

        public bool CanSendEmail(int emailType, string userName, CurrentUser currentUser, out string feedback)
        {
            //Checks if user exists
            var usersList = JsonFile.DeserializeUsersList("Users");
            var usersArray = usersList.Results.ToArray();
            bool userExists = false;

            foreach (var user in usersArray)
            {
                if (user.UserName == userName)
                {
                    userExists = true;
                    currentUser.UserName = userName;
                    currentUser.Email = user.Email;
                    currentUser.Id = user.Id;
                    currentUser.Password = user.Password;  
                    break;
                }
            }
            switch (userExists)
            {
                case true:

                    if(sendEmailSMTP(1, currentUser,out feedback)) { feedback = "Email sent."; return true; }
                    feedback = "Username Exists but email couldn't be sent";
                    return false;

                case false:

                    feedback = "Provided username doesn't exist.";
                    return false;

                default:

                    throw new Exception("This method should exit either with user existing ( so a password recovery email is sent) or non existing.");
                    break;
            }
        }

        private bool sendEmailSMTP(int emailType,CurrentUser currentUser, out string feedback)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ostreCGame@gmail.com", "jgkeyglxajjymsft"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("ostreCGame@gmail.com"),
                Subject = "",
                Body = "",
                IsBodyHtml = true,
            };

            //Forgot Password
            if (emailType == 1)
            {
                mailMessage.Subject = "Ostre C Game password recovery email";
                mailMessage.Body = $"<h1>Hello,</h1> <br> <h2> dear {currentUser.UserName}</h2><br> You forgot your password. <br> For now the best I can do is send you your password. Here it is : <br>" +
                    $"Your username: {currentUser.UserName} <br> Your password: {currentUser.Password} <br> Please don't forget your password going forward. <br> <b>Regards</b>,<br><b> Ostre C team</b>";

                mailMessage.To.Add(currentUser.Email);

                feedback = "Email sent on the email adress assigned to your existing account :" + currentUser.Email;
                smtpClient.Send(mailMessage);
                return true;
            }
            else
            {
                feedback = "An non existing email template was chosen";
                throw new Exception(feedback);
                return false;

            }
        }
    }
}
