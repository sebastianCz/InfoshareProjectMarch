using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OstreC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var player = new PlayerCreator()
            {
                Name = "Michał",
                Level = 1,
                HealthPoints = 100,
                Statisctics = new List<Statistics>()
                {
                    new Statistics()
                    {
                        Name = "Strength",
                        Points = 10,
                    },
                    new Statistics()
                    {
                        Name = "Intelligence",
                        Points = 10,
                    }
                }
            };

            player.Level++;

            string playerSerialized = JsonConvert.SerializeObject(player);

            Console.WriteLine(playerSerialized);

            var currentDirectory = Directory.GetCurrentDirectory();
            var playerSerializedPath = Path.Combine(currentDirectory, "data", "data", "player.json");
            var racesSerializedPath = Path.Combine(currentDirectory, "data", "data", "races.json");

            //Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "data"));

            //File.WriteAllText(Path.Combine(dataDirectory, "playerSerialized.json"), "");

            //Console.WriteLine(Directory.GetCurrentDirectory());

            //File.WriteAllText(playerSerializedPath, playerSerialized); //- plik do json

            string racesSerialized = File.ReadAllText(racesSerializedPath); // - odczytanie pliku json

            PlayerCreator player2 = JsonConvert.DeserializeObject<PlayerCreator>(playerSerialized);

            Console.WriteLine(player2.Statisctics[0].Name);

            RacesList races = JsonConvert.DeserializeObject<RacesList>(racesSerialized);

            Console.WriteLine(races.Results[3].Name);
            foreach (var asi in races.Results[3].Asi)
            {
                foreach (var asi2 in asi.Attributes)
                {
                    Console.WriteLine(asi2);
                    Console.WriteLine(asi.Value);
                }
            }
        }
    }
}