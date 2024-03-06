

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Red_Social1.Core.Application.Interfaces.Repositories;
using Red_Social1.Infrastructure.Identity.Interfaces.Repositories;
using Red_Social1.Infrastructure.Persistence.Context;
using Red_Social1.Infrastructure.Persistence.Repository;


namespace Red_Social1.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        #region CONTEXT
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString, m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            }
            #endregion

            #region REPOSITORIES

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPublicationUserRepository, PublicationRepository>();
            services.AddTransient<IComentaryUserRepository, ComentaryUserRepository>();
            #endregion
        }

    }
}
