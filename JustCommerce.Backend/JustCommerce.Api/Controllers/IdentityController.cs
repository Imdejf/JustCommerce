using JustCommerce.Application.Features.CommonFeatures.AuthFeatures;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers
{
    [Route("/api/Identity")]
    public class IdentityController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public IdentityController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// Refreshes current user JWT
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>JwtResponse</returns>
        [HttpGet]
        [Authorize]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken)
        {
            //var result = await Mediator.Send(new RefreshToken.Query(), cancellationToken);
            //return Json(ApiResponse.Success(200, result));
            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(Register.Command command, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(201, result));
        }

    }
}
