using AutoMapper;
using OstreCWEB.Data.Repository.Characters.CharacterModels;

namespace OstreCWEB.Data.Factory
{
    internal class CharacterProfile :Profile
    {
        public CharacterProfile()
        {
            CreateMap<Enemy, Enemy>();
            CreateMap<PlayableCharacter,PlayableCharacter>();
        }
    }
}
