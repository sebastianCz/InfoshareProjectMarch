using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstreC.Services;
using static System.Net.Mime.MediaTypeNames;

namespace OstreC.Services
{
    public class CurrentPlayer : Player
    {
        int userIdKey = 0; //Allows to link player instance to user. When character is created this INT should be assigned as follows:
        //userIdKey = CurrentPlayer.Id;
        //This way I will be able to link multiple characters to one user. 

    public  int Hit_Dice_Nr { get; set; }// Amount of dices used to attack.
    public int Hit_Dmg { get; set; } // dmg per hit dice.
    public int Flat_damage { get; set; } // dmg added to hit dice result regardless of roll.
   // public List PlayerItems = new List(); //player inventory  LIST with ITEMS
     public bool isAlive { get; set; } 



    }
}
