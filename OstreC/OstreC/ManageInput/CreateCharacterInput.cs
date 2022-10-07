using OstreC.Interface;
using OstreC.Services.Characters;

namespace OstreC.ManageInput
{
    public class CreateCharacterInput : IuiInput
    {
        public PageType Type => PageType.Create_Character;
        public void checkUserInput(UI UI)
        {
            CreateCharacterHelper createCharacterHelper = new CreateCharacterHelper();
            createCharacterHelper.CreateMenu();

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }
            //UI.DrawUI(UI, false);
        }


    }
}
