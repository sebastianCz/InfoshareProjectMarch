using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.Services.Factory;

namespace OstreCWEB.Data.Factory
{
    internal class CharacterFactory : ICharacterFactory
    {
        private OstreCWebContext _ostreCWebContext;
        public CharacterFactory(OstreCWebContext ostreCWebContext)
        {
            _ostreCWebContext = ostreCWebContext;
        }

        public  Task<PlayableCharacter> CreatePlayableCharacterInstance(PlayableCharacter template)
        {
            var newInstance = new PlayableCharacter();

            ConfigureNewInstanceProperties(template, newInstance);
            _ostreCWebContext.PlayableCharacters.Add(newInstance);
            _ostreCWebContext.SaveChanges();

            ConfigureNewInstanceAction(template, newInstance);
            ConfigureNewInstanceItems(template, newInstance);
            _ostreCWebContext.SaveChanges(); 
            return Task.FromResult(newInstance);
        }
        public Task<List<Enemy>> CreateEnemiesInstances(List<EnemyInParagraph> enemiesInParagraphs)
        {
            var generatedEnemies = new List<Enemy>();
            foreach(var creationInstructions in enemiesInParagraphs)
            {
                for(var i =0; i < creationInstructions.AmountOfEnemy;i++)
                {
                    generatedEnemies.Add(FactoryHelper.GenerateNewObjectInstance<Enemy>(creationInstructions.Enemy));
                }
            }
            return Task.FromResult(generatedEnemies);
        }
        private  Task<PlayableCharacter> ConfigureNewInstanceProperties(PlayableCharacter template, PlayableCharacter newInstance)
        { 
            newInstance.IsTemplate = false;
            newInstance.CharacterName = template.CharacterName;
            newInstance.MaxHealthPoints = template.MaxHealthPoints;
            newInstance.CurrentHealthPoints = template.CurrentHealthPoints;
            newInstance.Level = template.Level;
            newInstance.Strenght = template.Strenght;
            newInstance.Dexterity = template.Dexterity;
            newInstance.Constitution = template.Constitution;
            newInstance.Intelligence = template.Intelligence;
            newInstance.Wisdom = template.Wisdom;
            newInstance.Charisma = template.Charisma;

            newInstance.PlayableClassId = template.PlayableClassId;
            newInstance.RaceId = template.RaceId; 

            return Task.FromResult(newInstance);
        }  
        private PlayableCharacter ConfigureNewInstanceAction(PlayableCharacter template, PlayableCharacter newInstance)
        {
            if(template.LinkedActions != null)
            {
                foreach (var linkedAction in template.LinkedActions)
                {
                    newInstance.LinkedActions.Add(
                         new ActionCharacter()
                         {
                             CharacterId = newInstance.CharacterId,
                             CharacterActionId = linkedAction.CharacterActionId,
                             UsesLeftBeforeRest = linkedAction.UsesLeftBeforeRest
                         });
                }
            } 
            return newInstance;
        } 
        private PlayableCharacter ConfigureNewInstanceItems(PlayableCharacter template, PlayableCharacter newInstance)
        { 
           if(template.LinkedActions != null)
            {
                foreach (var linkedItem in template.LinkedItems)
                {
                    newInstance.LinkedItems.Add(
                        new ItemCharacter()
                        {
                            CharacterId = newInstance.CharacterId,
                            ItemId = linkedItem.ItemId,
                            IsEquipped = linkedItem.IsEquipped
                        });
                } 
            }
            
            return newInstance; 
        }
    }
}
