using OstreC.Services;
using OstreC;
using OstreC.Interface;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;
 


//UI UI = new UI();
//UI.Page.switchPage(PageType.Login, UI);

//UI.Page.switchPage(PageType.Main_Menu, UI);

//do
//{

//    UI.checkInput(UI);

//} while (UI.exit == false);

var smtpClient = new SmtpClient("smtp.gmail.com")
{
    Port = 587,
    Credentials = new NetworkCredential("ostreCGame@gmail.com", "jgkeyglxajjymsft"),
    EnableSsl = true,
};


var mailMessage = new MailMessage
{
    From = new MailAddress("ostreCGame@gmail.com"),
    Subject = "generic subject",
    Body = "<h1>Hello</h1>",
    IsBodyHtml = true,
};
mailMessage.To.Add("sebastianczarnowski95@gmail.com");

smtpClient.Send(mailMessage);




