using AutoMapper;
using OstreCWEB.Data.Repository.Characters.CoreClasses;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.ViewModel.Fight;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Mapping
{
    public class FightProfile : Profile
    {
        public FightProfile()
        {
            CreateMap<FightInstance,FightViewModel>();
            CreateMap<PlayableCharacter, CharacterView>();
            CreateMap<Enemy, CharacterView>();
            CreateMap<CharacterAction, CharacterActionView>();
        }
    }
}




 