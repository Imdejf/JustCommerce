using JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Product.Attribute
{
    [Route("/api/administration/ProductAttribute")]
    public class ProductAttributeController : BaseApiController
    {
        [HttpPost]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> CreateProductAttribute(CreateProductAttribute.Command command,CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpPut]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> UpdateProductAttribute(UpdateProductAttribute.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpDelete]
        //[Authorize]
        [Route("{id}")]
        public async Task<IActionResult> DeleteeProductAttribute(Guid id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new RemoveProductAttribute.Command(id), cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }
    }
}
