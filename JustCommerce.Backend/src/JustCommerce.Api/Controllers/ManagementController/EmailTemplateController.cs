using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.ManagementController
{
    [Route("/api/management")]
    public class EmailTemplateController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public EmailTemplateController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}
