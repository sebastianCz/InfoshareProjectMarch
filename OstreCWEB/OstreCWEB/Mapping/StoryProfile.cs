using AutoMapper;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using OstreCWEB.ViewModel.StoryBuilder;
using OstreCWEB.ViewModel.StoryBuilder.Properties;

namespace OstreCWEB.Mapping
{
    public class StoryProfile : Profile
    {
        public StoryProfile() 
        {
            CreateMap<Story, StoryAllParagraphsView>();

            CreateMap<Story, StoryView>();

            CreateMap<StoryView, Story>();

            CreateMap<Paragraph, ParagraphView>();

            CreateMap<Story, StoryDetailsView>();

            CreateMap<TestProp, TestPropView>();

            CreateMap<FightProp, FightPropView>();

            CreateMap<EnemyInParagraph, EnemyInParagraphView>();

            CreateMap<Choice, ChoiceView>();

            CreateMap<ParagraphCreateView, Paragraph>();

            CreateMap<Paragraph, ParagraphCreateView>();
        }
    }
}
