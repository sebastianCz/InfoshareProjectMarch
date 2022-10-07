using OstreC.Interface;

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

            //Your code goes here

        }

        public void DisplaySomething()
        {

        }

    }
}
