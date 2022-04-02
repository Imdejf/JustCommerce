using JustCommerce.Application.Models;
using JustCommerce.Domain.Entities;

namespace JustCommerce.Application.Common.Interfaces.CommonFeatures
{
    public interface IJwtGenerator
    {
        JwtGenerationResult Generate(User user);
    }
}
