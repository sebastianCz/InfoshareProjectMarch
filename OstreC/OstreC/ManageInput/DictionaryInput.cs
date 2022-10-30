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
            GameDictionary dictionary = new GameDictionary();




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
            
             
            // */
            //while (true)
            //{
            //    var input1 = Console.ReadLine().ToUpper().Trim();
            //    if (input1 != string.Empty);
            //    {

            //        break;
            //    }

            //}
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
            UI.DrawUI(UI, false);

            var input = Console.ReadLine();
            Enemy monster1 = null;
            Enemy monster2 = null;
           

            if (Helpers.IsCommand(input, UI))
            {
                Helpers.HandleCommand(input, UI);
            }
            else if (String.Equals(input, "1"))
            {
                Console.WriteLine("Library with enemies");

                Console.WriteLine($"This is list of all enemies in a game \n {dictionary.ShowEnemies()}");

            }
            else if (String.Equals(input, "2"))
            {
                var next = false;
                    while (!next)
                    {
                    UI.Page.Instructions = "Provide name of the first enemy to compare";
                    UI.DrawUI(UI, false);
                    string userInput = Console.ReadLine();
                        foreach (var Enemy in dictionary.Enemies)
                        {
                            if (Enemy.Name == userInput)
                            {
                                monster1 = Enemy;
                                next = true;
                            break;
                            }
                        }
                        UI.Page.Error = "You provide the wrong name,"; 
                    }
                UI.Page.Error = "";
                next = false;
                while (!next)
                {
                    UI.Page.Instructions = "Provide the name of the secend enemy";
                    UI.DrawUI(UI, false);
                    string userInput = Console.ReadLine();
                    foreach (var Enemy in dictionary.Enemies)
                    {
                        if (Enemy.Name == userInput)
                        {
                            monster2 = Enemy;
                            next = true;
                            break;
                        }
                    }
                    UI.Page.Error = "You provide the wrong name,";
                }
                UI.Page.Error = "";
                next = false;
                dictionary.CompareEnemies(monster1, monster2);
                Console.WriteLine("Press anything to proceed");
                Console.ReadLine();
            }


        }

        public void checkIfEnemyExists()
        {
            

        }

    }
}
