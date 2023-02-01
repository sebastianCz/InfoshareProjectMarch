using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters
{
    internal class CharacterRaceRepository : ICharacterRaceRepository
    {
        private OstreCWebContext _ostreCWebContext;
        public CharacterRaceRepository(OstreCWebContext ostreCWebContext)
        {
            _ostreCWebContext = ostreCWebContext;
        }        

        public Task Create(PlayableRace item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(PlayableRace item)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayableRace>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public PlayableRace GetById(int id)
        {
            return _ostreCWebContext.PlayableCharacterRaces.SingleOrDefault(x => x.PlayableRaceId == id);
        }

        public Task Update(PlayableRace item)
        {
            throw new NotImplementedException();
        }
    }
}
