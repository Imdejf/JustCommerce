using JustCommerce.Application.Features.AdministrationFeatures.Manufacturers.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Manufacturer
{
    [Route("/api/administration/Manufacturer")]
    public class ManufacturerController : BaseApiController
    {
        [HttpPost]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> CreateManufacturer(CreateManufacturer.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpPut]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> UpdateProductAttribute(UpdateManufacturer.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpDelete]
        //[Authorize]
        [Route("{id}")]
        public async Task<IActionResult> RemoveProductAttribute(Guid id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new RemoveManufacturer.Command(id), cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }
    }
}
