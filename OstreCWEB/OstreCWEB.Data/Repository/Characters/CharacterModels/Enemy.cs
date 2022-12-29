using System.Text.Json.Serialization;

namespace OstreCWEB.Data.Repository.Characters.CharacterModels

{
    public class Enemy : Character
    {
        public string Race { get; set; }

        [JsonConstructor]
        public Enemy() { }

        public void InitializePossibleActions()
        {
            var weapon = EquippedWeapon;
            var secondaryWeapon = EquippedSecondaryWeapon;
            var secondaryWeapon2 = EquippedSecondaryWeapon;
            var armor = EquippedArmor;

            if (armor.ActionToTrigger != null) { }

            AllAvailableActions.Add(weapon.ActionToTrigger);

        }

    }


}

