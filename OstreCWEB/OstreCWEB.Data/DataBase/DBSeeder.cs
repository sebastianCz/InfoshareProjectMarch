using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.Characters.CharacterModels; 
using System.Linq;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace OstreCWEB.Data.DataBase
{
    public class DBSeeder : ISeeder
    {
        private readonly OstreCWebContext _db;

        public DBSeeder(OstreCWebContext ostreCWebContext)
        {
            _db = ostreCWebContext;
        }

        public void SeedDataBase()
        {
            Seed();
        }

        private void Seed()
        {

            var statuses = new List<Status>
            {
                new Status
                {

                    Name="Blind",
                    Description = "Blinds the character making him less accurate"

                },
                new Status
                {
                    Name="Bless",
                    Description="Character is blessed. It has a bonus 1d4 to every roll"
                }
            };

            var playableRaces = new List<PlayableRace>
            {
                new PlayableRace
                {
                    RaceName = "Human",
                    //DefaultSkillsForClass = new List<Skill>
                    //{
                    //        Skill.acrobatics,
                    //        Skill.religion
                    //    },
                    AmountOfSkillsToChoose = 1,

                }

            };

            var users = new List<User>();
            for (var i = 0; i < 5; i++)
            {
               var user =  new User
                {
                    LoggedIn = false,
                    UserName = "Admin"+i,
                    Password = "Admin",
                    Email = "Admin@Admin.com",
                    Created = DateTime.Now,
                    StoriesCompletedTotal = 0,
                    DamageDealt = 0,
                    DamageReceived = 0,
                    CharactersCreated = new List<PlayableCharacter>()

                };
                users.Add(user);
            }







            var playableCharacterClasses = new List<PlayableClass>
                {
                    new PlayableClass
                    {
                        ClassName = "Warrior",
                        StrengthBonus=1,
                        ConstitutionBonus=1
                    }
                };


            //Property StatusName is null if none is applied.
            var actions = new List<CharacterAction>
                {
                     new CharacterAction
                {
                    ActionName = "Short Sword Attack",
                    ActionDescription = "Strikes the chosen character with your weapon",
                    ActionType = CharacterActionType.MeleeAttack,
                    SavingThrowPossible = true,
                    Max_Dmg = 6,
                    Flat_Dmg = 1,
                    Hit_Dice_Nr = 1,
                    PossibleTargets = "enemy",
                    InflictsStatus = false,
                    StatForTest = Statistics.Strenght,
                    AggressiveAction = true
                },
                        new CharacterAction
                {
                    ActionName = "Fist Attack",
                    ActionDescription = "Strikes the chosen character with your bare hands",
                    ActionType = CharacterActionType.MeleeAttack,
                    SavingThrowPossible = true,
                    Max_Dmg = 2,
                    Flat_Dmg = 1,
                    Hit_Dice_Nr = 1,
                    PossibleTargets = "enemy",
                    InflictsStatus = false,
                    StatForTest = Statistics.Strenght,
                    AggressiveAction = true
                },
                        new CharacterAction
                {
                    ActionName = "Magic Missiles",
                    ActionDescription = "Throws magic missiles at the enmy",
                    ActionType = CharacterActionType.MeleeAttack,
                            SavingThrowPossible = true,
                    Max_Dmg = 4,
                    Flat_Dmg = 2,
                    Hit_Dice_Nr = 2,
                    PossibleTargets = "enemy",
                    InflictsStatus = true,
                    Status = _db.Statuses.FirstOrDefault(s=>s.StatusId == 1),
                    StatForTest = Statistics.Dexterity,
                    UsesMaxBeforeRest = 2,
                     AggressiveAction = true

                },
                                  new CharacterAction
                {
                    ActionName = "Small Heal",
                    ActionDescription = "Heals the user for 1d6 +2",
                    ActionType = CharacterActionType.ItemAction,
                    SavingThrowPossible = false,
                    Max_Dmg = 1,
                    Flat_Dmg = 2,
                    Hit_Dice_Nr = 1,
                    PossibleTargets = "caster",
                    InflictsStatus = false,
                    StatForTest = Statistics.None,
                    UsesMax = 1,
                    AggressiveAction = false
                },
                     new CharacterAction
                {
                    ActionName = "Bless",
                    ActionDescription = "Blesses the target giving him advantage a bonus 1d4 to attack rolls",
                    ActionType = CharacterActionType.Spell,
                         SavingThrowPossible = false,
                    Max_Dmg = 0,
                    Flat_Dmg = 0,
                    Hit_Dice_Nr = 0,
                    PossibleTargets = "caster",
                    InflictsStatus = true,
                    Status = _db.Statuses.FirstOrDefault(s=>s.StatusId == 2),
                    StatForTest = Statistics.None,
                    UsesMaxBeforeRest = 1,
                     AggressiveAction = false
                }

            };

            var items = new List<Item>
                {
                    new Item
                    {
                        Name="Light Armor",
                        ItemType = ItemType.Armors,
                        ArmorClass = 1,
                        ArmorType="Light"

                    },
                    new Item()
                    {
                        Name="Short Sword",
                        ItemType =ItemType.Weapons
                    },
                    new Item()
                    {
                        Name="Healing Potion",
                        ItemType = ItemType.Consumable
                    },
                    new Item()
                    {
                        Name="Small Wooden Shield",
                        ItemType = ItemType.Shield,
                        ArmorClass=1,
                        ArmorType = "basic"

                    }
                };

            var enemies = new List<Enemy>
                {
                    new Enemy
                    {
                        CharacterName = "Goblin Archer",
                        Race = "Goblin",
                        MaxHealthPoints = 10,
                        CurrentHealthPoints = 10,
                        Level = 1,  
                        Strenght = 10,
                        Dexterity =12,
                        Constitution=10,
                        Intelligence=8,
                        Wisdom = 8,
                        Charisma = 6
                    }
                };


            var playableCharacters = new List<PlayableCharacter>
                {
                    new PlayableCharacter
                    {
                        CharacterName = "AdminCharacter",
                        MaxHealthPoints = 30,
                        CurrentHealthPoints = 30,
                        Level = 1, 
                        //Inventory = new Item[5],
                        AllAvailableActions = new List<CharacterAction>(),
                        DefaultActions=new List<CharacterAction>(),
                        Strenght = 16,
                        Dexterity = 14,
                        Constitution = 10,
                        Intelligence = 15,
                        Wisdom = 12,
                        Charisma = 2, 
                        UserId = 1, 

                    }
                };
            //Temporary hardcoding 


            _db.CharacterActions.AddRange(actions);
            _db.Statuses.AddRange(statuses);
            _db.PlayableCharacterRaces.AddRange(playableRaces);
            _db.PlayableCharacterClasses.AddRange(playableCharacterClasses);
            _db.Items.AddRange(items);
            _db.SaveChanges();
            
            _db.Items.FirstOrDefault(i => i.Name.Contains("Short Sword")).ActionToTrigger = _db.CharacterActions.FirstOrDefault(a => a.ActionName.Contains("Short Sword Attack"));
            _db.Items.FirstOrDefault(i => i.Name.Contains("Healing Potion")).ActionToTrigger = _db.CharacterActions.FirstOrDefault(a => a.ActionName.Contains("Small Heal"));

            _db.CharacterActions.FirstOrDefault(a=>a.ActionName.Contains("Magic Missiles")).Status = _db.Statuses.FirstOrDefault(s=>s.Name.Contains("Blind"));
            _db.CharacterActions.FirstOrDefault(a => a.ActionName.Contains("Bless")).Status = _db.Statuses.FirstOrDefault(s => s.Name.Contains("Bless"));
             
            _db.SaveChanges();
          
            enemies[0].EquippedArmor = _db.Items.FirstOrDefault(i => i.Name.Contains("Armor"));
            enemies[0].EquippedWeapon = _db.Items.FirstOrDefault(i => i.Name.Contains("Short Sword")); 
            enemies[0].EquippedSecondaryWeapon = _db.Items.FirstOrDefault(i => i.Name.Contains("Small Wooden Shield"));

             
            playableCharacters[0].EquippedArmor = _db.Items.FirstOrDefault(i => i.Name.Contains("Light Armor"));
            playableCharacters[0].EquippedWeapon = _db.Items.FirstOrDefault(i => i.Name.Contains("Short Sword"));
            playableCharacters[0].EquippedSecondaryWeapon = _db.Items.FirstOrDefault(i => i.Name.Contains("Small Wooden Shield"));
            playableCharacters[0].Race = _db.PlayableCharacterRaces.FirstOrDefault(i => i.RaceName.Contains("Human"));
            playableCharacters[0].CharacterClass = _db.PlayableCharacterClasses.FirstOrDefault(i => i.ClassName.Contains("Warrior"));

            playableCharacters[0].DefaultActions.Add(_db.CharacterActions.FirstOrDefault(x => x.ActionName.Contains("Magic Missiles")));
            playableCharacters[0].DefaultActions.Add(_db.CharacterActions.FirstOrDefault(x => x.ActionName.Contains("Small Heal")));

            playableCharacters[0].LinkedActions = new List<ActionCharacter>();

            var characters = new List<Character>();
             characters.Concat(playableCharacters);
             characters.Concat(enemies); 

            UpdateCharacterActionsRelations(characters);

            _db.Enemies.AddRange(enemies);
            users[0].CharactersCreated.Add(playableCharacters[0]);
            _db.Users.AddRange(users);
             

            _db.SaveChanges();


            var t1 =  _db.Enemies
                .Include(x=> x.DefaultActions)
                .ThenInclude(y=>y.Status)
                .ToList();

            var t2 = _db.PlayableCharacters
                .Include(x => x.DefaultActions)
                .ThenInclude(y => y.Status)
                .ToList();

            _db.SaveChanges();

        }

        public void UpdateCharacterActionsRelations(List<Character> characters)
        {
            foreach (var character in characters)
            {
                //Deletes all many to many relations
                character.LinkedActions = new List<ActionCharacter>();

                foreach (var action in character.DefaultActions)
                {
                    //Creates a new relation object for each action. 
                    character.LinkedActions.Add(
                     new ActionCharacter()
                    {
                        Character = character,
                        CharacterAction = action
                    });  
                }
            };
        }


    }
}

