using AutoMapper;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.ViewModel.StoryBuilder;

namespace OstreCWEB.Mapping
{
    public class StoryProfile : Profile
    {
        public StoryProfile() 
        {
            CreateMap<Story, StoryView>();

            CreateMap<Paragraph, ParagraphView>();

            CreateMap<Story, StoryDetailsView>();
        }
    }
}
