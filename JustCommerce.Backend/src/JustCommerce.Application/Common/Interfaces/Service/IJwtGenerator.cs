using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Models;

namespace JustCommerce.Application.Common.Interfaces.DataAccess.Service
{
    public interface IJwtGenerator
    {
        JwtGenerationResult Generate(UserDTO user);
    }
}
