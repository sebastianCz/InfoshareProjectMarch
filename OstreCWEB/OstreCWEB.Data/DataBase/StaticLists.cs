using OstreCWEB.Data.Repository.Items;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Data.Enums;
using System;

namespace OstreCWEB.Data.DataBase
{
    public class StaticLists
    {
        private static List<Enemy> Enemies = new List<Enemy>();
        private static List<Item> Items = new List<Item>();
        private static List<CharacterActions> Actions = new List<CharacterActions>();
        public StaticLists()
        {
        }

        public void SeedData()
        {
            Actions = new List<CharacterActions>
            {
                 new CharacterActions
            {
                Id = 1,
                ActionName = "Short Sword Attack",
                ActionDescription = "Strikes the chosen character with your weapon",
                ActionType = CharacterActionType.MeleeAttack,
                HitRollRequired = true,
                Hit_Dmg = 6,
                Flat_Dmg = 1,
                Hit_Dice_Nr = 1,
                PossibleTargets = "enemy",
                InflictsStatus = false,
                StatusName = new List<string>(),
                StatForTest = Statistics.Strenght
            },
                    new CharacterActions
            {
                Id = 2,
                ActionName = "Fist Attack",
                ActionDescription = "Strikes the chosen character with your bare hands",
                ActionType = CharacterActionType.MeleeAttack,
                HitRollRequired = true,
                Hit_Dmg = 2,
                Flat_Dmg = 1,
                Hit_Dice_Nr = 1,
                PossibleTargets = "enemy",
                InflictsStatus = false,
                StatusName = new List<string>(),
                StatForTest = Statistics.Strenght
            },
                    new CharacterActions
            {
                Id = 3,
                ActionName = "Magic Missiles",
                ActionDescription = "Throws magic missiles at the enmy",
                ActionType = CharacterActionType.MeleeAttack,
                HitRollRequired = true,
                Hit_Dmg = 4,
                Flat_Dmg = 2,
                Hit_Dice_Nr = 2,
                PossibleTargets = "enemy",
                InflictsStatus = false,
                StatusName = new List<string>(),
                StatForTest = Statistics.Strenght
            },
                              new CharacterActions
            {
                Id = 4,
                ActionName = "Healing Potion",
                ActionDescription = "Heals the user for 1d6 +2",
                ActionType = CharacterActionType.ItemAction,
                HitRollRequired = false,
                Hit_Dmg = 1,
                Flat_Dmg = 2,
                Hit_Dice_Nr = 1,
                PossibleTargets = "playableCharacter",
                InflictsStatus = false,
                StatusName = new List<string>(),
                StatForTest = Statistics.None
            },

        };

            Items = new List<Item>
            {
                new Armor
                {
                    Id=1,
                    Name="Light Armor",
                    ItemType = ItemType.Armors,
                    ArmorClass = 1,
                    ArmorType="Light"

                },
                new Weapon()
                {
                    Id=2,
                    Name="Short Sword",
                    ItemType =ItemType.Weapons,
                    ActionToTrigger = Actions.FirstOrDefault(a=> a.Id == 1)
                },
                new Consumable()
                {
                    Id=3,
                    Name="Healing Potion",
                    ItemType = ItemType.Consumable,
                    ActionToTrigger = Actions.FirstOrDefault(a=>a.Id == 4 )
                }

            };

            Enemies = new List<Enemy>
            {
                new Enemy
                {
                    ID = 1,
                    CharacterName = "Goblin Archer",
                    Race = "Goblin",
                    HealthPoints = 10,
                    Level = 1,
                    Alignment = "evil",
                    EquippedArmor = Items.FirstOrDefault(a => a.Id == 1),
                    EquippedWeapon = Items.FirstOrDefault(a => a.Id == 2),
                    Inventory = new Item[5],
                    Strenght = 10,
                    ModStrenght =0,
                    Dexterity =12,
                    ModDexterity=1,
                    Constitution=10,
                    ModConstitution=2,
                    Intelligence=8,
                    ModIntelligence=0,
                    Wisdom = 8,
                    ModWisdom =0,
                    Charisma = 6,
                    ModCharisma = 6
                }
            };

        }

            public List<Item> GetItems()
            {
                return Items;
            }
            public List<Enemy> GetEnemies()
            {
                return Enemies;
            }
            public List<CharacterActions> GetActions()
            {
                return Actions;
            }
        };
    }

 