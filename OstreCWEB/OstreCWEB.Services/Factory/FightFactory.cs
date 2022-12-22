using Newtonsoft.Json;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CoreClasses;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Services.Fight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Services.Factories
{
    public class FightFactory : IFightFactory
    {
        private IFightRepository _fightRepository;
        private StaticLists _db;

        public FightFactory(IFightRepository fightRepository)
        {
            _fightRepository = fightRepository;
            _db = new StaticLists();
        }
        private PlayableCharacter BuildNewPlayerInstance(int characterId)
        {
            return GenerateNewObjectInstance<PlayableCharacter>(_db.GetPlayableCharacter(characterId));
        }
        private Enemy BuildNewEnemiesInstance()
        {
            return GenerateNewObjectInstance<Enemy>(_db.GetEnemy());
        }
        private List<Enemy> BuildActiveEnemiesList(int amountToGenerate)
        {
            var enemyList = new List<Enemy>();
            for (int i = 0; i < amountToGenerate; i++)
            {
                enemyList.Add(BuildNewEnemiesInstance());
            }
            return enemyList;
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
        public FightInstance BuildNewFightInstance()
        {
            var characterList = new List<Character>();
            var fightInstance = new FightInstance();
            fightInstance.TurnNumber = 1;
            var userId = 1;
            var playableCharacterId = 1;
            var amountToGenerate = 2;
            fightInstance.ActivePlayer = BuildNewPlayerInstance(playableCharacterId);
            fightInstance._activeEnemies = BuildActiveEnemiesList(amountToGenerate);
            fightInstance.ActivePlayer.CombatId = 1;
            for (int i = 0; i < fightInstance._activeEnemies.Count; i++)
            {
                //+2 because we have to start at 0 and player combat id by default is 1. 
                fightInstance._activeEnemies[i].CombatId = i + 2;
            }
            characterList.Add((Character)fightInstance.ActivePlayer);
            fightInstance._activeEnemies.ForEach(enemy => characterList.Add(enemy));
            InitializeActions(characterList);
            fightInstance.PlayerActionCounter = 2;
            fightInstance.FightHistory = new List<string>();
            _fightRepository.Add(userId, fightInstance, out string operationResult);
            return fightInstance;
        }
    }
}
