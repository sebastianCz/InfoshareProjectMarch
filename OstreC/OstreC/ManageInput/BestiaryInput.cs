using OstreC.Interface;

namespace OstreC.ManageInput
{
    public class BestiaryInput : IuiInput
    {
        public PageType Type => PageType.Bestiary;
        public void checkUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.isCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Your code goes here

        }

    }
}
