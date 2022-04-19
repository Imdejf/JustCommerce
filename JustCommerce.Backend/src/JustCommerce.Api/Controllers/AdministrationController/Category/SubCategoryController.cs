using E_Commerce.Shared.Attributes;
using E_Commerce.Shared.Enums;
using E_Commerce.Shared.Enums.Permissions;
using JustCommerce.Application.Features.AdministrationFeatures.SubCategory.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Category
{
    [Route("/api/administration/subcategory")]
    public class SubCategoryController : BaseApiController
    {
        public SubCategoryController()
        {

        }

        [HttpGet]
        [Authorize]
        [VerifyPermissions(SubCategoryPermissions.Detail, PermissionValidationMethod.HasAll)]
        [Route("{id}")]
        public async Task<IActionResult> GetSubCategoryById(Guid categoryId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(new GetSubCategoryById.Query(categoryId), cancellationToken)));
        }

        [HttpPost]
        [Authorize]
        [VerifyPermissions(SubCategoryPermissions.Create, PermissionValidationMethod.HasAll)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("")]
        public async Task<IActionResult> CreateSubCategory(CreateSubCategory.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }

        [HttpPut]
        [Authorize]
        [VerifyPermissions(SubCategoryPermissions.Edit, PermissionValidationMethod.HasAll)]
        [Route("")]
        public async Task<IActionResult> UpdateCategory(UpdateSubCategory.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpDelete]
        [Authorize]
        [VerifyPermissions(SubCategoryPermissions.Delete, PermissionValidationMethod.HasAll)]
        [Route("{categoryId}")]
        public async Task<IActionResult> DeleteCategoryById(Guid categoryId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new RemoveSubCategory.Command(categoryId), cancellationToken)));
        }
    }
}
