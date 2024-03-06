using Microsoft.Extensions.DependencyInjection;
using Red_Social1.Core.Application.Interfaces.Services;
using Red_Social1.Core.Application.Services;
using System.Reflection;

namespace Red_Social1.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUserService, UserService>();
          //  services.AddTransient<IPublicationService, PublicationService>();
            #endregion
        }
    }
}

