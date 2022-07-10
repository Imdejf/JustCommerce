using JustCommerce.Application.Features.AdministrationFeatures.Attributes.SpecificationAttributes.Commnad;
using JustCommerce.Application.Features.AdministrationFeatures.Attributes.SpecificationAttributes.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Product.Attribute
{
    [Route("/api/administration/specificationAttribute")]
    public class SpecificationAttributeController : BaseApiController
    {

        [HttpGet]
        //[Authorize]
        [Route("{storeId}")]
        public async Task<IActionResult> GetAllGroup(Guid storeId,CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetAllSpecificationGroup.Query(storeId), cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpPost]
        //[Authorize]
        [Route("createGroup")]
        public async Task<IActionResult> CreateGroup(CreateSpecificationGroup.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(201, result));
        }

        [HttpPost]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> CreateSpecificationAttribute(CreateSpecificationAttribute.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(201, result));
        }

        [HttpPut]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> UpdateSpecificationAttribute(UpdateSpecificationAttribute.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveSpecificationAttribute(Guid id, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new RemoveSpecificationAttribute.Command(id), cancellationToken)));
        }
    }
}
