namespace OstreC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey choice;

            do
            {
                //Wprowadzenie do gry - Sebastian
                Console.WriteLine("Menu: \n");

                //Tworzenie postaci -Arek
                do
                {
                    Console.WriteLine("Tworzenie postaci: \n");
                    break;
                } while (true);

                //Wprowadznie do fabuły
                //Wybór typ paragrafu - Michał
                do
                {
                    int id;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nWitaj poszukiwaczu przygód: ..");
                    Console.ResetColor();
                    Console.WriteLine("*teks fabularny*");

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Teraz od ciebie zależy jak potoczą się dalsze losy.");
                    Console.WriteLine("Stajesz przed pierwszym wyborem, wciśnij A lub B.\n");

                    Console.WriteLine("A. {Jakiś wybór w przyszłości coś z pliku}");
                    Console.WriteLine("B. {Jakiś wybór w przyszłości coś z pliku}");
                    Console.ResetColor();
                                        
                    do
                    {
                        choice = Console.ReadKey().Key;

                        if (choice == ConsoleKey.A)
                        {
                            id = 0;
                            break;
                        }
                        else if (choice == ConsoleKey.B)
                        {
                            id = 1;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNiestety wcisnąłeś nieprawidłowy klawisz");
                            Console.ResetColor();
                            Console.WriteLine("Wciśnij A lub B, zgodnie z Twoim wyborem.");
                        }
                    } while (true);

                    switch (id)
                    {
                        case 0: //Walka - Piotr
                            Console.WriteLine("\n\nRozpoczyna się walka!");
                            Console.ReadKey();
                            break;
                        case 1: //Dialog - Tomek
                            Console.WriteLine("\n\nRozpoczyna się dialog!");
                            Console.ReadKey();
                            break;
                    }

                    Console.WriteLine("\nJeśli chcesz zakończyć aktualną przygodę wciśnij 'Y' lub cokoliwek aby kontynuować");
                    choice = Console.ReadKey().Key;
                } while (choice != ConsoleKey.Y);

                Console.WriteLine("\nJeśli chcesz zakończyć działanie konsoli wciśnij 'Y' lub cokoliwek aby kontynuować");
                choice = Console.ReadKey().Key;
            } while (choice != ConsoleKey.Y);
        }
    }
}