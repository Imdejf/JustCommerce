using JustCommerce.Application.Features.ManagemenetFeatures.Language.Query;
using JustCommerce.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.CommonController.Language
{
    [Route("api/[controller]")]
    public class LanguageController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllLanguage(GetLanguage.Query query, CancellationToken cancellationToken = default)
    }
}
