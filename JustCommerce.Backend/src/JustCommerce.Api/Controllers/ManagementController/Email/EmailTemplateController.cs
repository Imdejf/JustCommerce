using JustCommerce.Application.Features.ManagemenetFeatures.EmailTemplate.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.ManagementController.Email
{
    [Route("/api/management/EmailTemplate")]
    public class EmailTemplateController : BaseApiController
    {
        public EmailTemplateController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetEmailTemplate()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("")]
        public async Task<IActionResult> CreateEmailTemplate(CreateEmailTemplate.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }
    }
}
