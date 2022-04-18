using E_Commerce.Shared.Attributes;
using E_Commerce.Shared.Enums;
using E_Commerce.Shared.Enums.Permissions;
using JustCommerce.Application.Features.AdministrationFeatures.Category.Command;
using JustCommerce.Application.Features.AdministrationFeatures.Category.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController
{
    [Route("/api/administration/category")]
    public class CategoryController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public CategoryController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpGet]
        [Authorize]
        [VerifyPermissions(CategoryPermissions.ViewList, PermissionValidationMethod.HasAll)]
        [Route("")]
        public async Task<IActionResult> GetCategory(Guid categoryId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(new GetCategory.Query(), cancellationToken)));
        }

        [HttpGet]
        [Authorize]
        [VerifyPermissions(CategoryPermissions.Detail, PermissionValidationMethod.HasAll)]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid categoryId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(new GetCategoryById.Query(categoryId), cancellationToken)));
        }

        [HttpPost]
        [Authorize]
        [VerifyPermissions(CategoryPermissions.Create, PermissionValidationMethod.HasAll)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("")]
        public async Task<IActionResult> CreateCategory(CreateCategory.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken))); 
        }

        [HttpPut]
        [Authorize]
        [VerifyPermissions(CategoryPermissions.Edit, PermissionValidationMethod.HasAll)]
        [Route("")]
        public async Task<IActionResult> UpdateCategory(UpdateCategory.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpDelete]
        [Authorize]
        [VerifyPermissions(CategoryPermissions.Delete, PermissionValidationMethod.HasAll)]
        [Route("{categoryId}")]
        public async Task<IActionResult> DeleteCategoryById(Guid categoryId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new RemoveCategory.Command(categoryId), cancellationToken)));
        } 
    }
}
