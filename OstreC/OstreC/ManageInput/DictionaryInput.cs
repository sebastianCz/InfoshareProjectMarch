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
            var dictionary = new GameDictionary();
            //Pozwolic uzytkownikowi wpisac nazwe przeciwnika 1 oraz 2. 
            //User input1 oraz user input2
            //monster1 oraz monster2

            //Sprawdzic czy podany przez uzytkownika przeciwnik istnieje w liscie dictionary.Enemies i jezeli tak, to zapiszemy jego index w zmiennej monsterIndex.
            /*
             foreach(var x in dictionary.Enemies){
                         x.Name == userinput .name ;
                        monster1 = x
            }
            //Jezeli tak to uruchamiamy methode Compare enemies przekazujac dane konkretnych dwoch przeciwnikow.

              dictionary.compare(monster1,monster2)

            //Metoda compare porownuje przeciwnikow 

             
             */

            ///Jak moze wygladac calos?
            /*
             while(true){
            var input 1 = console.readline();       
             //Sprawdzic czy input faktycznie jest stringiem, czy nie jest liczba itd.   
            .
             if (Helpers.IsCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }

            //Sprawdzamy czy przeciwnik istnieje ? 

            //Jezeli tak, to robimy : break;
            }
            while(true){
            //Do the same as above for monster 2
            }

            jezeli udalo sie przypisac obu przeciwnikow -> wywolujemy compare ktory zwraca nam stringa z rezultatem.
            np.: 
            var result = dictionary.compare(monster1,monster2);
            UI.Page.Instructions = result;
            UI.Page.Error
            UI.Page.PageInfo = 
            UI.Draw(true);
             
             
             */


            var input = Console.ReadLine();
           

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

        public void checkIfEnemyExists()
        {
            

        }

    }
}
