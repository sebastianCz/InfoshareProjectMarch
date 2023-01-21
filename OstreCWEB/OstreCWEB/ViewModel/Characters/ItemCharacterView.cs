using OstreCWEB.Data.Repository.Characters.CharacterModels;

namespace OstreCWEB.ViewModel.Characters
{
    public class ItemCharacterView
    {
        public int Id { get; set; }
        public ItemView Item { get; set; } 

        //Paremeters for items in the given relationship
        public bool IsEquipped { get; set; }
    }
}
