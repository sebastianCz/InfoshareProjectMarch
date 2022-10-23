using Newtonsoft.Json.Linq;
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
                    UI.Exit = true;
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
        public static bool YesOrNoKey(bool loop)
        {
            do
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                    default:
                        if (!loop) return false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You didn't press the correct key. Try again.");
                        Console.ResetColor();
                        break;
                }
            } while (true);
        }

        public static void WriteLineColorText(string textColored, ConsoleColor firstColor = ConsoleColor.DarkGreen)
        {
            Console.ForegroundColor = firstColor;
            Console.WriteLine(textColored);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteColorText(string textColored, ConsoleColor firstColor = ConsoleColor.DarkGreen)
        {
            Console.ForegroundColor = firstColor;
            Console.Write(textColored);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int ThrowDice(UI UI)
        {
            int powerThrow = 1;            
            UI.Page.Instructions = $"Press the right arrow to increase the power of the dice throw or the left arrow to decrease the power. \nPress Enter to accept the power of the dice throw.";
            UI.DrawUI(UI, false);
            string power = $" Power({powerThrow}/ 10): █";
            do
            {
                Console.WriteLine(power);               
                ConsoleKey key = Console.ReadKey().Key;                                       
                if (key == ConsoleKey.Enter) break;
                else if (key == ConsoleKey.LeftArrow && powerThrow > 1) powerThrow--;
                else if (key == ConsoleKey.RightArrow && powerThrow < 10) powerThrow++;
                power = $" Power({powerThrow}/ 10): ";

                for (int i = 0; i < powerThrow; i++)
                {
                    power += "█";
                }
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.WriteLine("                                                      ");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            } while (true);

            int valueRoll = 0;

            for (int i = 0; i < powerThrow * powerThrow; i++)
            {
                Random rand = new Random();
                valueRoll = rand.Next(1, 21);

                Console.WriteLine(" Roll:" + valueRoll);
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                int timeSleep = (int)Math.Pow(2, (i / powerThrow));
                Thread.Sleep(timeSleep);
                Console.WriteLine("                                                      ");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            }
            Console.WriteLine(" Roll:" + valueRoll);
            Console.WriteLine("\nPress anything.");
            Console.ReadKey();
            return valueRoll;
        }
    }
}