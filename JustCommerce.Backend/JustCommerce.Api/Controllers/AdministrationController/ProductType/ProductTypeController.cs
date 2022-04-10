using JustCommerce.Application.Common.Security;
using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command;
using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.ProductType
{
    [Route("/api/administration/producttype")]
    [Authorize(Roles.Seller, Roles.Manager)]
    public class ProductTypeController : BaseApiController
    {
        [HttpGet]
        [Route((""))]
        public async Task<IActionResult> GetAllProductType(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetProductType.Query(), cancellationToken);

            return Ok(ApiResponse.Success(200, result));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductTypeById(Guid id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetProductTypeById.Query(id), cancellationToken);

            return Ok(ApiResponse.Success(200, result));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProductType(CreateProductType.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateProductType(UpdateProductType.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveProductType(Guid id, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new RemoveProductType.Command(id),cancellationToken)));
        }
    }
}
