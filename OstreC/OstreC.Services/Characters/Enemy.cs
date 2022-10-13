using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstreC.Services;
namespace OstreC.Services
{
    internal class Enemy : Character
    {
        
        internal string Size { get; set; }// Size of the creature. Relevant for spells. 
        internal string Type { get; set; } // Abberation, Animal, etc. Usefull if we implement spells in 2nd sprint. 
        internal string Alignment { get; set; }// Evil, neutral, neutral evil. Maybe we can use it in paragraphs at some point. 
        
        internal int Armor_Desc {get;set;}//natural armor, heavy armor etc

        //Players also use hit dices but they might be calculated on items if we implement it later. 
        //Meanwhile enemies can be simplified and have those values hardcoded.  
        internal int Armor_Class { get; set; }//Int from 1 to 20 specifying the armor "level".
        internal int Dmg_Dice { get; set; } //Amount of dmg dices thrown to calculate dmg 
      internal int Dmg_Dice_Max { get; set; }//Max value of dmg dice. Usually 6 for lesser creatures
      internal int Flat_Dmg { get; set; } //Flat dmg bonus
    }
}
