using E_Commerce.Shared.Attributes;
using E_Commerce.Shared.Enums;
using E_Commerce.Shared.Enums.Permissions;
using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Command;
using JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.ProductType
{
    [Route("/api/administration/producttype")]
    public class ProductTypeController : BaseApiController
    {
        [HttpGet]
        [Authorize]
        [VerifyPermissions(ProductTypePermissions.ViewList, PermissionValidationMethod.HasAll)]
        [Route((""))]
        public async Task<IActionResult> GetAllProductType(CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetProductType.Query(), cancellationToken);

            return Ok(ApiResponse.Success(200, result));
        }

        [HttpGet]
        [Authorize]
        [VerifyPermissions(ProductTypePermissions.Detail | ProductTypePermissions.Edit, PermissionValidationMethod.HasAll)]
        [Route("{id}")]
        public async Task<IActionResult> GetProductTypeById(Guid id, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(new GetProductTypeById.Query(id), cancellationToken);

            return Ok(ApiResponse.Success(200, result));
        }

        [HttpPost]
        [Authorize]
        [VerifyPermissions(ProductTypePermissions.Create, PermissionValidationMethod.HasAll)]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProductType(CreateProductType.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }

        [HttpPut]
        [Authorize]
        [VerifyPermissions(ProductTypePermissions.Edit, PermissionValidationMethod.HasAll)]
        [Route("")]
        public async Task<IActionResult> UpdateProductType(UpdateProductType.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpDelete]
        [Authorize]
        [VerifyPermissions(ProductTypePermissions.Delete, PermissionValidationMethod.HasAll)]
        [Route("{id}")]
        public async Task<IActionResult> RemoveProductType(Guid id, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new RemoveProductType.Command(id),cancellationToken)));
        }
    }
}
