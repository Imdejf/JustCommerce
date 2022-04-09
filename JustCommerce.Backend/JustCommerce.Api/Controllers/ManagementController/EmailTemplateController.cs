using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;

namespace JustCommerce.Api.Controllers.ManagementController
{
    [Route("/api/management")]
    public class EmailTemplateController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public UserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}
