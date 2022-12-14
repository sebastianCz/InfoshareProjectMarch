using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Interfaces
{
    public interface IWeapon
    {
        public ITargetable UseItem(ITargetable itemUser,ITargetable itemTarget);
        public CharacterActions ActionToTrigger { get; } 
    }
}
