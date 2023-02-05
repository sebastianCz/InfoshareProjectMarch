using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.ManyToMany
{
    public interface IActionCharacterRepository
    {
        public Task<ActionCharacter> GetByCharacterId();
        public Task<ActionCharacter> GetAll();
        public Task<ActionCharacter> Create();
        public Task<ActionCharacter> Update();
        public Task<ActionCharacter> Delete();
    }
}
