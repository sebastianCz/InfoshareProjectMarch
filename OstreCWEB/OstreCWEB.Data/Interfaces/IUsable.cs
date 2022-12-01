using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Interfaces
{
    internal interface IUsable
    {
        public ITargetable UseItem(ITargetable itemUser,ITargetable itemarget);
        public CharacterActions ActionToTrigger { get; }
    }
}
