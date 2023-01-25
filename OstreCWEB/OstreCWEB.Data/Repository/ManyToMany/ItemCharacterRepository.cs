using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.MetaTags;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    internal class ItemCharacterRepository : IItemCharacterRepository
    {
        public OstreCWebContext _context { get; }

        public ItemCharacterRepository(OstreCWebContext context)
        {
            _context = context;
        }
        public Task<ItemCharacter> Create()
        {
            throw new NotImplementedException();
        }

        public Task<ItemCharacter> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<ItemCharacter> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ItemCharacter> GetByCharacterId()
        {
            throw new NotImplementedException();
        }

        public Task<ItemCharacter> Update()
        {
            throw new NotImplementedException();
        }
      
    }
}
