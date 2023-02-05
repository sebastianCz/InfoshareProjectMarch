using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using System.Text.Json.Serialization;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels

{
    public class Enemy : Character
    {
        public Races NonPlayableRace { get; set; }

        public List<EnemyInParagraph> EnemyInParagraphs { get; set; }

        [JsonConstructor]
        public Enemy() { } 
    } 
}

