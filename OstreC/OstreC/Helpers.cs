using OstreC.Interface;

namespace OstreC
{
    public static class Helpers
    {
        public static bool isNumber(string userInput)
        {
            bool isNr = int.TryParse(userInput, out int n);
            if (isNr) { return true; }
            return false;


        }

        public static bool isCommand(string userInput, UI UI)
        {
            foreach (string command in UI._menuCommands)
            {
                if (command == userInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Are you sure? You go back to menu.\nPress 'Y' - yes or 'N' - no");
                    Console.ResetColor();              
                    do
                    {
                        ConsoleKey key = Console.ReadKey().Key;
                        switch (key)
                        {
                            case ConsoleKey.Y:
                                UI.Page.switchPage(PageType.Main_Menu, UI);
                                return true;
                            case ConsoleKey.N:
                                UI.DrawUI(UI, true);
                                return true;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You didn't press the correct key. Try again.");
                                Console.ResetColor();
                                break;
                        }
                    } while (true);
                }
            }
            return false;
        }

        public static class EnumUtil
        {
            public static IEnumerable<T> GetValues<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>();
            }
        }

        public static void HandleCommand(string command, UI UI)
        {

            switch (command)
            {
                case "EXIT":
                    UI.exit = true;
                    break;
                case "MENU":
                case "MAIN_MENU":
                    UI.Page.switchPage(PageType.Main_Menu, UI);
                    break;
                default:
                    //Method shouldn't be inkoked if input != command. 
                    throw new Exception();
            }
        }
    }
}