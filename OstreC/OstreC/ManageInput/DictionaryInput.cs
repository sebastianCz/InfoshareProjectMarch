using OstreC;
using OstreC.Services;
using System.Security.Cryptography.X509Certificates;

namespace OstreC.ManageInput
{
    public class DictionaryInput : IuiInput
    {
        public PageType Type => PageType.Dictionary;
        public void CheckUserInput(UI UI)
        {
            GameDictionary dictionary = new GameDictionary();             
             
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
                UI.Page.Instructions = "";
                UI.DrawUI(UI, false);
                Console.WriteLine($"This is list of all enemies in a game \n");
                dictionary.ShowAllEnemiesData();
                Console.WriteLine("\nPress ENTER to proceed");
                Console.ReadLine();
                UI.Page.SwitchPage(PageType.Dictionary, UI);
            }
            else if (String.Equals(input, "2"))
            {
                var next = false;
                    while (!next)
                    {

                    UI.Page.Instructions = "Provide name of the first enemy to compare";
                    UI.DrawUI(UI, false);
                    Console.WriteLine($"\nThis is list of all enemies in a game \n {dictionary.ShowEnemies()}");

                    string userInput = Console.ReadLine();
                    if(Helpers.IsCommand(userInput, UI)) { return; }

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
                    Console.WriteLine($"\nThis is list of all enemies in a game \n {dictionary.ShowEnemies()}");
                    string userInput = Console.ReadLine();
                    if (Helpers.IsCommand(userInput, UI)) { return; }

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
                UI.Page.Instructions = "This is list of all enemies in a game:";
                next = false;
                UI.DrawUI(UI, false);
                dictionary.CompareEnemies(monster1, monster2);
                Console.WriteLine("\nPress ENTER to proceed");
                Console.ReadLine();
                UI.Page.SwitchPage(PageType.Dictionary, UI);
            }
        }
    }
}
