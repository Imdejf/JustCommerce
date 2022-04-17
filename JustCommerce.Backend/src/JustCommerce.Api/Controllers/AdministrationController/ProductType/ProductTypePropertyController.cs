using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query;
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

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> ProductTypeById(Guid productTypeId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetProductTypeById.Query(productTypeId), cancellationToken)));
        }

        [HttpPut]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> UpdateProductTypeProperty(UpdateProductTypeProperty.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

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
