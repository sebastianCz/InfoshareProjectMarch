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
            CreateMap<PlayableClass, PlayableClassView>();
            CreateMap<Character, CharacterView>();
            CreateMap<ItemCharacter, ItemCharacterView>();
            CreateMap<ActionCharacter, ActionCharacterView>();

            CreateMap<PlayableCharacter, PlayableCharacterCreateView>()
                .ForMember(dest => dest.CharacterClasses, opt => opt.Ignore())
                .ForMember(dest => dest.CharacterRaces, opt => opt.Ignore());
            CreateMap<PlayableCharacterCreateView, PlayableCharacter>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.UserParagraph, opt => opt.Ignore())
                .ForMember(dest => dest.UserParagraphId, opt => opt.Ignore())
                .ForMember(dest => dest.LinkedActions, opt => opt.Ignore())
                .ForMember(dest => dest.LinkedItems, opt => opt.Ignore())
                .ForMember(dest => dest.IsTemplate, opt => opt.Ignore())
                .ForMember(dest => dest.MaxHealthPoints, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentHealthPoints, opt => opt.Ignore())
                .ForMember(dest => dest.EquippedItems, opt => opt.Ignore())
                .ForMember(dest => dest.Inventory, opt => opt.Ignore())
                .ForMember(dest => dest.InnateActions, opt => opt.Ignore())
                .ForMember(dest => dest.AllAvailableActions, opt => opt.Ignore())
                .ForMember(dest => dest.ActiveStatuses, opt => opt.Ignore())
                .ForMember(dest => dest.CombatId, opt => opt.Ignore());
            CreateMap<PlayableRaceView, PlayableRace>()
                .ForMember(dest => dest.PlayableCharacter, opt => opt.Ignore());
            CreateMap<PlayableClassView, PlayableClass>()
                .ForMember(dest => dest.PlayableCharacter, opt => opt.Ignore());
        } 
    }
}
