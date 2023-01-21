﻿namespace OstreCWEB.Data.Repository.Fight
{
    public interface IFightRepository
    {
        public bool Add(string userId, FightInstance fightInstance, out string operationResult);
        public FightInstance GetById(string userId,int characterId);
        //public bool Delete(string userId, out string operationResult);
        //public bool Update(string userId, FightInstance fightInstance, out string operationResult); 
        public Task DeleteLinkedItemAsync(FightInstance fightInstance, int itemToDelete);
    }
}
