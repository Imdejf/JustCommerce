using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.ProductType
{
    [Route("/api/administration/producttypeproperty")]
    public class ProductTypePropertyController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public ProductTypePropertyController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

    }
}
