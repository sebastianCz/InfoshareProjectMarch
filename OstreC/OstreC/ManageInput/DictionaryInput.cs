using OstreC;

namespace OstreC.ManageInput
{//Will use user input to filter through all monsters.
    public class DictionaryInput : IuiInput
    {
        public PageType Type => PageType.Dictionary;
        public void CheckUserInput(UI UI)
        {

            var input = Console.ReadLine();

            if (Helpers.IsCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }
            else if (String.Equals(input, "1"))
            {
                Console.WriteLine("Metoda wczytująca bibliotekę historii");

            }
            else if (String.Equals(input, "2"))
            {
                Console.WriteLine("Metoda wczytująca profile wrogów");
            }
            //Your code goes here

        }

    }
}
