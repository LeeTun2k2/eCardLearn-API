using API.Services;
using API.Services.Implements;
using API.Services.Interfaces;

namespace API.Services
{
    /// <summary>
    /// Dependency injection
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Add services
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddTransient<IAuthenticationService, AuthenticationService>();
            return service;
        }
    }

}
