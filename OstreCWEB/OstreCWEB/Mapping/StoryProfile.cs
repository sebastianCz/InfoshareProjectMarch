using AutoMapper;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.Services.Models;
using OstreCWEB.ViewModel.StoryBuilder;
using OstreCWEB.ViewModel.StoryBuilder.Properties;

namespace OstreCWEB.Mapping
{
    public class StoryProfile : Profile
    {
        public StoryProfile() 
        {
            //Game
            CreateMap<Paragraph, GameParagraphView>();

            //StoryBuilder          
            CreateMap<Story, StoriesView>()
                .ReverseMap()
                    .ForMember(dest => dest.Paragraphs, opt => opt.Ignore());

            CreateMap<Story, StoryParagraphsView>();
            CreateMap<Paragraph, ParagraphElementOfStoryView>();

            CreateMap<ParagraphDetails, ParagraphDetailsView>();
            CreateMap<ParagraphWithCoice, ParagraphWithCoiceView>();

            CreateMap<TestProp, TestPropView>();
            CreateMap<FightProp, FightPropView>();

            CreateMap<EnemyInParagraph, EnemyInParagraphView>()
                .ForMember(dest => dest.EnemyName, opt => opt.Ignore());

            CreateMap<Choice, ChoiceView>();

            CreateMap<Paragraph, ParagraphCreateView>()
                .ReverseMap()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.FightProp, opt => opt.Ignore())
                    .ForMember(dest => dest.DialogProp, opt => opt.Ignore())
                    .ForMember(dest => dest.TestProp, opt => opt.Ignore())
                    .ForMember(dest => dest.ShopkeeperProp, opt => opt.Ignore())
                    .ForMember(dest => dest.Choices, opt => opt.Ignore())
                    .ForMember(dest => dest.UserParagraphs, opt => opt.Ignore())
                    .ForMember(dest => dest.Story, opt => opt.Ignore());           
        }
    }
}
