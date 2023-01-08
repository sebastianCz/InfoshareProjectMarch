using Microsoft.Extensions.DependencyInjection;
using OstreCWEB.Data.Repository.StoryModels;

namespace OstreCWEB.Data.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IStoryRepository, StoryRepository>();
        }
    }
}
