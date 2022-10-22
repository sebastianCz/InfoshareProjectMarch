using OstreC.Services;
  
namespace OstreC.ManageInput
{
    public class LoginInput : IuiInput
    {
        public PageType Type => PageType.Login;
        public void CheckUserInput(UI UI)
        {
            string userName;
            string password;
            string email = "";
            int id = -1;
            string feedback = "";
             
            var input = Console.ReadLine();
            input = input.Replace(" ", null);
            
            switch (input)
            {
                //Login  
                case "1":
                    do
                    { 
                        UI.Page.PageInfo = "Proceed as specified below to login or type BACK to go back to previous screen.";

                        UI.Page.Instructions = "Provide your username";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine().Trim(); 

                        userName = input; 

                        UI.Page.Instructions = "Provide your password";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                        if (Helpers.IsCommand(input, UI)) { return; }
                        password = input;


                        bool login = UI.Login(userName, password);
                        Console.WriteLine(UI.CurrentUser);
                        if (login)
                        {
                            UI.Page.switchPage(PageType.Main_Menu, UI);
 
                            break;
                        }

                        UI.Page.Error = "Your password or login were not correct.Press enter to proceed.";
                        UI.DrawUI(UI, false);
                        Console.ReadLine();
                        UI.Page.switchPage(PageType.Login,UI);

                        break;

                        
                    } while (true);
                    break;

                    //Create new user
                case "2":
                     
                        bool userCreated = false;

                        UI.Page.PageInfo = "Proceed as specified below to create a new User.";
                        UI.Page.Instructions = "Provide a username.Must be at least 1 character and can't be only a number.";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine().Trim(); 
                        
                        userName = input;
                        UI.Page.Instructions = " Provide a password.Must be at least 1 character and can't be only a number.";
                         UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                       
                        password = input;
                        UI.Page.Instructions = " Provide your email.Make sure it's correct.It must contain '@' and '.'.\n There's no email validation to see if the email exists. \n If you provide a wrong one you won't receive emails from us!  ";
                        UI.DrawUI(UI, true);
                        input = Console.ReadLine();

                      
                        
                        
                        email= input;
                       //Checks user input. If it's correct creates user and serialises the new Users.Json file. If not returns to main login page. Returns bool to know if operation succeeded.
                        if(email.Contains("@") && email.Contains(".") && userName.Length != 0 && password.Length != 0 && !Helpers.IsNumber(password) && !Helpers.IsNumber(userName))
                        {
                           userCreated = UI.CreateUser(userName, password, email, out feedback);
                        }
                        else
                        {
                            UI.Page.Error= (" You provided wrong data. Make sure your username and password is not only a number and contains at least 1 character.\n Make sure your email contains the following 2 characters" +
                                $"'@' and '.' \n {feedback}\n Press enter to attempt again.");
                            UI.Page.Instructions = "";
                            UI.DrawUI(UI, false);
                            Console.ReadLine();
                            UI.Page.switchPage(PageType.Login,UI);

                            return;
                        }
                        
                        
                        if (userCreated)
                        {
                           
                            UI.Page.Instructions = $"User created. \n Username:{userName} \n Password:{password} \n email: {email} \n If you provided the wrong email login and change it. ";
                            UI.Page.Error = "Press enter to go back to main login page. ";

                            
                        
                            UI.DrawUI(UI, false);
                            Console.ReadLine();
                            UI.Page.switchPage(UI.Page.CurrentType, UI);
                            break;
                        }
                        else
                        {
                            UI.Page.Error = "User already exists.";
                        UI.Page.Instructions = "Press Enter to go back to main menu.";
                            UI.DrawUI(UI, false);
                            Console.ReadLine();
                            UI.Page.switchPage(UI.Page.CurrentType, UI);
                            UI.Page.Error = feedback;
                            
                        }

                       
                     

                   
                    break;

                    //Passowrd recovery
                case "3":

                    UI.Page.Instructions = " You forgot your password. Please provide your username. ";
                    UI.DrawUI(UI,true);

                    input = Console.ReadLine().Trim();
                  

                    userName = input;

                    UI.Page.Instructions = "Attempting to send password recovery email for provided username. Retrieving user data. Please wait. This process should take a couple seconds";
                    UI.DrawUI(UI, true);

                    Mailing Mail = new Mailing();
                    // int = email template, username provided just above, UI.CurrentUser = obj holding all data, feedback == Error validation attempt on Services side of the app. 
                    bool test = Mail.CanSendEmail(1, userName,UI.CurrentUser, out  feedback);

                    if (test)
                    {
                        UI.Page.Instructions = " We sent you an email with the password recovery. Press enter to proceed to main screen. ";
                        UI.DrawUI(UI, true);

                        Console.ReadLine();
                        UI.Page.switchPage(PageType.Login, UI);
                        return;
                    }
                    else
                    {
                        UI.Page.Instructions = " You provided wrong username. email can't be sent.  Press enter to proceed.";
                        UI.DrawUI(UI, true);


                        Console.ReadLine();
                        UI.Page.switchPage(PageType.Login, UI);

                        return;
                    } 
                default:

                    UI.DrawUI(UI, false);
                    UI.Page.Error = " You provded the wrong number. Please try again";
                    UI.DrawUI(UI, false);

                    break;
            } 
        } 
    }
}