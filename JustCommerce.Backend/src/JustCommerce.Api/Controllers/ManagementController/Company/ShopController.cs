using JustCommerce.Application.Features.ManagemenetFeatures.Shop.Command;
using JustCommerce.Application.Features.ManagemenetFeatures.Shop.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
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
        [Route("")]
        public async Task<IActionResult> GetAllShop(CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetShop.Query(), cancellationToken));
        }

        [HttpGet]
        [Route("{shopId}")]
        public async Task<IActionResult> GetShopById(Guid shopId,CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetShopById.Query(shopId), cancellationToken)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("")]
        public async Task<IActionResult> CreateShop(CreateShop.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateShop(UpdateShop.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpDelete]
        [Route("{shopId}")]
        public async Task<IActionResult> DeleteShopById(Guid shopId ,CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new DeleteShop.Command(shopId))));
        }
    }
}
