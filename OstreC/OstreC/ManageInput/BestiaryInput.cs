using OstreC;

namespace OstreC.ManageInput
{//Will use user input to filter through all monsters.
    public class BestiaryInput : IuiInput
    {
        public PageType Type => PageType.Bestiary;
        public void CheckUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.IsCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Your code goes here

        }

    }
}
