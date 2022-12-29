using AutoMapper;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.ViewModel.Fight; 

namespace OstreCWEB.Mapping
{
    public class FightProfile : Profile
    {
        public FightProfile()
        {
            CreateMap<FightInstance,FightViewModel>(); 
        }
    }
}




 