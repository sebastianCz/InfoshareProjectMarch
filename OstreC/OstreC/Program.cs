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

            //File.WriteAllText(@"ścieżka", playerSerialized) - plik do json

            //string playerDeserialize = File.ReadAllText(@"ścieżka"); - odczytanie pliku json

            PlayerCreator player2 = JsonConvert.DeserializeObject<PlayerCreator>(playerSerialized);

            Console.WriteLine(player2.Name);

            RacesList races = JsonConvert.DeserializeObject<RacesList>(DataJason.Races());

            Console.WriteLine(races.Count);

        }
    }
}