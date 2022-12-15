using OstreCWEB.Data.Enums;
using OstreCWEB.Data.Repository;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Data.Repository.Items;
using OstreCWEB.Data.Repository.WebObjects;

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



        public StaticLists()
        {
        }

        public void SeedData()
        {

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
                    EquippedSecondaryWeapon = Items.FirstOrDefault(a=>a.Id ==4),
                    Inventory = new Item[5],
                    AllAvailableActions = new List<CharacterActions>(),
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
                    Strenght = 16,
                    ModStrenght =2,
                    Dexterity = 14,
                    ModDexterity=1,
                    Constitution = 10,
                    ModConstitution=1,
                    Intelligence = 15,
                    ModIntelligence =1,
                    Wisdom = 12,
                    ModWisdom=1,
                    Charisma = 2,
                    ModCharisma= 1,
                    Race = PlayableRaces.FirstOrDefault(r=>r.ID ==1),
                    UserId = Users.FirstOrDefault(u=>u.Id == 1).Id,
                    CharacterClass =PlayableCharacterClasses.FirstOrDefault(c=>c.ID ==1)

                }
            };

            foreach(var enemy in Enemies)
            {
                enemy.InitializePossibleActions();
            }
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

 