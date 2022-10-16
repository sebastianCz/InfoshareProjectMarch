using OstreC.Services;


namespace OstreC
{
    //Static " helper " methods used in different contexts.


    public static class Helpers
    {
        //checks if provided string is a number.
        public static bool IsNumber(string userInput)
        {
            bool isNr = int.TryParse(userInput, out int n);
            if (isNr) { return true; }
            return false;


        }
        //checks if provided string is a command.
        public static bool IsCommand(string userInput, UI UI)
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
        //Contains code to execute if provided string is a command.
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
                case "BACK":
                    UI.Page.switchPage(UI.Page.CurrentType, UI);
                    break;
                default:
                    //Method shouldn't be inkoked if input != command. 
                    throw new Exception();
            }
        }

      


    }
}