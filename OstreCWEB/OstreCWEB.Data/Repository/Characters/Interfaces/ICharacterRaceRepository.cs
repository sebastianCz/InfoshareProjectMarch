using OstreCWEB.Data.Repository.Characters.CharacterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstreCWEB.Data.Repository.Characters.Interfaces
{
    public interface ICharacterRaceRepository
    {
        public PlayableRace GetById(int id);
        public Task<List<PlayableRace>> GetAll(int id);
        public Task Update(PlayableRace item);
        public Task Create(PlayableRace item);
        public Task Delete(PlayableRace item);        
    }
}
