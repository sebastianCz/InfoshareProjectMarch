using AutoMapper;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.ViewModel.Game;

namespace OstreCWEB.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<UserParagraph, GameInstanceView>(); 
        }
    }
}