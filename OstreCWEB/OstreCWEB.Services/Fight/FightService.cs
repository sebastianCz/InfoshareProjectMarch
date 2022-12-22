using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters;
using System.Net.Http.Headers;
using OstreCWEB.Services.Test;
using Newtonsoft.Json;
using OstreCWEB.Data.Repository.Items;
using OstreCWEB.Data.Enums;
using System;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;

namespace OstreCWEB.Services.Fight
{
    public class FightService : IFightService
    {
        private int _id = 1;
        public int PlayerActionCounter { get; set; }
        public static List<string> FightHistory { get; set; }
        public static List<Enemy> _activeEnemies { get; set; } = new List<Enemy>();
        public static PlayableCharacter ActivePlayer { get; set; }
        public StaticLists _db { get; } = new StaticLists();
        public static CharacterActions ActiveAction { get; set; }
        public static Character ActiveTarget { get; set; }

        public FightService()
        {
            _db = new StaticLists();
            FightHistory = new List<string>();
        }

        public void CommitRound()
        {
            ApplyAction(ActiveTarget,ActivePlayer,ActiveAction);
        }

        public Character GetActiveTarget()
        {
            return ActiveTarget;
        }

        public CharacterActions GetActiveActions()
        {
            return ActiveAction;
        }

        public void UpdateActiveAction(CharacterActions action)
        {
           ActiveAction = action;
        }


        public void UpdateActiveTarget(Character character)
        {
            ActiveTarget = character;
        }

        public PlayableCharacter GetPlayer()
        {
            return ActivePlayer;
        }

        public List<string> ReturnHistory()
        {
            return FightHistory;
        }

        public Character ChooseTarget(int id)
        {
            if (id == ActivePlayer.CombatId)
            {
                return ActivePlayer;
            }
            return _activeEnemies.First(a => a.CombatId == id);
        }
        public Character ResetActiveTarget() 
        {
            //We  create playable character instance and replace the active target with null values. Character class is abstract.   
            ActiveTarget = new PlayableCharacter();
            return ActiveTarget;
        }

        public CharacterActions ChooseAction(int id)
        {
            return ActivePlayer.AllAvailableActions.First(a => a.Id == id);
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
                var damage = 0;
                var savingThrow = SpellSavingThrow(target, caster, action);
                if (savingThrow == false)
                {
                    damage = ApplyDamage(target, action, savingThrow);

                    FightHistory = UpdateFightHistory(FightHistory,
                        $" {target.CharacterName} lost {damage} healthpoints, current healthpoints {target.HealthPoints}," +
                        $" due to {caster.CharacterName} using {action.ActionName}");
                }
                else
                {
                    damage = ApplyDamage(caster, action, savingThrow);
                    ApplyStatus(target, action.Status);

                    FightHistory = UpdateFightHistory(FightHistory,
                        $" {target.CharacterName} lost {damage} healthpoints, current healthpoints {target.HealthPoints}, " +
                        $"due to {caster.CharacterName} using {action.ActionName}, ");
                }
            }
            else
            { 
                var savingThrow = false;
                if (action.Status != null) { ApplyStatus(target, action.Status); }

                if (action.AggressiveAction) {
                    var damage = ApplyDamage(target, action, savingThrow);

                    FightHistory = UpdateFightHistory(FightHistory,
                        $" {target.CharacterName} lost {damage} healthpoints, current healthpoints {target.HealthPoints}," +
                        $" due to {caster.CharacterName}  using {action.ActionName}");
                }
                else
                {
                    var heal = ApplyHeal(target, action, savingThrow);
                    FightHistory = UpdateFightHistory(FightHistory,
                        $" {target.CharacterName} gained {heal} healthpoints, current healthpoints {target.HealthPoints}," +
                        $" due to {caster.CharacterName}  using {action.ActionName}");
                }
                
               
                   
            }
        }

        public void ApplyStatus(Character character,Status status)
        {
            if(status != null)
            {
                character.ActiveStatuses.Add(status);
            } 
        }

        public int ApplyDamage(Character target,CharacterActions actions, bool savingThrow)
        { 
            var updateValue = 0;

            for (int i = 0; i < actions.Hit_Dice_Nr; i++)
            {
                updateValue += DiceThrow(actions.Max_Dmg) + actions.Flat_Dmg;
            }
            if (savingThrow)
            {
                target.HealthPoints = target.HealthPoints - (updateValue / 2);
            }
            else
            { 
                target.HealthPoints = target.HealthPoints - updateValue;
            }
                return updateValue;
        }
        public int ApplyHeal(Character target, CharacterActions actions, bool savingThrow)
        {
            var updateValue = 0;

            for (int i = 0; i < actions.Hit_Dice_Nr; i++)
            {
                updateValue += DiceThrow(actions.Max_Dmg) + actions.Flat_Dmg;
            }
            if (savingThrow)
            {
                target.HealthPoints = target.HealthPoints + (updateValue / 2);
            }
            else
            {
                target.HealthPoints = target.HealthPoints + updateValue;
            }
            return updateValue;
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
            //Generates instances of each entity
            var player = _db.GetPlayableCharacter(1); 
            ActivePlayer = GenerateNewObjectInstance<PlayableCharacter>(player);
            _activeEnemies = GenerateEnemies(2);

            //Generates combat ID
            ActivePlayer.CombatId = 1;
            for (int i = 0; i < _activeEnemies.Count; i++)
            {
                //+2 because we have to start at 0 and player combat id by default is 1. 
                _activeEnemies[i].CombatId = i+ 2; 
            }

            //Prepares object for action init
            characterList.Add((Character)ActivePlayer);
            _activeEnemies.ForEach(enemy => characterList.Add(enemy));
            InitializeActions(characterList);

            PlayerActionCounter = ActivePlayer.ActionCounter;
            return;
        }

        public List<Character> InitializeActions(List<Character> characterList)
        {
            foreach (var character in characterList)
            {
                character.AllAvailableActions = new List<CharacterActions>();
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
 

        internal T GenerateNewObjectInstance<T>(T objectInstance)
        {
            var objectAsText = JsonConvert.SerializeObject(
                         objectInstance,
                     new JsonSerializerSettings()
                     {
                         TypeNameHandling = TypeNameHandling.Auto
                     });

            var newObjectInstance = JsonConvert.DeserializeObject<T>(
                objectAsText,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
            return newObjectInstance;

        }

        public List<Enemy> GenerateEnemies(int amountToGenerate)
        {
            var enemyList = new List<Enemy>();
            for (int i = 0; i < amountToGenerate; i++)
            { 
                enemyList.Add(GenerateNewObjectInstance<Enemy>(_db.GetEnemy())); 
            }
            return enemyList;
        }
        public Enemy GetEnemyByListPosition(int enemyPositionInList)
        {
            return _activeEnemies[enemyPositionInList];
        }
        /// <summary>
        /// Determines if target is a player or an enemy
        /// </summary>
        /// <param name="combatId"></param>
        /// <returns>Combat instance of given target as Character</returns>

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
    }
}