using Core.Interfaces.Infrastructure.Repositories;
using Repositories;

namespace WebApi.Extensions.Startup
{
    public static class Repositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        }
    }
}