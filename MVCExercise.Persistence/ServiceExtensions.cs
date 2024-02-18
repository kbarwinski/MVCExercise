using Microsoft.Extensions.DependencyInjection;
using MVCExercise.Persistence.Repositories.UnitOfWork;
using MVCExercise.Persistence.Repositories.Person;
using MVCExercise.Persistence.Repositories.Email;
using Microsoft.Extensions.Configuration;
using MVCExercise.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MVCExercise.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SQLServer")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
