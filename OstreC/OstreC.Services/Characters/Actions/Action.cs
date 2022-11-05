

namespace OstreC.Services
{
    //WORK IN PROGRESS ON THIS CLASS.
    //This is supposed to be an abstract class. Dmg dices should be in hereditating classes.
    //For instance : ShortBowAttack, ShortSowrdAttack etc. But in this case deserializing it will be 
    //a nightmare.
    public abstract class EnemyActionBase
    {
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public string ActionType { get; set; }

        public int Hit_Dice { get; set; }
        public int Hit_dmg { get; set; }
        public int Flat_dmg { get; set; }

        public EnemyActionBase()
        {


        }

    }
 
    public class EnemyAction
    {


    }

 }
