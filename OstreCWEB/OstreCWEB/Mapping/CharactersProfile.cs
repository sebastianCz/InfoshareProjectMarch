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
            CreateMap<Item, ItemEditView>()
                .ForMember(x => x.AllExistingActions, options => options.Ignore())  
                .ForMember(x => x.AllExistingClasses, options => options.Ignore());
            CreateMap<ItemEditView, Item>()
                .ForMember(x => x.LinkedCharacters, options => options.Ignore())
                 .ForMember(x => x.ParagraphItems, options => options.Ignore())
                  .ForMember(x => x.ActionToTrigger, options => options.Ignore())
                 .ForMember(x => x.PlayableClass, options => options.Ignore());
            //CreateMap<CharacterActionView, CharacterAction>();
            CreateMap<Status, StatusView>();
            CreateMap<PlayableRace, PlayableRaceView>();
            CreateMap<PlayableRaceView, PlayableRace>()
                .ForMember(x => x.PlayableCharacter, options => options.Ignore());
            CreateMap<PlayableClass, PlayableClassView>();
            CreateMap<PlayableClassView, PlayableClass>()
                .ForMember(x => x.PlayableCharacter, options => options.Ignore())
                .ForMember(x => x.ActionsGrantedByClass, options => options.Ignore())
                .ForMember(x => x.ItemsGrantedByClass, options => options.Ignore()); 
            CreateMap<Character, CharacterView>();
            CreateMap<ItemCharacter, ItemCharacterView>();
            CreateMap<ActionCharacter, ActionCharacterView>();
            CreateMap<CharacterActionEditView, CharacterAction>()
                .ForMember(x => x.LinkedCharacter, options => options.Ignore())
                 .ForMember(x => x.LinkedItems, options => options.Ignore())
                  .ForMember(x => x.Status, options => options.Ignore())
             .ForMember(x => x.PlayableClass, options => options.Ignore());
        } 
    }
}
