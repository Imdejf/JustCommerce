using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Configurations.Identity;
using E_Commerce.Persistence.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Persistence.DependencyInjection
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
            .AddEntityFrameworkStores<ECommerceDbContext>()
            .AddUserManager<UserManager<User>>()
            .AddSignInManager<SignInManager<User>>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
