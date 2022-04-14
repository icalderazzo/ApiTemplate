using Core.Interfaces.Services;
using Core.Services;

namespace WebApi.Extensions.Startup
{
    public static class DapperDatabaseService
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkoutService, WorkoutService>();
        }
    }    
}