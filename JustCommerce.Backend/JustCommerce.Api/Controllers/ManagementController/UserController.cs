using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.ManagementController
{
    [Route("api/management")]
    public class UserController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public UserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}
