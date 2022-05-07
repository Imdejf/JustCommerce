using JustCommerce.Application.Features.AdministrationFeatures.Offer.Command;
using JustCommerce.Application.Features.AdministrationFeatures.Offer.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Offer
{
    [Route("/api/administration/offer")]
    public class OfferController : BaseApiController
    {
        public OfferController()
        {

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetOffer(CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetOffer.Query(), cancellationToken)));
        }

        [HttpGet]
        [Route("offerId")]
        public async Task<IActionResult> GetOfferById(Guid offerId,CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetOfferById.Query(offerId), cancellationToken)));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateOffer(CreateOffer.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken))); 
        }

        [HttpPost]
        [Route("/status-type")]
        public async Task<IActionResult> OfferStatusType(SetOfferStatusType.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }

        [HttpPost]
        [Route("/send")]
        public async Task<IActionResult> SendOffer(SendOffer.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(command, cancellationToken)));
        }
    }
}
