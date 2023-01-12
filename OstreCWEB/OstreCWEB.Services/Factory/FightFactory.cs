using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Fight;

namespace OstreCWEB.Services.Factory
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
        //I leave it here for now but this method should be deleted. The instance will be created in a different context. 
        private PlayableCharacter BuildNewPlayerInstance(int characterId)
        {
            return FactoryHelper.GenerateNewObjectInstance<PlayableCharacter>(_db.GetPlayableCharacter(characterId));
        }
        private Enemy BuildNewEnemiesInstance()
        {
            return FactoryHelper.GenerateNewObjectInstance<Enemy>(_db.GetEnemy());
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
       
        public List<Character> InitializeActions(List<Character> characterList)
        {
            foreach (var character in characterList)
            {

                character.AllAvailableActions = new List<CharacterAction>();
                if (character.EquippedArmor.ActionToTrigger != null) { 
                    character.AllAvailableActions.Add(character.EquippedArmor.ActionToTrigger); 
                }
                if (character.EquippedWeapon.ActionToTrigger != null) {
                    character.AllAvailableActions.Add(character.EquippedWeapon.ActionToTrigger); 
                }
                if (character.EquippedSecondaryWeapon.ActionToTrigger != null) { 
                    character.AllAvailableActions.Add(character.EquippedSecondaryWeapon.ActionToTrigger); 
                }

                if (character.InnateActions != null)
                {
                    foreach (var actions in character.InnateActions)
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
            fightInstance.ActiveEnemies = BuildActiveEnemiesList(amountToGenerate);
            fightInstance.ActivePlayer.CombatId = 1;
            for (int i = 0; i < fightInstance.ActiveEnemies.Count; i++)
            {
                //+2 because we have to start at 0 and player combat id by default is 1. 
                fightInstance.ActiveEnemies[i].CombatId = i + 2;
            }
            characterList.Add((Character)fightInstance.ActivePlayer);
            fightInstance.ActiveEnemies.ForEach(enemy => characterList.Add(enemy));
            InitializeActions(characterList);
            fightInstance.PlayerActionCounter = 2;
            fightInstance.FightHistory = new List<string>(); 
            return fightInstance;
        }
    }
}
