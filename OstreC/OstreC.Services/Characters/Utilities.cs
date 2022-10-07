using System.Text.RegularExpressions;

namespace OstreC.Services.Characters
{
    internal class Utilities
    {
        public static Regex rgxAZ = new Regex("[^a-zA-Z]");
        public static Regex rgxAZ09 = new Regex("[^a-zA-Z0-9]");
        public static bool isGarageCreated = false;
        public static string InputDataAsString()
        {
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && input.Length <= 100)
            {
                return input;
            }
            else
            {
                Console.WriteLine("Podano niepoprawną wartość. Proszę sprobować raz jeszcze");
            }
            return input;
        }
        public static string InputDataAsString(int valueSwitch = 1)
        {
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && input.Length <= 100)
            {
                return input;
            }
            else
            {
                switch (valueSwitch)
                {
                    case 1:
                        Console.WriteLine("Podano niepoprawną wartość. Proszę sprobować raz jeszcze");
                        break;
                    default:
                        Console.WriteLine("Podano niepoprawną wartość. Proszę sprobować raz jeszcze");
                        break;
                }
                return InputDataAsString(valueSwitch);
            }
        }
        public static string InputDataAsString(Regex rgx, int valueSwitch = 1)
        {
            string input = Console.ReadLine();
            bool isString = rgx.IsMatch(input);
            if (!isString && !string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                switch (valueSwitch)
                {
                    case 1:
                        Console.WriteLine("Podano niepoprawną wartość. Proszę sprobować raz jeszcze");
                        break;
                    default:
                        Console.WriteLine("Podano niepoprawną wartość. Proszę sprobować raz jeszcze");
                        break;
                }
                return InputDataAsString(rgx, valueSwitch);
            }
        }
        ///<summary>Get Data as int input with validation </summary>
        public static int InputDataAsInt(int minValue, int maxValue, int valueSwitch)
        {
            int number;

            string input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Niepoprawny format danych, proszę spróbować raz jeszcze");
                return InputDataAsInt(minValue, maxValue, valueSwitch);
            }
            else if ((number < minValue || number > maxValue))
            {
                switch (valueSwitch)
                {
                    case 1:
                        Console.WriteLine($"Podano niepoprawną wartość, proszę spróbować raz jeszcze. Prawidłowy przedział jest od {minValue} do {maxValue}");
                        break;
                    default:
                        Console.WriteLine("Podano niepoprawną wartość");
                        break;
                }
                return InputDataAsInt(minValue, maxValue, valueSwitch);
            }
            else
            {
                return number;
            }
        }
        public static void WriteColorText(string textColored, ConsoleColor firstColor = ConsoleColor.DarkGreen, bool isConsoleCleared = false)
        {
            if (isConsoleCleared)
            {
                Console.Clear();
            }
            Console.ForegroundColor = firstColor;
            Console.Write(textColored);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteColorText(string text, string textColored, ConsoleColor firstColor = ConsoleColor.White, ConsoleColor secondColor = ConsoleColor.DarkGreen, bool isConsoleCleared = false, int multiplierTab = 0)
        {
            string tabs = new string('\t', multiplierTab);
            if (isConsoleCleared)
            {
                Console.Clear();
            }
            Console.ForegroundColor = firstColor;
            Console.Write(text);
            Console.Write(tabs);
            Console.ForegroundColor = secondColor;
            Console.Write(textColored);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLineColorText(string textColored, ConsoleColor firstColor = ConsoleColor.DarkGreen, bool consoleClear = false)
        {
            if (consoleClear)
            {
                Console.Clear();
            }
            Console.ForegroundColor = firstColor;
            Console.WriteLine(textColored);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLineColorText(string text, string textColored, ConsoleColor firstColor = ConsoleColor.White, ConsoleColor secondColor = ConsoleColor.DarkGreen, bool isConsoleCleared = false, int multiplierTab = 0)
        {
            string tabs = new string('\t', multiplierTab);
            if (isConsoleCleared)
            {
                Console.Clear();
            }
            Console.ForegroundColor = firstColor;
            Console.Write(text);
            Console.Write(tabs);
            Console.ForegroundColor = secondColor;
            Console.WriteLine(textColored);
            Console.ForegroundColor = ConsoleColor.White;


        }
        public static void Underline(char symbol = '=', int value = 10)
        {
            string underline = new string(symbol, value);
            Console.WriteLine(underline);
        }
        public static void PressAnyKey(bool pressKey = true)
        {
            Utilities.WriteColorText("Press any key to continue", ConsoleColor.White);
            if (pressKey)
                Console.ReadKey();
        }

        public static int DiceRoll(int value)
        {
            Random rand = new Random();
            int valueRoll = rand.Next(1,value);
            return valueRoll;
        }
    }
}
