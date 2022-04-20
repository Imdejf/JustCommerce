using JustCommerce.Application.Features.AdministrationFeatures.Product.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Product
{
    [Route("/api/administration/product")]
    public class ProductController : BaseApiController
    {

        public ProductController()
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateProduct(CreateProduct.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }
    }
}

