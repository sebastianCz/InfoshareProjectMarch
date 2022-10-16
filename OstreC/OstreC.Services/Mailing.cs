using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services
{
    public class Mailing
    {
        //Verifies if user exists and if yes sends an email. 
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
                    //sends email if yes
                    if (sendEmailSMTP(1, currentUser, out feedback)) { feedback = "Email sent."; return true; }
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


        //Method sends an email if invoked.
        //Feedback param used to provide 'waiting" message before sending email. It can take time sometimes. 
        public bool sendEmailSMTP(int emailType,CurrentUser currentUser, out string feedback)
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

            //Forgot Password template
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
