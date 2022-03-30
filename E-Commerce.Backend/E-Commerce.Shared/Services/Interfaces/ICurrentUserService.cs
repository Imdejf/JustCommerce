using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.Services.Interfaces
{
    public interface ICurrentUserService
    {
        ApplicationUserJwtClaims CurrentUser { get; }
        void SetCurrentUser(ApplicationUserJwtClaims claims);
        void SetCurrentUser(string jwt);
    }
}
