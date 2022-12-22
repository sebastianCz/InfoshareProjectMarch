using OstreCWEB.Data.Enums;
using OstreCWEB.Data.Repository;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Data.Repository.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Fight
{
    public interface IFightService
    {
        public Character ChooseTarget(int id);
        public CharacterActions ChooseAction(int id);
        public void InitializeFight();
        public List<Character> InitializeActions(List<Character> characterList);
        public List<Enemy> GenerateEnemies(int amountToGenerate);
        public Enemy GetEnemyByListPosition(int enemyPositionInList);
        public List<Item> GetItems();
        public List<Enemy> GetActiveEnemies();
        public List<CharacterActions> GetActions();
        public void UpdateActiveAction(CharacterActions action);
        public void UpdateActiveTarget(Character character);
        public PlayableCharacter GetPlayer();
        public List<string> ReturnHistory();
        public CharacterActions GetActiveActions();
        public Character GetActiveTarget();
        public Character ResetActiveTarget();
        public void ApplyAction(Character target, Character caster, CharacterActions action);
        public void CommitRound();
    }
}