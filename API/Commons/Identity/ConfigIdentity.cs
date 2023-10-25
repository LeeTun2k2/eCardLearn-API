using API.Data.Constants;
using API.Data.Entities;
using API.Data;
using Microsoft.AspNetCore.Identity;

namespace API.Commons
{
    /// <summary>
    /// Config Identity framework
    /// </summary>
    public static class ConfigIdentity
    {
        /// <summary>
        /// Add Identity
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DataContext>()
                .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

            // Config identity framework
            services.Configure<IdentityOptions>(options =>
            {
                // Password
                options.Password.RequireDigit = UserPassword.RequireDigit;
                options.Password.RequireLowercase = UserPassword.RequireLowercase;
                options.Password.RequireNonAlphanumeric = UserPassword.RequireNonAlphanumeric;
                options.Password.RequireUppercase = UserPassword.RequireUppercase;
                options.Password.RequiredLength = UserPassword.Length.Min;
                options.Password.RequiredUniqueChars = UserPassword.RequiredUniqueChars;

                // Lockout when trying spam password
                options.Lockout.DefaultLockoutTimeSpan = UserLockout.DefaultLockoutTimeSpan;
                options.Lockout.MaxFailedAccessAttempts = UserLockout.MaxFailedAccessAttempts;
                options.Lockout.AllowedForNewUsers = UserLockout.AllowedForNewUsers;

                // User
                options.User.AllowedUserNameCharacters = UserConfig.AllowedUserNameCharacters;
                options.User.RequireUniqueEmail = UserConfig.RequireUniqueEmail;

                // Login
                options.SignIn.RequireConfirmedEmail = UserSignIn.RequireConfirmedEmail;
                options.SignIn.RequireConfirmedPhoneNumber = UserSignIn.RequireConfirmedPhoneNumber;
            });
            return services;
        }
    }
}
