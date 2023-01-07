using AutoMapper;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.ViewModel.Identity;

namespace OstreCWEB.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<UserParagraph, UserParagraphView>()
                .ForMember(destinationMember => destinationMember.UserParagraphId,
                method => method.MapFrom(source => source.UserParagraphId)); 
        }
    }
}