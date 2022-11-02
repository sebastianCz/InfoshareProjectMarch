namespace OstreC.ManageInput
{
    public class ManageAccount : IuiInput
    {
        //Has to define it's type.Type has to be one of the existing types defined in IuiInput
        public PageType Type => PageType.ManageAccount;

        //Main function. It's name can't change.
        public void CheckUserInput(UI UI)
        {
            var input = Console.ReadLine();
            if (Helpers.IsCommand(input, UI)) { return; }

            if (!Helpers.IsNumber(input) || input.Length == 0)
            {
                UI.Page.Error = "Invalit input";
                UI.DrawUI(UI, false);
                return;
            }

            switch (input)
            {
                case "1":

                    UI.Page.Instructions = "Press 1 to change your username.\n Press 2 to change your password \n Press 3 to change your email.";
                    UI.DrawUI(UI, true);

                    input = Console.ReadLine();
                    if (Helpers.IsCommand(input, UI)) return;

                    switch (input)
                    {
                        case "1":
                            do
                            {
                                UI.Page.Instructions = "Type your new username.It can't be only a number. It has to contain at least 1 character.";
                                UI.DrawUI(UI, false);

                                input = Console.ReadLine().Trim();
                                if (Helpers.IsCommand(input, UI)) { return; }

                                if (!Helpers.IsNumber(input) & input.Length != 0)
                                {
                                    UI.Page.Instructions = "Please wait. We are changing your username.";
                                    UI.DrawUI(UI, true);

                                    if (UI.CurrentUser.UpdateUser(UI.CurrentUser, input, 1))
                                    {
                                        UI.Page.Error = "Username Updated";
                                        UI.Page.SwitchPage(PageType.ManageAccount, UI);
                                        return;
                                    }
                                    else
                                    {
                                        throw new Exception("Currentuser ID wasn't found in Users.json at updatedUser(). It shouldn't be possible. Only logged in users can change the name. ");
                                    }
                                }
                                else
                                {
                                    UI.Page.Error = "Invalid input.";
                                }

                            } while (true);
                            break;

                        case "2":
                            do
                            {
                                UI.Page.Instructions = "Type your new password.It can't be only a number. It has to contain at least 1 character.";
                                UI.DrawUI(UI, false);

                                input = Console.ReadLine().Trim();
                                if (Helpers.IsCommand(input, UI)) { return; }

                                if (!Helpers.IsNumber(input) & input.Length != 0)
                                {
                                    UI.Page.Instructions = "Please wait. We are changing your password.";
                                    UI.DrawUI(UI, true);

                                    if (UI.CurrentUser.UpdateUser(UI.CurrentUser, input, 2))
                                    {
                                        UI.Page.Error = "Username Updated";
                                        UI.Page.SwitchPage(PageType.ManageAccount, UI);
                                        return;
                                    }
                                    else
                                    {
                                        throw new Exception("Currentuser ID wasn't found in Users.json at updatedUser(). It shouldn't be possible. Only logged in users can change the name. ");
                                    }
                                }
                                else
                                {
                                    UI.Page.Error = "Invalid input.";
                                }

                            } while (true);
                            break;

                        case "3":

                            do
                            {
                                UI.Page.Instructions = "Type your new email.It can't be only a number. It has to contain both key characters: '@' and '.'. Make sure it's valid or you won't receive our emails!";
                                UI.DrawUI(UI, false);

                                input = Console.ReadLine().Trim();
                                if (Helpers.IsCommand(input, UI)) { return; }

                                if (!Helpers.IsNumber(input) & input.Length != 0)
                                {
                                    UI.Page.Instructions = "Please wait. We are changing your email.";
                                    UI.DrawUI(UI, true);
                                    if (UI.CurrentUser.UpdateUser(UI.CurrentUser, input, 3))
                                    {
                                        UI.Page.Error = "Email Updated";
                                        UI.Page.SwitchPage(PageType.ManageAccount, UI);
                                        return;
                                    }
                                    else
                                    {
                                        UI.Page.Error = "Invalid data provided";
                                    }
                                }
                                else
                                {
                                    UI.Page.Error = "Invalid input.";
                                }
                            } while (true);
                            break;

                        default:
                            break;
                    }
                    break;

                case "2":
                    UI.Page.Instructions = "Are you sure you want to delete your account? If you do so you will loose access to all your saves. Type DELETE(case sensitive) or any key to leave this menu.";
                    UI.DrawUI(UI, true);
                    input = Console.ReadLine();
                    if (Helpers.IsCommand(input, UI)) return;

                    if (input == "DELETE")
                    {
                        UI.CurrentUser.DeleteUser(UI.CurrentUser);
                        UI.CurrentUser.logOff(UI.CurrentUser);
                        UI.Page.SwitchPage(PageType.Login, UI);
                    }
                    break;

                case "3":
                    UI.Page.SwitchPage(PageType.Login, UI);
                    break;

                default:
                    UI.Page.Error = ("You provided the wrong number");
                    UI.DrawUI(UI, false);
                    break;
            }
        }
    }
}