using OstreCWEB.Data.Repository.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Fight
{
    public class FightRepository : IFightRepository
    {
        private static Dictionary<int, FightInstance> FightInstances { get; set; }

        public FightRepository()
        {
            FightInstances = new Dictionary<int, FightInstance>();
        }
        public bool Add(int userId, FightInstance fightInstance, out string operationResult)
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
                Debug.WriteLine(operationResult);
                return false;
            }
        }
        public FightInstance GetById(int userId)
        {
            if (FightInstances.ContainsKey(userId))
            {
                  return FightInstances.First(x => x.Key == userId).Value;
            }
            else
            {
                return new FightInstance();
            }
        }
        public bool Delete(int userId, out string operationResult)
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

        public bool Update(int userId, FightInstance fightInstance,out string operationResult)
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



