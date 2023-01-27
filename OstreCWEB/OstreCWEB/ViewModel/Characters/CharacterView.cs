using OstreCWEB.Data.Repository.Characters.CharacterModels;

namespace OstreCWEB.ViewModel.Characters
{
    public class CharacterView
    {
        public int CombatId { get; set; }
        public string CharacterName { get; set; }
        public int CurrentHealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        public List<ItemView> EquippedItems { get; set; }
        public List<ItemView> Inventory { get; set; }
        public List<CharacterActionView>? InnateActions { get; set; }
        public List<CharacterActionView> AllAvailableActions
        {
            get
            {
                var allAvailableActions = new List<CharacterActionView>();
                foreach (var item in EquippedItems) { if (item.ActionToTrigger != null) { allAvailableActions.Add(item.ActionToTrigger); } }
                foreach (var action in InnateActions) { if (action != null) { allAvailableActions.Add(action); } }
                foreach (var item in Inventory)
                {
                    if (item != null && item.ActionToTrigger != null)
                    {
                        allAvailableActions.Add(item.ActionToTrigger);
                    }
                }
                return allAvailableActions;
            }
            set
            {
                //Should be removed. For now it will cause compile errors in fight ( it needs the SET )
            }
        }
        public List<StatusView> ActiveStatuses { get; set; }


    }
}
