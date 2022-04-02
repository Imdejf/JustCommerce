using JustCommerce.Domain.Entities;
using JustCommerce.Persistence.Configurations.Identity;
using JustCommerce.Persistence.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JustCommerce.Persistence.DependencyInjection
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
            {
                options.Password = IdentityOptionsConfig.PasswordOptions;
                options.User = IdentityOptionsConfig.UserOptions;
                options.ClaimsIdentity = IdentityOptionsConfig.ClaimsIdentityOptions;
                options.Lockout = IdentityOptionsConfig.LockoutOptions;
                options.Tokens = IdentityOptionsConfig.TokenOptions;
                options.SignIn = IdentityOptionsConfig.SignInOptions;
                options.Stores = IdentityOptionsConfig.StoreOptions;
            })
            .AddEntityFrameworkStores<JustCommerceDbContext>()
            .AddUserManager<UserManager<User>>()
            .AddSignInManager<SignInManager<User>>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
