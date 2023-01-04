using AutoMapper;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Data.Repository.WebObjects;
using OstreCWEB.ViewModel.Fight;
using OstreCWEB.ViewModel.Game;

namespace OstreCWEB.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameInstance, GameInstanceView>(); 
        }
    }
}




 