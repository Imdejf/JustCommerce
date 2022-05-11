using JustCommerce.Application.Features.AdministrationFeatures.Article.Article;
using JustCommerce.Application.Features.AdministrationFeatures.Article.Command;
using JustCommerce.Shared.Abstract;
using JustCommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Controllers.AdministrationController.Article
{
    [Route("/api/administration/article")]
    public class ArticleController : BaseApiController
    {
        public ArticleController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetArticle(Guid shopId,CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetArticle.Query(shopId), cancellationToken)));
        }

        [HttpGet]
        [Route("{articleId}")]
        public async Task<IActionResult> GetArticleById(Guid articleId, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(200, await Mediator.Send(new GetArticleById.Query(articleId), cancellationToken)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticle.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }

        [HttpPut]
        public async Task<IActionResult> CreateArticle(UpdateArticle.Command command, CancellationToken cancellationToken)
        {
            return Ok(ApiResponse.Success(201, await Mediator.Send(command, cancellationToken)));
        }
    }
}
