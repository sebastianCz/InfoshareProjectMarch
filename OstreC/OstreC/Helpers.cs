using OstreC.Services;

namespace OstreC
{
    //Static " helper " methods used in different contexts.
    public static class Helpers
    {

        public static string ChooseCharacterToDelete(List<String> characters)
        {
            ConsoleKeyInfo keyinfo;
            int index = 0;
            Helpers.WriteLineColorText("Choose which character you want to delete\nUse the left or right arrow on the keyboard and press ENTER to confirm or esc to exit.");
            do
            {
                Helpers.WriteColorText($"Character {index + 1}/{characters.Count()}: ", ConsoleColor.Magenta);
                Console.WriteLine(characters[index]);

                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (index + 1 >= characters.Count()) index = 0;
                    else index++;
                }
                else if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (index <= 0) index = characters.Count() - 1;
                    else index--;
                }
                else if (keyinfo.Key == ConsoleKey.Enter) break;
                else if(keyinfo.Key == ConsoleKey.Escape) return "cancel";
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.WriteLine("                                                                                   ");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            } while (true);
            return characters[index];
        }

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
                    if (String.Equals(command, "EXIT"))  Console.WriteLine(" Are you sure you want to exit from program? \n Press Y - yes or 'N' - no"); 
                    else Console.WriteLine(" Are you sure? You go back to menu.\n Press 'Y' - yes or 'N' - no");

                    Console.ResetColor();
                    do
                    {
                        ConsoleKey key = Console.ReadKey().Key;
                        switch (key)
                        {
                            case ConsoleKey.Y:
                                HandleCommand(command, UI);
                                return true;
                            case ConsoleKey.N:
                                UI.DrawUI(UI, true);
                                return true;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" You didn't press the correct key. Try again.");
                                Console.ResetColor();
                                break;
                        }
                    } while (true);
                }
            }
            return false;
        }
        //Contains code to execute if provided string is a command.
        public static void HandleCommand(string command, UI UI)
        {

            switch (command)
            {
                case "EXIT":
                    UI.Exit = true;
                    break;
                case "BACK":
                    UI.Page.SwitchPage(PageType.Main_Menu, UI);
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
        public static int ThrowDice(int diceNumber, bool player)
        {
            if (player)
                {
                int powerThrow = 1;
                Console.WriteLine("Press the right arrow to increase the power of the dice throw or the left arrow to decrease the power. \nPress Enter to accept the power of the dice throw.");
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
                    valueRoll = rand.Next(1, diceNumber + 1);

                    Console.WriteLine(" Roll:" + valueRoll);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    int timeSleep = (int)Math.Pow(2, (i / powerThrow));
                    Thread.Sleep(timeSleep);
                    Console.WriteLine("                                                      ");
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                }
                Console.WriteLine(" Roll:" + valueRoll);
                return valueRoll;
            }
            else
            {
                Random rand = new Random();
               return rand.Next(1, diceNumber + 1);
            }
        }
    }
}