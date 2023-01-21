using System.Diagnostics;

namespace OstreCWEB.Data.Repository.Fight
{
    internal  class FightRepository : IFightRepository
    {
        private static Dictionary<string, FightInstance> FightInstances { get; set; } = FightInstances = new Dictionary<string, FightInstance>();
 
        public bool Add(string userId, FightInstance fightInstance, out string operationResult)
        {
            if (!FightInstances.ContainsKey(userId))
            {
                FightInstances.Add(userId, fightInstance);
                operationResult = "operation success";
                return true;
            }
            else
            {
                operationResult = "operation failed"; 
                return false;
            }
        }
        public FightInstance GetById(string userId)
        {
            if (FightInstances.ContainsKey(userId))
            {
                  return FightInstances.First(x => x.Key == userId).Value;
            }
            else
            {
                return null;
            }
        }
        public bool Delete(string userId, out string operationResult)
        {
            if (FightInstances.ContainsKey(userId))
            {
                FightInstances.Remove(userId);
                operationResult = "operation success";
                return true;
            }
            else
            {
                operationResult = "There is no user";
                return false;
            }
        }

        public bool Update(string userId, FightInstance fightInstance,out string operationResult)
        {
            if (FightInstances.ContainsKey(userId))
            {
                FightInstances[userId] = fightInstance;
                operationResult = "operation success";
                return true;
            }
            else
            {
                operationResult = "There is no user";
                return false;
            }
        }
    }
}



