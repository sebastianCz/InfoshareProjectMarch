using OstreC.Interface;
using OstreC.Services.Characters;

namespace OstreC.ManageInput
{
    public class CreateCharacterInput : IuiInput
    {
        public PageType Type => PageType.Create_Character;
        public void checkUserInput(UI UI)
        {


            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }
            
            Console.WriteLine("Test z miejsca CreateCharacterInput");
            //Your code goes here
            CreatePlayer cp = new CreatePlayer();
            //cp.Create();
            Console.WriteLine("Test z miejsca CreateCharacterInput");
            UI.DrawUI(UI, false);
        }
    }
}
