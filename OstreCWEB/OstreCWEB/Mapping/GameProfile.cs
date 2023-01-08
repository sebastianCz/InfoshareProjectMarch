using AutoMapper;
using OstreCWEB.Data.DataBase.ManyToMany;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.ViewModel.Identity;
using OstreCWEB.ViewModel.StoryReader;

namespace OstreCWEB.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<UserParagraph, UserParagraphView>();

            CreateMap<Paragraph, CurrentParagraphView>();
            CreateMap<Choice, CurrentChoicesView>();
            CreateMap<PlayableCharacter, CurrentCharacterView>();
        }
    }
}