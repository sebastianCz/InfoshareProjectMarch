using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.Interfaces;

namespace OstreCWEB.Data.Repository.Characters
{
    internal class CharacterRaceRepository : ICharacterRaceRepository
    {
        public OstreCWebContext _ostreCWebContext { get; }
        public CharacterRaceRepository(OstreCWebContext ostreCWebContext)
        {
            _ostreCWebContext = ostreCWebContext;
        }
         
        public async Task CreateAsync(PlayableRace item)
        {
            _ostreCWebContext.PlayableCharacterRaces.Add(item);
            await _ostreCWebContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _ostreCWebContext.PlayableCharacterRaces.Remove(await GetByIdAsync(id));
            await _ostreCWebContext.SaveChangesAsync();
        }

        public async Task<List<PlayableRace>> GetAllAsync()
        {
            return await _ostreCWebContext.PlayableCharacterRaces.ToListAsync();
        }

        public async Task<PlayableRace> GetByIdAsync(int id)
        {
            return await _ostreCWebContext.PlayableCharacterRaces.SingleOrDefaultAsync(x => x.PlayableRaceId == id);
        }

        public async Task UpdateAsync(PlayableRace item)
        {
            _ostreCWebContext.Update(item);
            await _ostreCWebContext.SaveChangesAsync();
        }
    }
}
