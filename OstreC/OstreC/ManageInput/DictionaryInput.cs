using OstreC;
using OstreC.Services;
using System.Security.Cryptography.X509Certificates;

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
                Console.WriteLine("Czesc, podaj mi imie przeciwnika"); //library with stories

                input = Console.ReadLine();
                //jakies tam checki inputu 

                string result = dictionary.FindEnemiesWithName(input);

                Console.WriteLine(result);
            }
            else if (String.Equals(input, "2"))
            {
                Console.WriteLine("What action you want to take? \n 1) Show me all list with enemies \n 2) Compare two enemies with each other \n 3) Search in dictionary by key word");
                bool inputNumber = int.TryParse(Console.ReadLine(), out int result);
                if (inputNumber)
                {
                    switch(result)
                    {
                        case 1:
                            Console.WriteLine($"This is list of all enemies in a game \n {dictionary.LoadEnemies()}");
                            
                        break;

                        case 2:
                            Console.WriteLine("Select the enemies you want to compare: \n 1) GoblinWarrior \n 2) GoblinArcher \n 3) Orc \n 4) Mirmidon \n 5) Phobos");
                            //UI.CharacterNames;

                        break;

                    }
                }
            }
            //Your code goes here

        }

    }
}
