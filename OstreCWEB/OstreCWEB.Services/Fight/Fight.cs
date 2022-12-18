using OstreCWEB.Data;
using OstreCWEB.Data.Repository;
using OstreCWEB.Services.HardCoding;
using System.Security.Cryptography.X509Certificates;

namespace OstreCWEB.Services.Fight
{
    public class Fight
    { 


        private int _id = 1;
        public int PlayerActionCounter { get; set; }
        public List<string> FightHistory { get; set; }
        public List<Enemy> Enemies { get; set; }
        public Player Player { get; set; }

        //public Random Random { get; set; }
        public Fight()
        {
            Player = new Player();
            Enemy enemy = new Enemy();
            enemy.HealthPoints = 20;
            enemy.Name = "Ganjalf";
            enemy.ID = 1;
            Enemy enemy2 = new Enemy();
            enemy2.HealthPoints = 15;
            enemy2.Name = "Bulbo";
            enemy2.ID = 2;
            Enemies = new List<Enemy>(); 
            Enemies.Add(enemy);
            Enemies.Add(enemy2);
            PlayerActionCounter = Player.ActionCounter;
            FightHistory = new List<string>();
            Random random = new Random();
        }
        

        
        //        ProvidePossibleTargets(id ChosenAction)

        //foreach var action in Character.Actions

        //if(action.Id== ChosenAction)

        //return string[] PossibleTargets


        //Statuses most likely have to be applied in the form of " IFs" in fight script. 
        //Each character has a list of statutes applied to him. 
        //The database (or static list ) should have a list of all possible statutes applicable to characters.
        //Each spell or item used will have to search through the status list in DB and add a new status to character.Statuses 
        //If it wants to apply one. 

        //This should allow to " add" new statutes easily by just adding one to DB. Same for spells and anything else really. 

        //Alternatively each "action" can search for a specific " status" and apply it by itself. It's a bit complicated since
        //We're talking about establishing relationships between instances that don't exist yet. 
    }
}