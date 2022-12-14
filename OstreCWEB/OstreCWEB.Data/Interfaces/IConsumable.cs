using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Interfaces
{
    public interface IConsumable
    {
        public ITargetable UseItem(ITargetable itemUser,ITargetable itemarget);
        public CharacterActions ActionToTrigger { get; }
        
    }
}
