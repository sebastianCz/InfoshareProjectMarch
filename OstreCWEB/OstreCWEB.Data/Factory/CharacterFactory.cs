using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json.Linq;
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
        private readonly IMapper _mapper;

        public CharacterFactory(OstreCWebContext ostreCWebContext,IMapper mapper)
        {
            _ostreCWebContext = ostreCWebContext;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
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
                {//todo://Define newinstance configuration
                    var newInstance = new Enemy();
                    ConfigureNewInstanceProperties(creationInstructions.Enemy, newInstance);
                    ConfigureNewInstanceAction(creationInstructions.Enemy, newInstance);
                    ConfigureNewInstanceItems(creationInstructions.Enemy, newInstance);

                    generatedEnemies.Add(newInstance);
                }
            }
            return Task.FromResult(generatedEnemies);
        }
        
        private Task<Enemy> ConfigureNewInstanceProperties(Enemy template,Enemy newInstance)
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
            newInstance.NonPlayableRace = template.NonPlayableRace;
            return Task.FromResult(newInstance);
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
        private Character ConfigureNewInstanceAction(Character template,Character newInstance)
        {
            if(template.LinkedActions != null)
            {
                foreach (var linkedAction in template.LinkedActions)
                {
                    newInstance.LinkedActions.Add(
                         new ActionCharacter()
                         {
                             CharacterId = newInstance.CharacterId,
                             Character =newInstance,
                             CharacterAction = linkedAction.CharacterAction,
                             CharacterActionId = linkedAction.CharacterActionId,
                             UsesLeftBeforeRest = linkedAction.UsesLeftBeforeRest
                         });
                }
            } 
            return newInstance;
        } 
        private Character ConfigureNewInstanceItems(Character template, Character newInstance)
        { 
           if(template.LinkedActions != null)
            {
                foreach (var linkedItem in template.LinkedItems)
                {
                    newInstance.LinkedItems.Add(
                        new ItemCharacter()
                        {
                            CharacterId = template.CharacterId,
                            Character = template,
                            Item = linkedItem.Item,
                            ItemId = linkedItem.ItemId,
                            IsEquipped = linkedItem.IsEquipped
                        });
                } 
            } 
            return newInstance; 
        }
    }
}
