using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController
{
    [Route("/api/management")]
    public class ArticleController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public ArticleController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}
