using JustCommerce.Application.Features.ManagemenetFeatures.EmailAccount.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.ManagementController.Email
{
    [Route("/api/management/EmailAccount")]
    public class EmailAccountController : BaseApiController
    {
        public EmailAccountController()
        {

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetEmailAccount()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateEmailAccount(CreateEmailAccount.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));

        }


    }
}
