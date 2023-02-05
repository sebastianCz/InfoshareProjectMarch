using OstreCWEB.Data.Repository.Characters.MetaTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    public interface IItemCharacterRepository
    {
        public Task<ItemCharacter> GetByCharacterId();
        public Task<ItemCharacter> GetAll();
        public Task AddRange(List<ItemCharacter> itemCharacter);
        public Task<ItemCharacter> Update();
        public Task<ItemCharacter> Delete();
    }
}
