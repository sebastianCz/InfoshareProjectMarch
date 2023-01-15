using AutoMapper;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.ViewModel.Identity;

namespace OstreCWEB.Mapping
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<User, UserView>();
        }
    }
}