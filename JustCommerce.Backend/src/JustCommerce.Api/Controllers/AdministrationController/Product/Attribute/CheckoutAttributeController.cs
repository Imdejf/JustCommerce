using JustCommerce.Application.Features.AdministrationFeatures.Product.Attributes.CheckoutAttributes.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Product.Attribute
{
    [Route("/api/administration/CheckoutAttribute")]
    public class CheckoutAttributeController : BaseApiController
    {
        [HttpPost]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> CreateProductAttribute(CreateCheckoutAttribute.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpPut]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> UpdateProductAttribute(UpdateCheckoutAttribute.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpDelete]
        //[Authorize]
        [Route("{id}")]
        public async Task<IActionResult> RemoveProductAttribute(Guid id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new RemoveCheckoutAttribute.Command(id), cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }
    }
}
