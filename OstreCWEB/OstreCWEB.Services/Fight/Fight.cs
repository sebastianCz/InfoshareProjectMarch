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

namespace OstreCWEB.Services.Fight
{
    public class Fight : IFightService
    {
        private int _id = 1;
        public int PlayerActionCounter { get; set; }
        public static List<string> FightHistory { get; set; }
        public static List<Enemy> _activeEnemies { get; set; } = new List<Enemy>();
        public static PlayableCharacter ActivePlayer { get; set; }
        public StaticLists _db { get; } = new StaticLists();
        public static CharacterActions ActiveAction { get; set; }
        public static Character ActiveTarget { get; set; }

        public Fight()
        {
            _db = new StaticLists();
            FightHistory = new List<string>();
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
            return _activeEnemies.First(a => a.ID == id);
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
                    FightHistory = UpdateFightHistory(FightHistory, $" {target.CharacterName} lost {damage} healthpoints, actual healthpoints {target.HealthPoints}, due to {caster.CharacterName} {action.ActionName}");
                }
                else
                {
                    damage = ApplyDamage(caster, action, savingThrow);
                    ApplyStatus(target, action.Status);
                    FightHistory = UpdateFightHistory(FightHistory, $" {target.CharacterName} lost {damage} healthpoints, actual healthpoints {target.HealthPoints}, due to {caster.CharacterName} {action.ActionName}, ");
                }
            }
            else
            {
                var damage = 0;
                var savingThrow = false;
                ApplyStatus(target, action.Status);
                damage = ApplyDamage(target, action, savingThrow);
                    FightHistory = UpdateFightHistory(FightHistory, $" {target.CharacterName} lost {damage} healthpoints, actual healthpoints {target.HealthPoints}, due to {caster.CharacterName} {action.ActionName}");
            }
        }

        public void ApplyStatus(Character character,Status status)
        {
            character.ActiveStatuses.Add(status);
        }

        public int ApplyDamage(Character target,CharacterActions actions, bool savingThrow)
        { 
            var damage = 0;

            for (int i = 0; i < actions.Hit_Dice_Nr; i++)
            {
            damage += DiceThrow(actions.Max_Dmg) + actions.Flat_Dmg;
            }
            if (savingThrow)
            {
                target.HealthPoints = target.HealthPoints - (damage/2);
            }
            else
            { 
                target.HealthPoints = target.HealthPoints - damage;
            }
                return damage;
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
            ActivePlayer = _db.GetPlayableCharacter(1);
            characterList.Add((Character)ActivePlayer);
            GenerateEnemies(2);
            _activeEnemies.ForEach(Any_list => characterList.Add(Any_list));
            InitializeActions(characterList);
            PlayerActionCounter = ActivePlayer.ActionCounter;
            ActivePlayer.Actions.Add(CharacterAction.ATTACK);
            ActivePlayer.Actions.Add(CharacterAction.HEAL);
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
    }
}