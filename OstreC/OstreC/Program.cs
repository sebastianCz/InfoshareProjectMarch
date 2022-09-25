using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OstreC.Paragraph;

namespace OstreC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var listParagraphSerializedPath = Path.Combine(currentDirectory, "data", "dataJson", "listParagraph.json");

            string listParagraphSerialize = File.ReadAllText(listParagraphSerializedPath);

            ListParagraph Paragraph = JsonConvert.DeserializeObject<ListParagraph>(listParagraphSerialize);

            int idParagraph = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Paragraph.Paragraph[idParagraph].TextParagraph);
                Console.ResetColor();

                idParagraph = ChoiceParagraph.NextParagraph(Paragraph.Paragraph[idParagraph].HowManyOptions, Paragraph.Paragraph[idParagraph].NextParagraph);

            } while (idParagraph != 0);
        }
    }
}
        //{
        //    var player = new PlayerCreator()
        //    {
        //        Name = "Michał",
        //        Level = 1,
        //        HealthPoints = 100,
        //        Statisctics = new List<Statistics>()
        //        {
        //            new Statistics()
        //            {
        //                Name = "Strength",
        //                Points = 10,
        //            },
        //            new Statistics()
        //            {
        //                Name = "Intelligence",
        //                Points = 10,
        //            }
        //        }
        //    };

        //    player.Level++;

        //    string playerSerialized = JsonConvert.SerializeObject(player);

        //    Console.WriteLine(playerSerialized);

        //    var currentDirectory = Directory.GetCurrentDirectory();
        //    var playerSerializedPath = Path.Combine(currentDirectory, "data", "dataJson", "player.json");
        //    var racesSerializedPath = Path.Combine(currentDirectory, "data", "dataJson", "races.json");

        //    //Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "data"));

        //    //File.WriteAllText(Path.Combine(dataDirectory, "playerSerialized.json"), "");

        //    //Console.WriteLine(Directory.GetCurrentDirectory());

        //    //File.WriteAllText(playerSerializedPath, playerSerialized); //- plik do json

        //    string racesSerialized = File.ReadAllText(racesSerializedPath); // - odczytanie pliku json

        //    PlayerCreator player2 = JsonConvert.DeserializeObject<PlayerCreator>(playerSerialized);

        //    Console.WriteLine(player2.Statisctics[0].Name);

        //    RacesList races = JsonConvert.DeserializeObject<RacesList>(racesSerialized);

            
        //    Console.ForegroundColor = ConsoleColor.DarkGreen;
        //    Console.WriteLine("\n\nChoise your race: ");
        //    Console.ResetColor();

        //    int idRace = -1;
        //    foreach (var race in races.Results)
        //    {
        //        idRace += 1;
        //        Console.Write($"{idRace}. ");
        //        Console.ForegroundColor = ConsoleColor.Magenta;
        //        Console.WriteLine(race.Name);
        //        Console.ResetColor();
        //        Console.WriteLine(race.Desc);
        //        Console.WriteLine(race.Asi_desc);
        //        Console.WriteLine(race.Speed_desc);
        //    }
            
        //    switch (Console.ReadKey().Key)
        //    {
        //        case ConsoleKey.D0:
        //        case ConsoleKey.NumPad0:
        //            idRace = 0;
        //            break;
        //        case ConsoleKey.D1:
        //        case ConsoleKey.NumPad1:
        //            idRace = 1;
        //            break;
        //        case ConsoleKey.D2:
        //        case ConsoleKey.NumPad2:
        //            idRace = 2;
        //            break;
        //        case ConsoleKey.D3:
        //        case ConsoleKey.NumPad3:
        //            idRace = 3;
        //            break;
        //        case ConsoleKey.D4:
        //        case ConsoleKey.NumPad4:
        //            idRace = 4;
        //            break;
        //        case ConsoleKey.D5:
        //        case ConsoleKey.NumPad5:
        //            idRace = 5;
        //            break;
        //        case ConsoleKey.D6:
        //        case ConsoleKey.NumPad6:
        //            idRace = 6;
        //            break;
        //        case ConsoleKey.D7:
        //        case ConsoleKey.NumPad7:
        //            idRace = 7;
        //            break;
        //        case ConsoleKey.D8:
        //        case ConsoleKey.NumPad8:
        //            idRace = 7;
        //            break;
        //        default:
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("Error, try again");
        //            Console.ResetColor();
        //            break;
        //    }

        //    Console.ForegroundColor = ConsoleColor.Magenta;
        //    Console.WriteLine($"\n\nYour choice: {races.Results[idRace].Name}");
        //    Console.ResetColor();
        //    Console.WriteLine("Bonus to your Attributes");
            

        //    Console.ForegroundColor = ConsoleColor.Green;
        //    foreach (var asi in races.Results[idRace].Asi)
        //    {
        //        foreach (var asi2 in asi.Attributes)
        //        {
        //            Console.Write(asi2);
        //            Console.WriteLine($" +{asi.Value}");
        //        }
        //    }
        //    Console.ResetColor();
        //}
