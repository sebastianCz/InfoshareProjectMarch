using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters;
using System.Net.Http.Headers;
using OstreCWEB.Services.Test;
using Newtonsoft.Json;
using OstreCWEB.Data.Repository.Items;
using OstreCWEB.Data.Enums;
using System;
using static System.Collections.Specialized.BitVector32;

namespace OstreCWEB.Services.Fight
{
    public class Fight : IFightService
    {
        private int _id = 1;
        public int PlayerActionCounter { get; set; }
        public static List<string> FightHistory { get; set; }
        public static List<Enemy> _activeEnemies { get; set; } = new List<Enemy>();
        public PlayableCharacter Player { get; set; }
        public StaticLists _db { get; } = new StaticLists();

        //public Random Random { get; set; }
        public Fight()
        {
            _db = new StaticLists();
            FightHistory = new List<string>();
        }

        public Character ChooseTarget(int id)
        {
            return _activeEnemies.First(a => a.ID == id);
        }

        public CharacterActions ChooseAction(int id)
        {
            return Player.AllAvailableActions.First(a => a.Id == id);
        }

        public List<string> UpdateFightHistory(List<string> FightHistory, string message)
        {
            FightHistory.Add(message);
            return FightHistory;
        }

        public void ApplyAction(Character target, Character caster, CharacterActions action)
        {

            if (action.SavingThrowPossible)
            {
                var test = DiceThrow(20); // <--- test do zdania

            }
        }

        public bool SpellSavingThrow(Character target, Character caster, CharacterActions action)
        {
            var targetMod = 0;
            var targetRoll = 0;
            var casterModifier = 0;
            switch (action.StatForTest)
            {
                case Statistics.Strenght:
                    targetMod = CalculateModifier(target.Strenght);
                    targetRoll = DiceThrow(20) + targetMod;
                    casterModifier = SpellCastingModifier(caster,action.StatForTest);
                    if (casterModifier > targetRoll) return false;
                    return true;
                case Statistics.Intelligence:
                    targetMod = CalculateModifier(target.Intelligence);
                    targetRoll = DiceThrow(20) + targetMod;
                    casterModifier = SpellCastingModifier(caster, action.StatForTest);
                    if (casterModifier > targetRoll) return false;
                    return true;
                case Statistics.Constitution:
                    targetMod = CalculateModifier(target.Constitution);
                    targetRoll = DiceThrow(20) + targetMod;
                    casterModifier = SpellCastingModifier(caster, action.StatForTest);
                    if (casterModifier > targetRoll) return false;
                    return true;
                case Statistics.Wisdom:
                    targetMod = CalculateModifier(target.Wisdom);
                    targetRoll = DiceThrow(20) + targetMod;
                    casterModifier = SpellCastingModifier(caster, action.StatForTest);
                    if (casterModifier > targetRoll) return false;
                    return true;
                case Statistics.Dexterity:
                    targetMod = CalculateModifier(target.Dexterity);
                    targetRoll = DiceThrow(20) + targetMod;
                    casterModifier = SpellCastingModifier(caster, action.StatForTest);
                    if (casterModifier > targetRoll) return false;
                    return true;
                case Statistics.Charisma:
                    targetMod = CalculateModifier(target.Charisma);
                    targetRoll = DiceThrow(20) + targetMod;
                    casterModifier = SpellCastingModifier(caster, action.StatForTest);
                    if (casterModifier > targetRoll) return false;
                    return true;
                default:
                    return false;

            }        
        }

        public int SpellCastingModifier(Character caster,Statistics statsForTest)
        {
            switch (statsForTest)
            {
                case Statistics.Strenght:
                   return 8 + CalculateModifier(caster.Strenght); // Dopisać premię z biegłości...gdy takowa powstanie.
                case Statistics.Intelligence:
                    return 8 + CalculateModifier(caster.Intelligence); // Dopisać premię z biegłości...gdy takowa powstanie.
                case Statistics.Constitution:
                    return 8 + CalculateModifier(caster.Constitution); // Dopisać premię z biegłości...gdy takowa powstanie.
                case Statistics.Wisdom:
                    return 8 + CalculateModifier(caster.Wisdom); // Dopisać premię z biegłości...gdy takowa powstanie.
                case Statistics.Dexterity:
                    return 8 + CalculateModifier(caster.Dexterity); // Dopisać premię z biegłości...gdy takowa powstanie.
                case Statistics.Charisma:
                    return 8 + CalculateModifier(caster.Charisma); // Dopisać premię z biegłości...gdy takowa powstanie.
                default:
                    return 0;
            }
        }

        //public static int TestOnDex(int modDexterity, bool player)
        //{
        //    return modDexterity + Helpers.ThrowDice(20, player);

        //}
        //public static int TestOn(int modificator, bool player, int diceNumber)
        //{
        //    return modificator + Helpers.ThrowDice(diceNumber, player);
        //}

        public int CalculateModifier(int value)
        {
            List<int> numbers = new List<int>() {
                   -5,-4,-4,-3,-3,-2,-2,-1,-1, 0,
                    0, 1, 1, 2, 2, 3, 3, 4, 4, 5,
                    5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };

            return numbers.First(x => x == numbers[value - 1]);
        }
        public int DiceThrow(int maxValue)
        {
            Random rand = new Random();
            var diceThrowResult = rand.Next(1, maxValue + 1);
            return diceThrowResult;
        }

        public void InitializeFight()
        {
            var characterList = new List<Character>();
            _activeEnemies = new List<Enemy>();
            Player = _db.GetPlayableCharacter(1);
            characterList.Add((Character)Player);
            GenerateEnemies(2);
            _activeEnemies.ForEach(Any_list => characterList.Add(Any_list));
            InitializeActions(characterList);
            PlayerActionCounter = Player.ActionCounter;
            Player.Actions.Add(CharacterAction.ATTACK);
            Player.Actions.Add(CharacterAction.HEAL);
            return;
        }

        public List<Character> InitializeActions(List<Character> characterList)
        {
            foreach (var character in characterList)
            {
                if (character.EquippedArmor.ActionToTrigger != null) { character.AllAvailableActions.Add(character.EquippedArmor.ActionToTrigger); }
                if (character.EquippedWeapon.ActionToTrigger != null) { character.AllAvailableActions.Add(character.EquippedWeapon.ActionToTrigger); }
                if (character.EquippedSecondaryWeapon.ActionToTrigger != null) { character.AllAvailableActions.Add(character.EquippedSecondaryWeapon.ActionToTrigger); }

                if (character.DefaultActions != null)
                {
                    foreach (var actions in character.DefaultActions)
                    {
                        character.AllAvailableActions.Add(actions);
                    }
                }
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