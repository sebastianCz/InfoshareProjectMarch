using OstreCWEB.Data.Repository;
using OstreCWEB.Data.Enums;
namespace OstreCWEB.Data.Interfaces
{
    internal interface IEquipable
    {
        public bool EquipItem(IEquipable itemToEqup,Character equippingTarget,Slot slot );
    }
}
