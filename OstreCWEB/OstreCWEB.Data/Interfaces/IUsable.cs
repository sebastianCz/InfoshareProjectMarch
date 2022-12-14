﻿using OstreCWEB.Data.Repository.Characters;

namespace OstreCWEB.Data.Interfaces
{
    public interface IUsable
    {
        public ITargetable UseItem(ITargetable itemUser,ITargetable itemTarget);
        public CharacterActions ActionToTrigger { get; }
        public int UsesRemaining { get;}
    }
}
