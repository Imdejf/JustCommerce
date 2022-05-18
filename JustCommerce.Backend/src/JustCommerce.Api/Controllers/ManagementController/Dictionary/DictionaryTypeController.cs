using JustCommerce.Application.Features.ManagemenetFeatures.DictionaryType.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.ManagementController.Dictionary
{
    [Route("/api/management/dictionaryType")]
    public class DictionaryTypeController : BaseApiController
    {
        public DictionaryTypeController()
        {

        }

        [HttpGet]
        [Route("enum")]
        public async Task<IActionResult> GetDictionayTypeEnum(CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetDictionaryTypeEnum.Query(), cancellationToken)));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetDictionaryType(Guid shopId,CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetDictionaryType.Query(shopId), cancellationToken)));
        }
    }
}
