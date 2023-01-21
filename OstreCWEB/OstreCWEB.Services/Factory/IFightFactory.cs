
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Fight;

namespace OstreCWEB.Services.Factory
{
    public interface IFightFactory
    {
        public FightInstance BuildNewFightInstance(UserParagraph userParagraph,List<Enemy> enemies);
    }
}
