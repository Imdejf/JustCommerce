using JustCommerce.Application.Features.AdministrationFeatures.Product.Product.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Product.Product
{
    [Route("/api/administration/Product")]
    public class ProductController : BaseApiController
    {
        [HttpPost]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> CreateProduct(CreateProduct.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpPut]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> UpdateProduct(UpdateProduct.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpDelete]
        //[Authorize]
        [Route("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new RemoveProduct.Command(id), cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }
    }
}
