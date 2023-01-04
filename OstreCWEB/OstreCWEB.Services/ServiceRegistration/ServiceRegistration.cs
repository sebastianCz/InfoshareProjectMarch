using Microsoft.Extensions.DependencyInjection;
using OstreCWEB.Services.StoryService;

namespace OstreCWEB.Services.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IStoryService, StoryService.StoryService>();
        }
    }
}
