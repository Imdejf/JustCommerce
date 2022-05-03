using JustCommerce.Application.Features.AdministrationFeatures.Product.Command;
using JustCommerce.Application.Features.AdministrationFeatures.Product.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Product
{
    [Route("/api/administration/product")]
    public class ProductController : BaseApiController
    {

        public ProductController()
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProduct(CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetProduct.Query(), cancellationToken)));
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetProductById(Guid productId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetProductById.Query(productId), cancellationToken)));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProduct(CreateProduct.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateProduct(UpdateProduct.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> RemoveProduct(Guid productId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new RemoveProduct.Command(productId), cancellationToken)));
        }
    }
}

