using AutoMapper;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.ViewModel.Fight;
using OstreCWEB.ViewModel.Characters;
using OstreCWEB.Data.Repository.Characters.MetaTags;

namespace OstreCWEB.Mapping
{
    public class CharactersProfile : Profile
    {
        public CharactersProfile()
        {
            CreateMap<PlayableCharacter, CharacterView>();
            CreateMap<PlayableCharacter, PlayableCharacterView>();
            CreateMap<PlayableCharacter, PlayableCharacterRow>();
            CreateMap<Enemy, CharacterView>();
            CreateMap<CharacterAction, CharacterActionView>();
            CreateMap<Item, ItemView>();
            CreateMap<Status, StatusView>();
            CreateMap<PlayableRace, PlayableRaceView>();
            CreateMap<PlayableClass, PlayableClassView>();
            CreateMap<Character, CharacterView>();
            CreateMap<ItemCharacter, ItemCharacterView>();
            CreateMap<ActionCharacter, ActionCharacterView>();
        } 
    }
}
