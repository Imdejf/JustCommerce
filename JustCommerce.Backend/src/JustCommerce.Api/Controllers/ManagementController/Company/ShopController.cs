using E_Commerce.Shared.Attributes;
using E_Commerce.Shared.Enums;
using E_Commerce.Shared.Enums.Permissions;
using JustCommerce.Application.Features.ManagemenetFeatures.Shop.Command;
using JustCommerce.Application.Features.ManagemenetFeatures.Shop.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Company
{
    [Route("/api/management/shop")]
    public class ShopController : BaseApiController
    {
        public ShopController()
        {

        }
        
        [HttpGet]
        [Authorize]
        [VerifyPermissions(ShopPermissions.ViewList, PermissionValidationMethod.HasAll)]
        [Route("")]
        public async Task<IActionResult> GetAllShop(CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetShop.Query(), cancellationToken)));
        }

        [HttpGet]
        [Authorize]
        [VerifyPermissions(ShopPermissions.Detail, PermissionValidationMethod.HasAll)]
        [Route("{shopId}")]
        public async Task<IActionResult> GetShopById(Guid shopId,CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetShopById.Query(shopId), cancellationToken)));
        }

        [HttpPost]
        [Authorize]
        [VerifyPermissions(ShopPermissions.Create, PermissionValidationMethod.HasAll)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("")]
        public async Task<IActionResult> CreateShop(CreateShop.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }

        [HttpPut]
        [Authorize]
        [VerifyPermissions(ShopPermissions.Edit, PermissionValidationMethod.HasAll)]
        [Route("")]
        public async Task<IActionResult> UpdateShop(UpdateShop.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpDelete]
        [Authorize]
        [VerifyPermissions(ShopPermissions.Delete, PermissionValidationMethod.HasAll)]
        [Route("{shopId}")]
        public async Task<IActionResult> DeleteShopById(Guid shopId ,CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new DeleteShop.Command(shopId))));
        }
    }
}
