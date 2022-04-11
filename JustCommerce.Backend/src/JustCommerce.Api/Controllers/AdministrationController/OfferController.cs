using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController
{
    [Route("/api/administration")]
    public class OfferController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public OfferController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
    }
}
