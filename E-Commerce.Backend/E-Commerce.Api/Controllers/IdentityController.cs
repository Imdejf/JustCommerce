using E_Commerce.Shared.Abstract;
using E_Commerce.Shared.Models;
using E_Commerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
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
            var result = await Mediator.Send(new RefreshToken.Query(), cancellationToken);
            return Json(ApiResponse.Success(200, result));
        }

    }
}
