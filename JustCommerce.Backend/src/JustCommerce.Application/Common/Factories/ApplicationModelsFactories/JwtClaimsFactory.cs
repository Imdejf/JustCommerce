using JustCommerce.Application.Common.DTOs;
using JustCommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCommerce.Application.Common.Factories.ApplicationModelsFactories
{
    public static class JwtClaimsFactory
    {
        public static JustCommerceJwtClaims CreateFromIntranetUserDTO(UserDTO dto)
        {
            return new JustCommerceJwtClaims
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                PermissionsList = dto.Permissions,
                Id = dto.Id
            };
        }
    }
}
