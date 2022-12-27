using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.CoreClasses;
using System.ComponentModel.DataAnnotations;

namespace OstreCWEB.ViewModel.Fight
{
    public class CharacterView
    {
        public int CombatId { get; set; }
        public string CharacterName { get; set; }
        public int CurrentHealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        public int Level { get; set; } 
        public Item EquippedArmor { get; set; } 
        public Item EquippedWeapon { get; set; } 
        public Item EquippedSecondaryWeapon { get; set; } 
        public List<CharacterAction> AllAvailableActions { get; set; } 
        public List<Status> ActiveStatuses { get; set; }


    }
}
