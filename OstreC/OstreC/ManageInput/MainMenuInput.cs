using OstreC.Services;
namespace OstreC.ManageInput
{
    public class MainMenuInput : IuiInput
    {
        public PageType Type => PageType.Main_Menu;

        public void CheckUserInput(UI UI)
        {
            var input = Console.ReadLine();

            if (Helpers.IsCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }
            else if (Helpers.IsNumber(input))
            {

                if (String.Equals(input.ToLower().Replace(" ",null), "1"))
                {

                    UI.Page.switchPage(PageType.StartGame, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "2"))
                {
                    UI.Page.switchPage(PageType.Create_Character, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "3"))
                {
                    UI.Page.switchPage(PageType.Paragraph, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "4"))
                {
                    UI.Page.switchPage(PageType.Story_Bulider, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "5"))
                {
                    UI.Page.switchPage(PageType.ManageAccount, UI);
                }
                else if (String.Equals(input.ToLower().Replace(" ", null), "9"))
                {
                    UI.Page.switchPage(PageType.ExampleEnum, UI);
                }
                else
                {
                    UI.Page.Error = "You didn't provide a correct number";
                    UI.DrawUI(UI, false);
                }
            }
            else
            {
                UI.Page.Error = "You didn't provide a correct number";
                UI.DrawUI(UI, false);
            }

            //ENUM iteration -> So options can be created dynamically without having to update the entire logic each time. 
            //foreach (int i  in Enum.GetValues(typeof(PageType)))
            //{
            //    PageInfo += ($"{Enum.GetName(typeof(PageType), i)}");
            //}
        }
    }
}
