namespace OstreCWEB.Data.Repository.Fight
{
    public interface IFightRepository
    {
        public bool Add(int userId, FightInstance fightInstance, out string operationResult);
        public FightInstance GetById(int userId);
        public bool Delete(int userId, out string operationResult);
        public bool Update(int userId, FightInstance fightInstance, out string operationResult);
    }
}
