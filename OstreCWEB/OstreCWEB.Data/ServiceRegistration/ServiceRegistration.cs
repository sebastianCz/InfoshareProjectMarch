using Microsoft.Extensions.DependencyInjection;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Interfaces;

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
