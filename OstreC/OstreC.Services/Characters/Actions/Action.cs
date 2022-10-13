using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreC.Services.Characters.Actions
{
    //This is supposed to be an abstract class. Dmg dices should be in hereditating classes.
    //For instance : ShortBowAttack, ShortSowrdAttack etc. But in this case deserializing it will be 
    //a nightmare.
    public  class Action
    {
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public string ActionType { get; set; }

        public int Hit_Dice { get; set; }
        public int Hit_dmg { get; set; }
        public int Flat_dmg { get; set; }

      
     


    }

}
