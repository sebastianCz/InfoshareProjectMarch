using OstreC;
using OstreC.Services;

namespace OstreC.ManageInput
{//Will use user input to filter through all monsters.
    public class DictionaryInput : IuiInput
    {
        public PageType Type => PageType.Dictionary;
        public void CheckUserInput(UI UI)
        {

            var input = Console.ReadLine();
            var dictionary = new GameDictionary();

            if (Helpers.IsCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }
            else if (String.Equals(input, "1"))
            {
                Console.WriteLine("Czesc, podaj mi imie przeciwnika");

                input = Console.ReadLine();
                //jakies tam checki inputu 

                string result = dictionary.FindEnemiesWithName(input);

                Console.WriteLine(result);




            }
            else if (String.Equals(input, "2"))
            {
                Console.WriteLine("Metoda wczytująca profile wrogów");
            }
            //Your code goes here

        }

    }
}
