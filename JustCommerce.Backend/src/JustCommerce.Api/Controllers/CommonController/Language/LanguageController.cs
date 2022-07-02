using JustCommerce.Application.Features.ManagemenetFeatures.Language.Command;
using JustCommerce.Application.Features.ManagemenetFeatures.Language.Query;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.CommonController.Language
{
    [Route("api/language")]
    public class LanguageController : BaseApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllLanguage(Guid shopId, CancellationToken cancellationToken = default)
        {
            return Ok(ApiResponse.Success((200), await Mediator.Send(new GetLanguage.Query(shopId), cancellationToken)));
        }

        [HttpGet]
        [Route("{languageId}")]
        public async Task<IActionResult> GetLanguageById(Guid languageId, CancellationToken cancellationToken = default)
        {
            return Ok(ApiResponse.Success((200), await Mediator.Send(new GetLangaugeById.Query(languageId), cancellationToken)));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GetLanguageById(CreateLanguage.Command command, CancellationToken cancellationToken = default)
        {
            return Ok(ApiResponse.Success((200), await Mediator.Send(command, cancellationToken)));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> GetLanguageById(UpdateLanguage.Command command, CancellationToken cancellationToken = default)
        {
            return Ok(ApiResponse.Success((200), await Mediator.Send(command, cancellationToken)));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLanguageById(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(ApiResponse.Success((200), await Mediator.Send(new DeleteLanguage.Command(id), cancellationToken)));
        }
    }
}
