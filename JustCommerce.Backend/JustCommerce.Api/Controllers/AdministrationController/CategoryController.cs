using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;

namespace JustCommerce.Api.Controllers.AdministrationController
{
    public class CategoryController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public CategoryController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}
