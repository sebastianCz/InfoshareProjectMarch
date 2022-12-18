using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters;
using System.Net.Http.Headers;
using OstreCWEB.Services.Test;
using Newtonsoft.Json;
using OstreCWEB.Data.Repository.Items;
using OstreCWEB.Data.Enums;

namespace OstreCWEB.Services.Fight
{
    public class Fight
    { 
        private int _id = 1;
        public int PlayerActionCounter { get; set; }
        public List<string> FightHistory { get; set; }
        public static List<Enemy> _activeEnemies { get; set; } = new List<Enemy>();
        public PlayableCharacter Player { get; set; }
        public StaticLists _db { get; } = new StaticLists();

        //public Random Random { get; set; }
        public Fight()
        {
            _db = new StaticLists();
            FightHistory = new List<string>();
        }

        public void InitializeFight()
        {

            _activeEnemies = new List<Enemy>();
            Player = _db.GetPlayableCharacter(1);
            PlayerActionCounter = Player.ActionCounter;
            Player.Actions.Add(CharacterAction.ATTACK);
            Player.Actions.Add(CharacterAction.HEAL);
            GenerateEnemies(2);
            return;
        }

        public List<Character> InitializeActions(List<Character> characterList)
        {
            foreach (var character in characterList)
            {
                if (character.EquippedArmor.ActionToTrigger != null){ character.AllAvailableActions.Add(character.EquippedArmor.ActionToTrigger);} 
                if (character.EquippedWeapon.ActionToTrigger != null) { character.AllAvailableActions.Add(character.EquippedWeapon.ActionToTrigger);}
                if (character.EquippedSecondaryWeapon.ActionToTrigger != null) { character.AllAvailableActions.Add(character.EquippedSecondaryWeapon.ActionToTrigger); }
            }
            return characterList;
        }


        public void GenerateEnemies(int amountToGenerate)
        {
            for (int i = 0; i < amountToGenerate; i++)
            {
                var enemyAsText = JsonConvert.SerializeObject(
                        _db.GetEnemy(),
                    new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });

                var newEnemyInstance = JsonConvert.DeserializeObject<Enemy>(
                    enemyAsText,
                    new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });

                newEnemyInstance.InitializePossibleActions();
                _activeEnemies.Add(newEnemyInstance);
            }
        }
        public Enemy GetEnemy(int enemyPositionInList)
        {
            return _activeEnemies[enemyPositionInList];
        }
        public List<Item> GetItems()
        {
            return _db.GetItems();
        }
        public List<Enemy> GetActiveEnemies()
        {
            return _activeEnemies;
        }
        public List<CharacterActions> GetActions()
        {
            return _db.GetActions();
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