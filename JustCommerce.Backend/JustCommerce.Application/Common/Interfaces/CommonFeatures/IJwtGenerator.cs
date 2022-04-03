using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities.Identity;

namespace JustCommerce.Application.Common.Interfaces.CommonFeatures
{
    public interface IJwtGenerator
    {
        JwtGenerationResult Generate(UserEntity user);
    }
}
