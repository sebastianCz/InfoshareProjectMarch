using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Paragraph
{
    internal class ChoiceParagraph
    {
        public static int NextParagraph(int count, List<NextParagraph> listChoice)
        {
            int i = 1;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach(var item in listChoice)
            {
                Console.Write($"Press {i} on the keyboard to: ");
                Console.WriteLine(item.ChoiceText);
                i++;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press ESC on the keyboard to back to menu.");
            Console.ResetColor();

            do
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (count == 1)
                {
                    switch (key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            return listChoice[0].IdParagraph;
                        case ConsoleKey.Escape:                       
                            return 0;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nieznana opcja, wybierz ponownie.");
                            Console.ResetColor();
                            break;
                    }
                }
                else if (count == 2)
                {
                    switch (key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            return listChoice[0].IdParagraph;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            return listChoice[1].IdParagraph;
                        case ConsoleKey.Escape:
                            return 0;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nieznana opcja, wybierz ponownie.");
                            Console.ResetColor();
                            break;
                    }
                }
                else if (count == 3)
                {
                    switch (key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            return listChoice[0].IdParagraph;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            return listChoice[1].IdParagraph;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            return listChoice[2].IdParagraph;
                        case ConsoleKey.Escape:
                            return 0;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nieznana opcja, wybierz ponownie.");
                            Console.ResetColor();
                            break;
                    }
                }
            } while (true);
        }
    }
}
