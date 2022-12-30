using OstreCWEB.Data.Repository.Characters.Interfaces;

namespace OstreCWEB.Services.SuperAdmin
{
    internal class SuperAdminService
    {
        private IPlayableCharacterRepository _playableCharacterRepository;

        public SuperAdminService(IPlayableCharacterRepository characterRepository)
        {
            _playableCharacterRepository = characterRepository;
        }   
         
    }
}
