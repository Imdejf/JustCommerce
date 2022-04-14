using JustCommerce.Application.Features.AdministrationFeatures.ProductTypeProperty.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        //[HttpGet]
        //[Authorize]
        //[Route(("{id}"))]
        //public async Task<IActionResult> GetProductTypePropertyByProductTypeId(Guid id, CancellationToken cancellationToken)
        //{
        //    var result = await Mediator.Send(new GetProductTypePropertyByProductTypeId.Query(), cancellationToken);

        //    return Ok(ApiResponse.Success(200, result));
        //}

        [HttpPost]
        [Authorize]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProductTypeProperty(CreateProductTypeProperty.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }
    }
}
