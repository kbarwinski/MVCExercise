using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MVCExercise.Infrastructure.Services.Person;

namespace MVCExercise.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MSSQL");
            //services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
