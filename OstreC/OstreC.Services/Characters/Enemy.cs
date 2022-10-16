using System;


namespace OstreC.Services
{
    public class Enemy : Character
    {

        public string Size { get; set; }// Size of the creature. Relevant for spells. 
        public string Type { get; set; } // Abberation, Animal, etc. Usefull if we implement spells in 2nd sprint. 
        
        public string Alignment { get; set; }// Evil, neutral, neutral evil. Maybe we can use it in paragraphs at some point. 
        public int Armor_Class { get; set; }//Int from 1 to 20 specifying the armor "level".
        public string Armor_Desc { get; set; }//natural armor, heavy armor etc

        //Players also use hit dices but they might be calculated on items if we implement it later. 
        //Meanwhile enemies can be simplified and have those values hardcoded.  

        //public int Dmg_Dice { get; set; } //Amount of dmg dices thrown to calculate dmg 
        //public int Dmg_Dice_Max { get; set; }//Max value of dmg dice. Usually 6 for lesser creatures
        //public int Flat_Dmg { get; set; } //Flat dmg bonus

        //public List<EnemyAction> EnemyActions { get; set; }
        public List<EnemyAction> EnemyActions { get; } = new List<EnemyAction>();
    }
}
