using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Data.Enums;
namespace OstreCWEB.Data.Interfaces
{
    public interface IEquipable
    {
        public string Name { get; set; }
        public bool EquipItem(IEquipable itemToEqup,Character equippingTarget,Slot slot ,out string actionResult);
    }
}
