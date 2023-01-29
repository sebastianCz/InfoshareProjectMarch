using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    internal class ItemCharacterRepository : IItemCharacterRepository
    {
        public OstreCWebContext _context { get; }

        public ItemCharacterRepository(OstreCWebContext context)
        {
            _context = context;
        }

        public async Task Add(ItemCharacter itemCharacter)
        {
            _context.ItemsCharactersRelation.Add(itemCharacter);
            await _context.SaveChangesAsync();
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
