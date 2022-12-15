using OstreCWEB.Data.Repository.Items;
using System.Text.Json.Serialization;

namespace OstreCWEB.Data.Repository.Characters

{
    public class Enemy : Character
    {
        public string Race { get; set; }
        //It's essentially the name of the enemy. I'm assuming enemies will have a different set of methods that's why this class exists. 
        //public Enemy(int id, string characterName, string race, int healtPoints, int level, string alignment, Item equippedArmor, Item equippedWeapon,
        //    Item equippedSecondaryWeapon, Item[] items, int strenght, int modStrenght, int dexterity, int modDexterity, int constitution,
        //    int modConstitution, int intelligence, int modIntelligence, int wisdom, int modWisdom, int charisma, int modCharisma)
        //    : base(id, characterName, race, healtPoints, level, alignment, equippedArmor, equippedWeapon, equippedSecondaryWeapon,
        //          items, strenght, modStrenght, dexterity, modDexterity, constitution, modConstitution, intelligence, modIntelligence,
        //          wisdom, modWisdom, charisma, modCharisma)
        //{
        [JsonConstructor]
        public Enemy() { }
        }
    }

