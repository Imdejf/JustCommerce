using JustCommerce.Application.Features.AdministrationFeatures.Order.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Order
{
    [Route("/api/administration/order")]
    public class OrderContoller : BaseApiController
    {
        public OrderContoller()
        {

        }

        [HttpPost]
        public async Task<IActionResult> SetOrderStatus(SetOrderStatus.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }
    }
}
