using AutoMapper;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.ViewModel.Fight;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Mapping
{
    public class FightProfile : Profile
    {
        public FightProfile()
        {
            CreateMap<PlayableCharacter, CharacterView>();
            CreateMap<Enemy, CharacterView>();

        }

    }
}




 