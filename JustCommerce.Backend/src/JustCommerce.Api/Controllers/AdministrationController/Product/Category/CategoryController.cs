using JustCommerce.Application.Features.AdministrationFeatures.Product.Category.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Product.Category
{
    [Route("/api/administration/Category")]
    public class CategoryController : BaseApiController
    {
        [HttpPost]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> CreateCategory(CreateCategory.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpPut]
        //[Authorize]
        [Route("")]
        public async Task<IActionResult> UpdateCategory(UpdateCategory.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }

        [HttpDelete]
        //[Authorize]
        [Route("{id}")]
        public async Task<IActionResult> RemoveCategory(Guid id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new RemoveCategory.Command(id), cancellationToken);
            return Ok(ApiResponse.Success(200, result));
        }
    }
}
