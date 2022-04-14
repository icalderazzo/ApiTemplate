using DapperDatabaseInterface;

namespace WebApi.Extensions.Startup
{
    public static class Services
    {
        public static void AddDapperDatabaseInterface(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbContext>(c => ContextBuilder.Build(connectionString));
        }
    }    
}