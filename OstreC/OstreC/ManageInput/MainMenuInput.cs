using OstreC.Interface;

namespace OstreC.ManageInput
{
    public class MainMenuInput : IuiInput
    {
        public PageType Type => PageType.Main_Menu;

        public void checkUserInput(UI UI)
        {
            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }
            else if (Helpers.isNumber(input))
            {



                if (String.Equals(input.ToLower().Replace(" ",null), "1"))
                {
                    UI.Page.switchPage(PageType.Create_Character, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "2"))
                {
                    UI.Page.switchPage(PageType.Create_NewGame, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "3"))
                {
                    UI.Page.switchPage(PageType.Load_Game, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "4"))
                {
                    UI.Page.switchPage(PageType.Paragraph, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "5"))
                {
                    UI.Page.switchPage(PageType.Story_Bulider, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "6"))
                {
                    UI.Page.switchPage(PageType.ManageAccount, UI);
                } else if (String.Equals(input.ToLower().Replace(" ", null), "9"))
                {
                    UI.Page.switchPage(PageType.ExampleEnum, UI);
                }
                else
                {
                    UI.Page.error = "You didn't provide a correct number";
                    UI.DrawUI(UI, false);
                }
            }
            else
            {
                UI.Page.error = "You didn't provide a correct number";
                UI.DrawUI(UI, false);
            }

            //ENUM iteration -> So options can be created dynamically without having to update the entire logic each time. 
            //foreach (int i  in Enum.GetValues(typeof(PageType)))
            //{
            //    pageInfo += ($"{Enum.GetName(typeof(PageType), i)}");
            //}
        }
    }
}
