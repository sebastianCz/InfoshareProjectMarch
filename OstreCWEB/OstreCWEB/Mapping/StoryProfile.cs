using AutoMapper;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Services.Models;
using OstreCWEB.ViewModel.Game;
using OstreCWEB.ViewModel.StoryBuilder;

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
                    .ForMember(dest => dest.Paragraphs, opt => opt.Ignore())
                    .ForMember(dest => dest.FirstParagraphId, opt => opt.Ignore());

            CreateMap<Story, StoryParagraphsView>();
            CreateMap<Paragraph, ParagraphElementOfStoryView>();

            CreateMap<ParagraphDetails, ParagraphDetailsView>();
            CreateMap<ParagraphWithCoice, ParagraphWithCoiceView>();
        }
    }
}
