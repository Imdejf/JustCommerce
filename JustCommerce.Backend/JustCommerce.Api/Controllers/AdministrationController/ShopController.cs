using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;

namespace JustCommerce.Api.Controllers.AdministrationController
{
    [Route("/api/management")]
    public class ShopController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public ShopController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}
