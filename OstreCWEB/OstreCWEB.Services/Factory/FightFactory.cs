using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Data.Repository.Identity;

namespace OstreCWEB.Services.Factory
{
    internal class FightFactory : IFightFactory
    {
        private IFightRepository _fightRepository; 

        public FightFactory(IFightRepository fightRepository)
        {
            _fightRepository = fightRepository; 
        }
        //I leave it here for now but this method should be deleted. The instance will be created in a different context. 
      
       
        public List<Character> InitializeActions(List<Character> characterList)
        {
            foreach (var character in characterList)
            {
                character.AllAvailableActions = new List<CharacterAction>();
                if (character.EquippedArmor.ActionToTrigger != null) { character.AllAvailableActions.Add(character.EquippedArmor.ActionToTrigger); }
                if (character.EquippedWeapon.ActionToTrigger != null) { character.AllAvailableActions.Add(character.EquippedWeapon.ActionToTrigger); }
                if (character.EquippedSecondaryWeapon.ActionToTrigger != null) { character.AllAvailableActions.Add(character.EquippedSecondaryWeapon.ActionToTrigger); }

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
        public FightInstance BuildNewFightInstance(UserParagraph gameInstance,List<Enemy> enemiesList)
        {
            var characterList = new List<Character>();
            var fightInstance = new FightInstance();
            fightInstance.TurnNumber = 1;  
            fightInstance.ActivePlayer = gameInstance.ActiveCharacter;
            fightInstance.ActiveEnemies = enemiesList;
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
