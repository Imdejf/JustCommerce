using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController
{
    [Route("/api/administration")]
    public class CategoryController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public CategoryController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}
