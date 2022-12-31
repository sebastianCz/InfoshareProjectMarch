using OstreCWEB.Data.Repository.Characters.Enums;
using System.Text.Json.Serialization;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels

{
    public class Enemy : Character
    {
        public Races NonPlayableRace { get; set; }

        [JsonConstructor]
        public Enemy() { }
         
    }


}

