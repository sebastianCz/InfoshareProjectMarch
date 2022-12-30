﻿using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels
{
    public abstract class Character
    {
        //Ef Config
        [Key]
        public int CharacterId { get; set; }
        public List<ActionCharacter>? LinkedActions{get;set;}
        public List<ItemCharacter>? ItemCharacter { get; set; }

        //This is required because Characters IDs can be the same as enemies...Combat needs to generate it's own IDs
        //This is not saved to data base.
        public List<CharacterAction>? DefaultActions { get; set; }
        [NotMapped]
        public List<CharacterAction> AllAvailableActions { get; set; }
        [NotMapped]
        public List<Status> ActiveStatuses { get; set; }


        [NotMapped]
        public int CombatId { get; set; } 
        public string CharacterName { get; set; } 
        public int MaxHealthPoints { get; set; } 
        public int CurrentHealthPoints { get; set; } 
        public int Level { get; set; }
        [NotMapped]
        public Item EquippedArmor { get; set; }
        [NotMapped]
        public Item EquippedWeapon { get; set; }
        [NotMapped]
        public Item EquippedSecondaryWeapon { get; set; }
        [NotMapped]  
        
        public Item[] Inventory { get; set; }
        //Actions granted on level 1 based on class+race+ user choices.




        public int Strenght { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; } 
        [JsonConstructor]
        public Character()
        {

        }
    }

    //public Character(int id,string characterName,string race,int healtPoints,int level,string alignment,Item equippedArmor,Item equippedWeapon,
    //    Item equippedSecondaryWeapon, Item[] items,int strenght,int modStrenght,int dexterity,int modDexterity,int constitution,int modConstitution,
    //    int intelligence,int modIntelligence,int wisdom,int modWisdom,int charisma,int modCharisma)

    //{
    //    ID = id;
    //    CharacterName = characterName;
    //    Race = race;
    //    HealthPoints = healtPoints;
    //    Level = level;
    //    Alignment = alignment;
    //    EquippedArmor = (Armor)equippedArmor;
    //    EquippedWeapon = (Weapon)equippedWeapon;
    //    EquippedSecondaryWeapon = equippedSecondaryWeapon;
    //    Inventory = items;
    //    Strenght = strenght;
    //    ModStrenght = modStrenght;
    //    Dexterity = dexterity;
    //    ModDexterity = modDexterity;
    //    Constitution = constitution;
    //    ModConstitution = modConstitution; 
    //    Intelligence = intelligence;
    //    ModIntelligence = modIntelligence;
    //    Wisdom = wisdom;
    //    ModWisdom = modWisdom;
    //    Charisma = charisma;
    //    ModCharisma = charisma;
    //}
}

