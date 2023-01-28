using Microsoft.AspNetCore.Identity;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.InitialData;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Enums;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Services.Identity;


namespace OstreCWEB.Services.Seed;

internal class SeedCharacters : ISeeder
{
    private readonly OstreCWebContext _db;
    private readonly UserManager<User> _userManager;
    private readonly IUserAuthenticationService _auth;
    private readonly IIdentityRepository _identity; 
    public SeedCharacters(UserManager<User> userManager,OstreCWebContext ostreCWebContext,IUserAuthenticationService auth,IIdentityRepository identity)
    {
        _db = ostreCWebContext;
        _userManager = userManager; 
        _auth = auth;
        _identity = identity;
    } 
    public async Task SeedCharactersDb()
    {
        if (_db.Users.Any()) { return; }
         await Seed();
    } 
    private async Task Seed()
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
            },
            new PlayableRace
            {
                RaceName = "Dwarf",
            },
            new PlayableRace
            {
                RaceName = "Elf",
            }
        };

        

        var playableCharacterClasses = new List<PlayableClass>
            {
                new PlayableClass
                {
                    ClassName = "Barbarian",
                    StrengthBonus=1,
                    ConstitutionBonus=1,
                    BaseHP = 12
                },
                 new PlayableClass
                {
                    ClassName = "Fighter",
                    StrengthBonus=1,
                    ConstitutionBonus=1,
                    BaseHP = 10
                },
                 new PlayableClass
                {
                    ClassName = "Cleric",
                    StrengthBonus=0,
                    IntelligenceBonus=1,
                    BaseHP = 8
                },
                new PlayableClass
                {
                    ClassName = "Wizard",
                    StrengthBonus=0,
                    IntelligenceBonus=1,
                    BaseHP = 6
                }
            }; 
        //Property StatusName is null if none is applied.
        var actions = new List<CharacterAction>
            {
                 new CharacterAction
            {
                ActionName = "Short Sword Attack",
                ActionDescription = "Strikes the chosen character with your weapon",
                ActionType = CharacterActionType.WeaponAttack,
                SavingThrowPossible = true,
                Max_Dmg = 6,
                Flat_Dmg = 1,
                Hit_Dice_Nr = 1,
                PossibleTarget = TargetType.Target,
                InflictsStatus = false,
                StatForTest = Statistics.Strenght,
                AggressiveAction = true
                
            },
                      new CharacterAction
            {
                ActionName = "Fireball",
                ActionDescription = "Throws a fireball",
                ActionType = CharacterActionType.Cantrip,
                SavingThrowPossible = true,
                Max_Dmg = 8,
                Flat_Dmg = 2,
                Hit_Dice_Nr = 4,
                PossibleTarget = TargetType.Target,
                InflictsStatus = false,
                StatForTest = Statistics.Intelligence,
                AggressiveAction = true,
                 UsesMaxBeforeRest = 0

            },

                    new CharacterAction
            {
                ActionName = "Fist Attack",
                ActionDescription = "Strikes the chosen character with your bare hands",
                ActionType = CharacterActionType.WeaponAttack,
                SavingThrowPossible = true,
                Max_Dmg = 2,
                Flat_Dmg = 1,
                Hit_Dice_Nr = 1,
                PossibleTarget = TargetType.Target,
                InflictsStatus = false,
                StatForTest = Statistics.Strenght,
                AggressiveAction = true
            },
                    new CharacterAction
            {
                ActionName = "Magic Missiles",
                ActionDescription = "Throws magic missiles at the enmy",
                ActionType = CharacterActionType.WeaponAttack,
                        SavingThrowPossible = true,
                Max_Dmg = 4,
                Flat_Dmg = 2,
                Hit_Dice_Nr = 2,
                PossibleTarget = TargetType.Target,
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
                SavingThrowPossible = false,
                ActionType = CharacterActionType.Spell,
                Max_Dmg = 1,
                Flat_Dmg = 2,
                Hit_Dice_Nr = 1,
                PossibleTarget = TargetType.Caster,
                InflictsStatus = false,
                StatForTest = Statistics.None,
                UsesMaxBeforeRest = 2,
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
                PossibleTarget = TargetType.Caster,
                InflictsStatus = true,
                Status = _db.Statuses.FirstOrDefault(s=>s.StatusId == 2),
                StatForTest = Statistics.None,
                UsesMaxBeforeRest = 1,
                 AggressiveAction = false
            },
                 
                 new CharacterAction
            {
                ActionName = "Action Surge",
                ActionDescription = "Gives you one more action once per day and once per turn",
                ActionType = CharacterActionType.SpecialAction,
                     SavingThrowPossible = false,
                Max_Dmg = 0,
                Flat_Dmg = 0,
                Hit_Dice_Nr = 0,
                PossibleTarget = TargetType.Caster,
                InflictsStatus = false,
                StatForTest = Statistics.None,
                UsesMaxBeforeRest = 1,
                 AggressiveAction = false
            } 
        }; 
        var items = new List<Item>
            {
                new Item()
                {
                    Name="Short Sword",
                    ItemType =ItemType.TwoHandedWeapon,
                    DeleteOnUse = false
                },
                new Item()
                {
                    Name="Healing Potion",
                    ItemType = ItemType.Consumable,
                    DeleteOnUse = true
                    
                },
                new Item()
                {
                    Name="Small Wooden Shield",
                    ItemType = ItemType.Shield,
                    ArmorClass=2,
                    ArmorType = ArmorType.Shield ,
                    DeleteOnUse = false
                },
                 new Item
                {
                    Name="Heavy Armor",
                    ItemType = ItemType.Armor,
                    ArmorClass = 2,
                    ArmorType = ArmorType.HeaveArmor, 
                    DeleteOnUse=false
                },
                new Item
                {
                    Name="Mage Robe",
                    ItemType = ItemType.Armor,
                    ArmorClass = 1,
                    ArmorType= ArmorType.LightArmor,
                    DeleteOnUse = false
                }
            }; 
        var enemies = new List<Enemy>
            {
                new Enemy
                {
                    CharacterName = "Goblin Archer",
                    NonPlayableRace = Races.Humanoid,
                    MaxHealthPoints = 10,
                    CurrentHealthPoints = 10,
                    Strenght = 10,
                    Dexterity =12,
                    Constitution=10,
                    Intelligence=8,
                    Wisdom = 8,
                    Charisma = 6,
                     IsTemplate= true
                }
            };
        var playableCharacters = new List<PlayableCharacter>
            {
                new PlayableCharacter
                {
                    CharacterName = "AdminCharacterWarrior",
                    MaxHealthPoints = 30,
                    CurrentHealthPoints = 30,
                    Strenght = 16,
                    Dexterity = 14,
                    Constitution = 10,
                    Intelligence = 15,
                    Wisdom = 12,
                    Charisma = 2,
                    IsTemplate= true
                },
                new PlayableCharacter
                {
                    CharacterName = "AdminCharacterMage",
                    MaxHealthPoints = 30,
                    CurrentHealthPoints = 30,
                    Strenght = 10,
                    Dexterity = 10,
                    Constitution = 14,
                    Intelligence = 18,
                    Wisdom = 14,
                    Charisma = 12,
                    IsTemplate = true
                }
            };

        var register = new Registration();
        var password = "";

        for (var i = 1; i < 10; i++)
        {
              password = "NewPassword@" + i;
              register = new Registration
            {
                Name = "NewUser" + i,
                Email = $"Test{i}@test.com",
                UserName = "NewUserName" + i,
                Password = password,
                PasswordConfirm = password,
                Role = "user"

            };
            await _auth.RegisterAsync(register);
        }
         password = "Admin123#";
        register = new Registration
        {
           
            Name = "Admin",
            Email = $"Test@test.com",
            UserName = "AdminUser",
            Password = password,
            PasswordConfirm = password,
            Role = "admin"

        };
        await _auth.RegisterAsync(register); 


        //_db.UserRoles.Add(adminRole);

        var users = await _identity.GetAll();
        _db.CharacterActions.AddRange(actions);
        _db.Statuses.AddRange(statuses);
        _db.PlayableCharacterRaces.AddRange(playableRaces);
        _db.PlayableCharacterClasses.AddRange(playableCharacterClasses);
        _db.Items.AddRange(items);
        _db.SaveChanges();


        //_db.SaveChanges();
        //ADDING RELATIONS
        _db.Items.FirstOrDefault(i => i.Name.Contains("Short Sword")).ActionToTrigger = _db.CharacterActions.FirstOrDefault(a => a.ActionName.Contains("Short Sword Attack"));
        _db.Items.FirstOrDefault(i => i.Name.Contains("Healing Potion")).ActionToTrigger = _db.CharacterActions.FirstOrDefault(a => a.ActionName.Contains("Small Heal"));

        _db.CharacterActions.FirstOrDefault(a => a.ActionName.Contains("Magic Missiles")).Status = _db.Statuses.FirstOrDefault(s => s.Name.Contains("Blind"));
        _db.CharacterActions.FirstOrDefault(a => a.ActionName.Contains("Bless")).Status = _db.Statuses.FirstOrDefault(s => s.Name.Contains("Bless"));

        _db.SaveChanges();
        foreach (var enemy in enemies)
        {
            enemy.EquippedItems.Add(_db.Items.FirstOrDefault(i => i.Name.ToLower().Contains("armor")));
            enemy.EquippedItems.Add(_db.Items.FirstOrDefault(i => i.Name.ToLower().Contains("short sword")));
            enemy.EquippedItems.Add(_db.Items.FirstOrDefault(i => i.Name.ToLower().Contains("small wooden shield")));
        }

        //warrior
        playableCharacters[0].EquippedItems.Add(_db.Items.FirstOrDefault(i => i.Name.ToLower().Contains("heavy armor")));
        playableCharacters[0].EquippedItems.Add(_db.Items.FirstOrDefault(i => i.Name.ToLower().Contains("short sword")));
        playableCharacters[0].EquippedItems.Add(_db.Items.FirstOrDefault(i => i.Name.ToLower().Contains("small wooden shield")));


        playableCharacters[0].Inventory.Add(_db.Items.FirstOrDefault(i => i.Name.ToLower().Contains("healing potion")));
        

        playableCharacters[0].Race = _db.PlayableCharacterRaces.FirstOrDefault (i => i.RaceName.ToLower().Contains("human"));
        playableCharacters[0].CharacterClass = _db.PlayableCharacterClasses.FirstOrDefault(i => i.ClassName.ToLower().Contains("fighter"));

        playableCharacters[0].InnateActions.Add(_db.CharacterActions.FirstOrDefault(x => x.ActionName.ToLower().Contains("action surge")));
        //mage
        playableCharacters[1].EquippedItems.Add(_db.Items.FirstOrDefault(i => i.Name.ToLower().Contains("mage robe")));

        playableCharacters[1].Race = _db.PlayableCharacterRaces.FirstOrDefault(i => i.RaceName.ToLower().Contains("human"));
        playableCharacters[1].CharacterClass = _db.PlayableCharacterClasses.FirstOrDefault(i => i.ClassName.ToLower().Contains("wizard"));

        playableCharacters[1].InnateActions.Add(_db.CharacterActions.FirstOrDefault(x => x.ActionName.ToLower().Contains("magic Missiles")));
        playableCharacters[1].InnateActions.Add(_db.CharacterActions.FirstOrDefault(x => x.ActionName.ToLower().Contains("small Heal")));
        playableCharacters[1].InnateActions.Add(_db.CharacterActions.FirstOrDefault(x => x.ActionName.ToLower().Contains("fireball")));
        playableCharacters = UpdatePlayableCharacterActionsRelations(playableCharacters);
        enemies = UpdateEnemyActionsRelations(enemies);
        playableCharacters = UpdatePlayableCharacterItemsRelations(playableCharacters);
        enemies = UpdateEnemyItemsRelations(enemies);

        _db.Enemies.AddRange(enemies);
        
        users.FirstOrDefault(u=>u.UserName =="AdminUser").CharactersCreated.Add(playableCharacters[0]);
        users[1].CharactersCreated.Add(playableCharacters[1]);


        //_db.SaveChanges();
        _db.SaveChanges();
        SeedStories.Initialize(_db, users.FirstOrDefault(u => u.UserName == "AdminUser"));
    }

    public  List<PlayableCharacter> UpdatePlayableCharacterItemsRelations(List<PlayableCharacter> characters)
    { 
        foreach (var character in characters)
        {
            //Deletes all many to many relations
            character.LinkedItems = new List<ItemCharacter>();
            if (character.EquippedItems.Any())
            {
                foreach (var item in character.EquippedItems)
                {
                    //Creates a new relation object for each action. 
                    character.LinkedItems.Add(
                     new ItemCharacter()
                     {
                         CharacterId = character.CharacterId,
                         ItemId = item.ItemId,
                         IsEquipped = true
                     });  
                }
            }

            if (character.Inventory.Any())
            {
                
                foreach (var item in character.Inventory)
                {
                    if(item != null)
                    {
                        character.LinkedItems.Add(
                            new ItemCharacter()
                               {
                                  CharacterId = character.CharacterId,
                                   ItemId = item.ItemId,
                                   IsEquipped = false 
                              });
                    } 
                }
            }
        };
        return characters;
    }
    public List<Enemy> UpdateEnemyItemsRelations(List<Enemy> characters)
    {
        foreach (var character in characters)
        {
            //Deletes all many to many relations
            character.LinkedItems = new List<ItemCharacter>();
            if (character.EquippedItems.Any())
            {
                foreach (var item in character.EquippedItems)
                {
                    //Creates a new relation object for each action. 
                    character.LinkedItems.Add(
                     new ItemCharacter()
                     {
                         CharacterId = character.CharacterId,
                         ItemId = item.ItemId,
                         IsEquipped = true 
                     });
                }
            } 
            if (character.Inventory.Any())
            {
                foreach (var item in character.Inventory)
                {
                    if(item != null)
                    {
                      character.LinkedItems.Add(
                        new ItemCharacter()
                        {
                         CharacterId = character.CharacterId,
                         ItemId = item.ItemId, 
                         IsEquipped = true
                        }); 
                    } 
                }
            }
        };
        return characters;
    }
    public List<PlayableCharacter> UpdatePlayableCharacterActionsRelations(List<PlayableCharacter> characters)
    {
        foreach (var character in characters)
        {
            //Deletes all many to many relations
            character.LinkedActions = new List<ActionCharacter>();

            foreach (var action in character.InnateActions)
            {
                //Creates a new relation object for each action. 
                character.LinkedActions.Add(
                 new ActionCharacter()
                 {
                     Character = character,
                     CharacterAction = action,
                     UsesLeftBeforeRest = action.UsesMaxBeforeRest 
                 });
            } 
        };
        return characters;
    }
    public List<Enemy> UpdateEnemyActionsRelations(List<Enemy> characters)
    {
        foreach (var character in characters)
        {
            //Deletes all many to many relations
            character.LinkedActions = new List<ActionCharacter>();

            foreach (var action in character.InnateActions)
            {
                //Creates a new relation object for each action. 
                character.LinkedActions.Add(
                 new ActionCharacter()
                 {
                     Character = character,
                     CharacterAction = action,
                     UsesLeftBeforeRest = action.UsesMaxBeforeRest
                 });
            }
        };
        return characters;
    } 
}

