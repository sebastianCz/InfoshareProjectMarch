using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OstreC.Services
{
    public class CharactersCompare
    {
        public int Armor_class { get; set; }
        public int Charisma { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Level { get; set; }
        public int Strenght { get; set; }

        public class Program
        {
            public static void Main()
            {
                string fileName = "Enemy.json";
                string jsonString = File.ReadAllText(fileName);

            }
            // Root myDeserializedClass = JsonConvert.DeserializeObject(myJsonResponse);


        }


    }
    //internal class CharactersCompare
    //{
    //    public static JsonConvert
            
            
    //    public bool Compare(Character character1, Character character2)
    //    {
    //        var character1Points = 0;
    //        var character2Points = 0;
    //        if (character1.Strength > character2.Strength)
    //        {
    //            character1Points += 1;
    //        }
    //        else
    //        {
    //            character1Points += 0;
    //        }
    //         return character1Points >= character2Points;
    //    }
        
    //}


}
