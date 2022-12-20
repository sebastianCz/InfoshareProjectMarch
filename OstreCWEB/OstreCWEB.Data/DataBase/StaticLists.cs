using OstreCWEB.Data.Enums;
using OstreCWEB.Data.Repository;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Data.Repository.Items;
using OstreCWEB.Data.Repository.WebObjects;
using OstreCWEB.Data.Repository.StoryModels;
using System.Security.Cryptography.X509Certificates;

namespace OstreCWEB.Data.DataBase
{
    public class StaticLists
    {
        private static List<User> Users = new List<User>();
        private static List<PlayableCharacterClass> PlayableCharacterClasses = new List<PlayableCharacterClass>();
        private static List<PlayableCharacter> PlayableCharacters = new List<PlayableCharacter>();
        private static List<PlayableRace> PlayableRaces = new List<PlayableRace>();
        private static List<Enemy> Enemies = new List<Enemy>();
        private static List<Item> Items = new List<Item>();
        private static List<CharacterActions> Actions = new List<CharacterActions>();
        private static List<Status> Statuses = new List<Status>();

        public PlayableCharacter GetPlayableCharacter(int id)
        {
            return PlayableCharacters.FirstOrDefault(x => x.ID == id);
        }
        public StaticLists()
        {
        }

        public void SeedData()
        {
            Statuses = new List<Status>
            {
                new Status
                {
                    ID = 1,
                    Name="Blind",
                    Description = "Blinds the character making him less accurate"

                },
                new Status
                {
                    ID=2,
                    Name="Bless",
                    Description="Character is blessed. It has a bonus 1d4 to every roll"
                }
            };

            PlayableRaces = new List<PlayableRace>
            {
                new PlayableRace
                {
                    ID = 1,
                    RaceName = "Human",
                    DefaultSkillsForClass = new List<Skill>
                        {
                            Skill.acrobatics,
                            Skill.religion
                        },
                    AmountOfSkillsToChoose = 1
                }
                
            };

            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    LoggedIn = false,
                    UserName = "Admin",
                    Password = "Admin",
                    Email = "Admin@Admin.com",
                    Created = DateTime.Now,
                    //It's set to null but we will hold our active character instance here. 
                    //It should be chosen each session. 
                    ActiveCharacter = null,
                    StoriesCreated = new List<Story>(),
                    CharactersCreated = new List<PlayableCharacter>(),
                    StoriesCompletedTotal = 0,
                    DamageDealt = 0,
                    DamageReceived = 0 
                }
            };

            PlayableCharacterClasses = new List<PlayableCharacterClass>
            {
                new PlayableCharacterClass
                {
                    ID = 1,
                    ClassName = "Warrior",
                    BonusesForEeachStatistic = new Dictionary<Statistics, int>
                    {
                        {Statistics.Strenght,1},
                        {Statistics.Dexterity,1}
                    }
                }
            };


            //Property StatusName is null if none is applied.
            Actions = new List<CharacterActions>
            {
                 new CharacterActions
            {
                Id = 1,
                ActionName = "Short Sword Attack",
                ActionDescription = "Strikes the chosen character with your weapon",
                ActionType = CharacterActionType.MeleeAttack,
                SavingThrowPossible = true,
                Max_Dmg = 6,
                Flat_Dmg = 1,
                Hit_Dice_Nr = 1,
                PossibleTargets = "enemy",
                InflictsStatus = false,
                StatForTest = Statistics.Strenght
            },
                    new CharacterActions
            {
                Id = 2,
                ActionName = "Fist Attack",
                ActionDescription = "Strikes the chosen character with your bare hands",
                ActionType = CharacterActionType.MeleeAttack,
                SavingThrowPossible = true,
                Max_Dmg = 2,
                Flat_Dmg = 1,
                Hit_Dice_Nr = 1,
                PossibleTargets = "enemy",
                InflictsStatus = false,
                StatForTest = Statistics.Strenght
            },
                    new CharacterActions
            {
                Id = 3,
                ActionName = "Magic Missiles",
                ActionDescription = "Throws magic missiles at the enmy",
                ActionType = CharacterActionType.MeleeAttack,
                SavingThrowPossible = true,
                Max_Dmg = 4,
                Flat_Dmg = 2,
                Hit_Dice_Nr = 2,
                PossibleTargets = "enemy",
                InflictsStatus = true,
                Status = Statuses.FirstOrDefault(s=>s.ID == 1),
                StatForTest = Statistics.Dexterity
            },
                              new CharacterActions
            {
                Id = 4,
                ActionName = "Healing Potion",
                ActionDescription = "Heals the user for 1d6 +2",
                ActionType = CharacterActionType.ItemAction,
                SavingThrowPossible = false,
                Max_Dmg = 1,
                Flat_Dmg = 2,
                Hit_Dice_Nr = 1,
                PossibleTargets = "caster",
                InflictsStatus = false,
                StatForTest = Statistics.None
            },
                 new CharacterActions
            {
                Id = 5,
                ActionName = "Bless",
                ActionDescription = "Blesses the target giving him advantage a bonus 1d4 to attack rolls",
                ActionType = CharacterActionType.Spell,
                SavingThrowPossible = false,
                Max_Dmg = 0,
                Flat_Dmg = 0,
                Hit_Dice_Nr = 0,
                PossibleTargets = "caster",
                InflictsStatus = true,
                Status = Statuses.FirstOrDefault(s=>s.ID==2),
                StatForTest = Statistics.None
            }

        };

            Items = new List<Item>
            {
                new Item
                {
                    Id=1,
                    Name="Light Armor",
                    ItemType = ItemType.Armors,
                    ArmorClass = 1,
                    ArmorType="Light"

                },
                new Item()
                {
                    Id=2,
                    Name="Short Sword",
                    ItemType =ItemType.Weapons,
                    ActionToTrigger = Actions.FirstOrDefault(a=> a.Id == 1)
                },
                new Item()
                {
                    Id=3,
                    Name="Healing Potion",
                    ItemType = ItemType.Consumable,
                    ActionToTrigger = Actions.FirstOrDefault(a=>a.Id == 4 )
                },
                new Item()
                {
                    Id=4,
                    Name="Small Wooden Shield",
                    ItemType = ItemType.Shield,
                    ArmorClass=1,
                    ArmorType = "basic"
                    
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
                    EquippedWeapon =Items.FirstOrDefault(a => a.Id == 2),
                    EquippedSecondaryWeapon = Items.FirstOrDefault(a=>a.Id == 4),
                    Inventory = new Item[5],
                    AllAvailableActions = new List<CharacterActions>(),
                    ActiveStatuses = new List<Status>(),
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

            PlayableCharacters = new List<PlayableCharacter>
            {
                new PlayableCharacter
                {
                    ID = 1,
                    CharacterName = "AdminCharacter",
                    HealthPoints = 10,
                    Level = 1,
                    Alignment = "Good",
                    EquippedArmor = Items.First(c=>c.Id==1),
                    EquippedWeapon = Items.First(c=>c.Id==2),
                    EquippedSecondaryWeapon =Items.First(c =>c.Id ==4),
                    Inventory = new Item[5],
                    AllAvailableActions = new List<CharacterActions>(),
                    DefaultActions = new List<CharacterActions>(),
                    Strenght = 16,
                    Dexterity = 14,
                    Constitution = 10,
                    Intelligence = 15,
                    Wisdom = 12,
                    ModWisdom=1,
                    Charisma = 2,
                    Race = PlayableRaces.FirstOrDefault(r=>r.ID ==1),
                    UserId = Users.FirstOrDefault(u=>u.Id == 1).Id,
                    CharacterClass =PlayableCharacterClasses.FirstOrDefault(c=>c.ID ==1),
                    Actions = new List<CharacterAction>(),
                    ActionsOnHero = new List<CharacterAction>()
                }
            };
            PlayableCharacters[0].DefaultActions.Add(Actions.FirstOrDefault(x => x.Id == 4));  //HardCoding
            PlayableCharacters[0].DefaultActions.Add(Actions.FirstOrDefault(x => x.Id == 3));

        }

        public Enemy GetEnemy()
        {
            return Enemies[0];
        }
        public List<Enemy> GetEnemies()
        {
            return Enemies;
        }
        public List<Item> GetItems()
         {
                return Items;
          }
           
            public List<CharacterActions> GetActions()
            {
                return Actions;
            }
        };
    }

 